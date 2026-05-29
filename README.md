# South African Cybersecurity Awareness Chatbot

## Project Overview
The South African Cybersecurity Awareness Chatbot is a GUI-based desktop application developed in C# using WPF. The purpose of the chatbot is to educate users about important cybersecurity topics such as password safety, phishing scams, suspicious links, online scams, and public Wi-Fi risks.

The chatbot was designed to provide an interactive and user-friendly cybersecurity awareness experience for South African users through conversational interaction, sentiment-aware responses, memory recall, and randomized cybersecurity tips.

---

# Features

## 1. GUI Interface
- Modern WPF graphical user interface
- User-friendly layout and color scheme
- ASCII art banner included in the interface
- Scrollable chatbot conversation area
- Input textbox and send button
- Voice greeting audio on startup

---

## 2. Keyword Recognition
The chatbot recognizes cybersecurity-related keywords including:
- Passwords
- Phishing
- Suspicious links
- Public Wi-Fi
- Online scams
- WhatsApp scams

The chatbot responds with relevant cybersecurity guidance when these topics are detected.

---

## 3. Randomized Responses
The chatbot uses arrays together with the `Random` class to generate varied responses for:
- Password safety
- Phishing scams
- Suspicious links
- Wi-Fi safety
- Online scams
- Unknown input handling

This creates more natural and engaging conversations.

---

## 4. Conversation Flow
The chatbot maintains conversational context using memory variables such as:
- `currentTopic`
- `lastSentiment`

Users can ask follow-up questions such as:
- "Tell me more"
- "Explain more"
- "Another tip"

The chatbot continues discussing the current cybersecurity topic naturally without restarting the conversation.

---

## 5. Sentiment Detection
The chatbot detects basic user emotions including:
- Worried
- Curious
- Frustrated
- Confused

Responses are adjusted dynamically to provide encouragement and supportive cybersecurity guidance.

Example:
- User: "I am worried about phishing scams."
- Bot: "It's completely understandable to feel worried. Scammers can be very convincing."

---

## 6. Error Handling and Edge Cases
The chatbot includes:
- Empty input validation
- Unknown keyword handling
- Default fallback responses
- Audio exception handling using `try-catch`
- Stable conversation handling without crashing

---

# Technologies Used

- C#
- WPF (Windows Presentation Foundation)
- .NET
- Visual Studio
- XAML

---

# Classes Used

## MainWindow.xaml.cs
Handles:
- GUI interaction
- User input processing
- Audio playback
- Message display
- Conversation flow

## BotBrain.cs
Handles:
- Chatbot logic
- Keyword recognition
- Randomized responses
- Sentiment detection
- Follow-up handling
- Error handling

## User.cs
Stores user information such as:
- Username

---

# Key Programming Concepts Demonstrated

- Classes and objects
- Methods
- Arrays
- Conditional statements
- Variables
- Random object generation
- String handling
- Exception handling
- GUI development
- Event-driven programming

---

# How to Run the Application

1. Open the project in Visual Studio.
2. Build the solution.
3. Run the application.
4. Enter your name when prompted.
5. Begin asking cybersecurity-related questions.

---

# Example Questions

- "Tell me about password safety"
- "How do phishing scams work?"
- "I am worried about scams"
- "Tell me more"
- "Explain more about phishing"
- "What should I know about public Wi-Fi?"

---

# Educational Purpose
This project was developed for educational purposes to demonstrate:
- GUI application development
- Cybersecurity awareness education
- Conversational chatbot design
- User interaction and sentiment detection
- Software structure and maintainability

---

# Author
Developed as part of a cybersecurity awareness chatbot assignment using C# and WPF.