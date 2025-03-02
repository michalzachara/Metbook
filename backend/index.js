import express from 'express'
import dotenv from 'dotenv'
import bcrypt from 'bcrypt'
import moment from 'moment'

import User from './model/user.js'
import connect from './db/connect.js'

const app = express()
app.use(express.json())

dotenv.config()

const PORT = process.env.PORT || 3000

function isAtLeast13YearsOld(dateOfBirth) {
	const today = moment()
	const birthDate = moment(dateOfBirth)
	const age = today.diff(birthDate, 'years')

	return age >= 13
}

app.post('/api/signup', async (req, res) => {
	try {
		const { name, surname, username, password, confirmPassword, gender, date } = req.body

		if (password !== confirmPassword) {
			return res.status(400).json({ error: "Passwords don't match" })
		}

		if (!isAtLeast13YearsOld(date)) {
			return res.status(400).json({ error: 'You must be over 13 years' })
		}

		const user = await User.findOne({ username })

		if (user) {
			return res.status(400).json({ error: 'Username already exists' })
		}

		const salt = await bcrypt.genSalt(10)
		const hashedPassword = await bcrypt.hash(password, salt)

		const boyProfilePic = `https://avatar.iran.liara.run/public/boy?username=${username}`
		const girlProfilePic = `https://avatar.iran.liara.run/public/girl?username=${username}`

		const currentDate = new Date()

		const newUser = new User({
			name,
			surname,
			username,
			password: hashedPassword,
			gender,
			profilePic: gender === 'male' ? boyProfilePic : girlProfilePic,
			role: 'user',
			date,
			createdAt: currentDate.getFullYear() + '-' + (currentDate.getMonth() + 1) + '-' + (currentDate.getDate() + 1),
		})

		if (newUser) {
			await newUser.save()
			res.status(201).json({ message: 'User created successfully' })
		} else {
			res.status(400).json({ error: 'Błedne dane' })
		}
	} catch (error) {
		console.log('Error in signup controller', error.message)
		res.status(500).json({ error: 'Internal Server Error 1' })
	}
})

app.post('/api/login', async (req, res) => {
	try {
		const { username, password } = req.body
		const user = await User.findOne({ username })
		const isPasswordCorrect = await bcrypt.compare(password, user?.password || '')

		if (!user || !isPasswordCorrect) {
			return res.status(400).json({ error: 'Nieprawidłowy login lub hasło' })
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
		})
	} catch (error) {
		console.log('Error in login controller', error.message)
		res.status(500).json({ error: 'Internal Server Error' })
	}
})

//---------------------------------------------------do zrobinia update profilu z zmianami pojedynczymh
app.put('/api/profile', async (req, res) => {
	try {
		const { _id, username, surname, name, date } = req.body

		const user = await User.findById(_id)

		if (!user) {
			return res.status(404).json({ error: 'User not found' })
		}

		// Sprawdzenie czy nowa nazwa użytkownika jest zajęta
		if (username) {
			const existingUser = await User.findOne({ username })
			if (existingUser && existingUser._id.toString() !== _id) {
				return res.status(400).json({ errorUsername: 'Username already taken' })
			}
		}

		// Sprawdzenie, czy użytkownik ma co najmniej 13 lat
		if (!isAtLeast13YearsOld(date)) {
			return res.status(400).json({ error: 'You must be over 13 years old' })
		}

		// Aktualizacja danych użytkownika
		user.username = username || user.username
		user.surname = surname || user.surname
		user.name = name || user.name
		user.date = date || user.date

		await user.save()

		res.status(200).json({ message: 'User updated successfully' })
	} catch (error) {
		console.error('Error in update user controller:', error.message)
		res.status(500).json({ error: 'Internal Server Error' })
	}
})

