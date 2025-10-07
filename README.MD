# 🏋️‍♂️ Metbook - Social App

Metbook is a **desktop social app**.  
Users can create and edit profiles.  
Administrators have advanced controls to manage users and roles.

---

## 📦 Installation

### 1️⃣ Clone the repository

```bash
git clone https://github.com/YourRepo/metbook.git
cd metbook

## 📦 Installation

Clone the repository and navigate to the main directory:

```bash
git clone https://github.com/m2ichu/wilksCalculatorApp.git
cd wilksCalculatorApp
```

Create a `.env` file in the backend folder:

```env
# MongoDB
MONGO_URI=<your_mongo_uri>

```

---

## 🧑‍💻 Development Setup

### Backend

```bash
npm install
npm run start
```

### Frontend

```bash
cd frontend
open FrontEnd.sln
```

And run aplication on Visual Studio

---

## 🌐 Get Started

* Register new user
* In MongoDB, change the property `role` to `admin` for that account.
* Create new users and explore app 

---

## 🖥️ Technologies

- **Frontend (Desktop):** C# / Windows Forms
- **Backend:** Node.js + Express  
- **Database:** MongoDB  
- **Authentication:** JWT  
 
---

## 📌 Notes

- The backend must be running for the desktop application to function correctly.
- User passwords are securely hashed with **bcrypt**.
- Roles are expandable beyond `user` and `admin`.
- JWT is used for authentication and session management.

---

## 📄 License

This project is licensed under the [MIT License](https://choosealicense.com/licenses/mit/).
