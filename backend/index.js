import express from "express";
import dotenv from "dotenv";
import bcrypt from "bcrypt";

import User from "./model/user.js";
import connect from "./db/connect.js";

const app = express();
app.use(express.json());

dotenv.config();

const PORT = process.env.PORT || 3000;
//this route is for testing
app.post("/api/signup", async (req, res) => {
  try {
    const { name, surname, username, password, confirmPassword, gender } =
      req.body;

    if (password !== confirmPassword) {
      return res.status(400).json({ error: "Passwords don't match" });
    }

    const user = await User.findOne({ username });

    if (user) {
      return res.status(400).json({ error: "Username already exists" });
    }

    const salt = await bcrypt.genSalt(10);
    const hashedPassword = await bcrypt.hash(password, salt);

    const boyProfilePic = `https://avatar.iran.liara.run/public/boy?username=${username}`;
    const girlProfilePic = `https://avatar.iran.liara.run/public/girl?username=${username}`;

    const newUser = new User({
      name,
      surname,
      username,
      password: hashedPassword,
      gender,
      profilePic: gender === "male" ? boyProfilePic : girlProfilePic,
      role: "user",
    });

    if (newUser) {
      await newUser.save();
      res.status(201).json({ message: "User created successfully" });
    } else {
      res.status(400).json({ error: "Invalid user data" });
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
      return res.status(400).json({ error: "Invalid username or password" });
    }

    res.status(200).json({
      _id: user._id,
      name: user.name,
      surname: user.surname,
      username: user.username,
      profilePic: user.profilePic,
      role: user.role,
      gender: user.gender,
    });
  } catch (error) {
    console.log("Error in login controller", error.message);
    res.status(500).json({ error: "Internal Server Error" });
  }
});

app.get("/api/users", async (req, res) => {
  try {
    const users = await User.find().select("-password");
    res.status(200).json(users);
  } catch (error) {
    console.error("Błąd podczas pobierania użytkowników:", error.message);
    res.status(500).json({ error: "Internal Server Error" });
  }
});

app.put("/api/profile", async (req, res) => {
  try {
    const { _id, username, surname, name, gender } = req.body;

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

    user.username = username || user.username;
    user.surname = surname || user.surname;
    user.name = name || user.name;
    user.gender = gender || user.gender;

    await user.save();

    res.status(200).json({ message: "User updated successfully", user });
  } catch (error) {
    console.log("Error in update user controller", error.message);
    res.status(500).json({ error: "Internal Server Error" });
  }
});

app.get("/api/search", async (req, res) => {
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

app.listen(PORT, () => {
  connect();
  console.log(`Server started on port ${PORT}`);
});