app.put('/api/profile/changePassword', async (req, res) => {
	const { _id, password, newPassword, confirmNewPassword } = req.body

	try {
		const user = await User.findById(_id)

		if (!user) {
			return res.status(404).json({ error: 'User not found' })
		}

		// Sprawdzenie poprawności aktualnego hasła
		const isPasswordCorrect = await bcrypt.compare(password, user.password)
		if (!isPasswordCorrect) {
			return res.status(400).json({ error: 'Invalid password' })
		}

		// Sprawdzenie poprawności nowego hasła
		if (newPassword || confirmNewPassword) {
			if (newPassword !== confirmNewPassword) {
				return res.status(400).json({ error: 'New password and confirm password do not match' })
			}
			// Hashowanie nowego hasła przed zapisaniem
			user.password = await bcrypt.hash(newPassword, 10)
		}

		await user.save()

		res.status(200).json({ message: 'Password changed successfully' })
	} catch (error) {
		console.error('Error in change password controller:', error.message)
		res.status(500).json({ error: 'Internal Server Error' })
	}
})

app.post('/api/users', async (req, res) => {
	try {
		const { role } = req.body

		// Sprawdzanie, czy rola została podana
		if (!role) {
			return res.status(400).json({ error: 'Rola jest wymagana' })
		}

		let users

		if (role === 'admin') {
			// Administrator widzi wszystkich użytkowników
			users = await User.find().select('-password').limit(50)
		} else if (role === 'moderator') {
			users = await User.find({ role: { $in: ['user', 'moderator'] } })
				.select('-password')
				.limit(20)
		} else {
			return res.status(403).json({ error: 'Brak uprawnień do wyświetlania użytkowników' })
		}

		res.status(200).json(users)
	} catch (error) {
		console.error('Błąd podczas pobierania użytkowników:', error.message)
		res.status(500).json({ error: 'Internal Server Error' })
	}
})

app.post('/api/search/', async (req, res) => {
	try {
		const { query, role } = req.body

		if (!query) {
			return res.status(400).json({ error: 'Query parameter is required' })
		}

		if (role === 'user') {
			return res.status(403).json({ error: 'You are not authorized to perform this action' })
		}

		// Budowanie zapytania do bazy w zależności od roli
		let searchCriteria = {
			$or: [
				{ name: { $regex: query, $options: 'i' } },
				{ surname: { $regex: query, $options: 'i' } },
				{ login: { $regex: query, $options: 'i' } },
			],
		}

		if (role === 'moderator'|| role === "admin") {
			searchCriteria.role = { $in: ['user', 'moderator'] }
		} else if (role === 'user') {
			return res.status(403).json({ error: 'Brak uprawnień do wyszukiwania użytkowników' })
		} 

		const users = await User.find(searchCriteria).select('-password').sort({ name: 1 }).limit(20)

		res.status(200).json(users)
	} catch (error) {
		console.error('Błąd podczas wyszukiwania użytkowników:', error.message)
		res.status(500).json({ error: 'Internal Server Error' })
	}
})

app.delete('/api/users/', async (req, res) => {
	try {
		const { _id, role } = req.body // Pobranie ID z URL
		console.log(role);
		if(role !== 'admin' && role !== "moderator") {
		return res.status(403).json({ error: 'Brak uprawnień do usuwania użytkowników' })
		}

		const user = await User.findByIdAndDelete(_id)

		if (!user) {
			return res.status(404).json({ error: 'User not found' })
		}

		res.status(200).json({ message: 'User deleted successfully' })
	} catch (error) {
		console.error('Błąd podczas usuwania użytkownika:', error.message)
		res.status(500).json({ error: 'Internal Server Error' })
	}
})

app.put('/api/changeRole', async (req, res) => {
	try {
		const { _id, role } = req.body // Pobranie id użytkownika oraz roli

		if (!role || !['user', 'moderator', 'admin'].includes(role)) {
			return res.status(400).json({ error: 'Invalid role' })
		}

		const user = await User.findById(_id) // Wyszukaj użytkownika po ID

		if (!user) {
			return res.status(404).json({ error: 'User not found' })
		}

		// Logika zmiany roli:
		// - Użytkownik -> Moderator
		if (role === 'moderator' || role !== 'admin') {
			user.role = user.role === 'user' ? 'moderator' : 'user'
		}

		// Zapisanie zaktualizowanego użytkownika
		await user.save()

		// Odpowiedź z sukcesem
		res.status(200).json({ message: 'Role changed successfully', user })
	} catch (error) {
		console.log('Error in role controller', error.message)
		res.status(500).json({ error: 'Internal Server Error' })
	}
})

app.listen(PORT, () => {
	connect()
	console.log(`Server started on port ${PORT}`)
})
