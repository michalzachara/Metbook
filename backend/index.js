import express from "express";
import dotenv from "dotenv";
import bcrypt from "bcrypt";
import moment from "moment";

import User from "./model/user.js";
import connect from "./db/connect.js";

const app = express();
app.use(express.json());

dotenv.config();

const PORT = process.env.PORT || 3000;

function isAtLeast13YearsOld(dateOfBirth) {
  const today = moment();
  const birthDate = moment(dateOfBirth);
  const age = today.diff(birthDate, 'years');

  return age >= 13;
}

app.post("/api/signup", async (req, res) => {
  try {
    const { name, surname, username, password, confirmPassword, gender, date } =
      req.body;

    if (password !== confirmPassword) {
      return res.status(400).json({ error: "Passwords don't match" });
    }

    if(!isAtLeast13YearsOld(date)){
      return res.status(400).json({ error: "You must be over 13 years" });
    }

    const user = await User.findOne({ username });

    if (user) {
      return res.status(400).json({ error: "Username already exists" });
    }

    const salt = await bcrypt.genSalt(10);
    const hashedPassword = await bcrypt.hash(password, salt);

    const boyProfilePic = `https://avatar.iran.liara.run/public/boy?username=${username}`;
    const girlProfilePic = `https://avatar.iran.liara.run/public/girl?username=${username}`;

    const currentDate = new Date();

    const newUser = new User({
      name,
      surname,
      username,
      password: hashedPassword,
      gender,
      profilePic: gender === "male" ? boyProfilePic : girlProfilePic,
      role: "user",
      date, 
      createdAt: (currentDate.getFullYear() + "-" + (currentDate.getMonth() + 1) + "-" + (currentDate.getDate()+1)),
    });

    if (newUser) {
      await newUser.save();
      res.status(201).json({ message: "User created successfully" });
    } else {
      res.status(400).json({ error: "Błedne dane" });
    }
  } catch (error) {
    console.log("Error in signup controller", error.message);
    res.status(500).json({ error: "Internal Server Error 1" });
  }
});

app.post("/api/login", async (req, res) => {
  try {
    const { username, password } = req.body;
    const user = await User.findOne({ username });
    const isPasswordCorrect = await bcrypt.compare(
      password,
      user?.password || ""
    );

    if (!user || !isPasswordCorrect) {
      return res.status(400).json({ error: "Nieprawidłowy login lub hasło" });
    }

    res.status(200).json({
      _id: user._id,
      name: user.name,
      surname: user.surname,
      username: user.username,
      profilePic: user.profilePic,
      role: user.role,
      date: user.date,
      password: user.password,
      createdAt: user.createdAt,
      gender: user.gender,
    });

  } catch (error) {
    console.log("Error in login controller", error.message);
    res.status(500).json({ error: "Internal Server Error" });
  }
});

app.get("/api/users", async (req, res) => {
  try {
    const users = await User.find().select("-password").limit(20);
    res.status(200).json(users);
  } catch (error) {
    console.error("Błąd podczas pobierania użytkowników:", error.message);
    res.status(500).json({ error: "Internal Server Error" });
  }
});


//---------------------------------------------------do zrobinia update profilu z zmianami pojedynczymh
app.put("/api/profile", async (req, res) => {
  try {
    const { _id, username, surname, name, gender, date, password, newpassword, confirmNewPassword } = req.body;

    const user = await User.findById(_id);

    if (!user) {
      return res.status(404).json({ error: "User not found" });
    }

    if (username) {
      const existingUser = await User.findOne({ username });

      if (existingUser && existingUser._id.toString() !== _id) {
        return res.status(400).json({ error: "Username already taken" });
      }
    } 

    //czy ma 13 lat
    if(!isAtLeast13YearsOld(date)){
      return res.status(400).json({ error: "You must be over 13 years" })
    }

    
    const isPasswordCorrect = await bcrypt.compare(
      password,
      user?.password || ""
    );
    
    //sparwdza poprawnosc hasla do zmiany
    if(!isPasswordCorrect){
      return res.status(400).json({ error: "Invalid password" });
    }

    if(newpassword !== confirmNewPassword){
      return res.status(400).json({ error: "new password and confirm password dont match" });
    }

    user.username = username || user.username;
    user.surname = surname || user.surname;
    user.name = name || user.name;
    user.gender = gender || user.gender;
    user.date = date || user.date;

    await user.save();

    res.status(200).json({ message: "User updated successfully", user });
  } catch (error) {
    console.log("Error in update user controller", error.message);
    res.status(500).json({ error: "Internal Server Error" });
  }
});

app.get("/api/search", async (req, res) => {
    //---------------------------------------do zrobienia moderator wyszukuje tylko uzytkonikow a admin tylko moderatorow
  try {
    const { query } = req.query;

    if (!query) {
      return res.status(400).json({ error: "Query parameter is required" });
    }

    const users = await User.find({
      $or: [
        { name: { $regex: query, $options: "i" } },
        { surname: { $regex: query, $options: "i" } },
        { login: { $regex: query, $options: "i" } },
      ],
    })
      .select("-password")
      .sort({ name: 1 })
      .limit(20);

    res.status(200).json(users);

  } catch (error) {
    console.error("Błąd podczas wyszukiwania użytkowników:", error.message);
    res.status(500).json({ error: "Internal Server Error" });
  }
});

app.delete("/api/deleteUser", async (req, res) => {
  try {
    const { _id } = req.body;
    const user = await User.findByIdAndDelete(_id);

    if (!user) {
      return res.status(404).json({ error: "User not found" });
    }

    res.status(200).json({ message: "User deleted successfully" });
  }
  catch (error) {
    console.error("Błąd podczas usuwania użytkownika:", error.message);
    res.status(500).json({ error: "Internal Server Error" });
  }
})


app.put("/api/changeRole", async (req, res) => {
  try {
    const { _id, role } = req.body; //id zmiany uzytkonika
    const user = await User.findById(_id);

    //moderator zmienia z usera na moderatora
    if(role == "moderator"  && user.role !== "admin") {
      user.role = user.role === "user" ? "moderator" : "user";
    }

    //admin zmienia z moderatora na admina
    if(role == "admin" && user.role !== "user") {
      user.role = user.role === "moderator" ? "admin" : "moderator";
    }

    await user.save();
    res.status(200).json({ message: "Role changed successfully", user });
  }
  catch(error){
    console.log("Error in role controller", error.message);
    res.status(500).json({ error: "Internal Server Error" });
  }
})

app.listen(PORT, () => {
  connect();
  console.log(`Server started on port ${PORT}`);
});