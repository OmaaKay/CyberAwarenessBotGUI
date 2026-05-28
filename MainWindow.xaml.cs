
using System;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Input;


namespace CyberAwarenessBotGUI
{
    public partial class MainWindow : Window
    {
        private User currentUser;

        private bool hasName = false;

        private BotBrain botBrain = new BotBrain();

        public MainWindow()
        {
            InitializeComponent();

            PlayGreetingAudio();

            ShowWelcomeMessage();
        }


        // Plays welcome audio
        private void PlayGreetingAudio()
        {
            try
            {
                string audioPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "audio",
                    "greeting.wav"
                );

                if (File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);

                    player.Play();
                }
                else
                {
                    DisplaySystemMessage("Audio file not found.");
                }
            }
            catch (Exception ex)
            {
                DisplaySystemMessage($"Audio error: {ex.Message}");
            }
        }

        // First chatbot messages
        private void ShowWelcomeMessage()
        {
            DisplayBotMessage("Dumelang! I am your cybersecurity assistant.");

            DisplayBotMessage("Please enter your name to begin.");
        }

        // Send button
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessInput();
        }

        // Enter key
        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessInput();
            }
        }

        // Main chatbot logic
        private void ProcessInput()
        {
            string input = UserInputTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            DisplayUserMessage(input);

            UserInputTextBox.Clear();

            // First input becomes username
            if (!hasName)
            {
                currentUser = new User(input);

                hasName = true;

                DisplayBotMessage($"Hello, {currentUser.Name}.");

                DisplayBotMessage("It is important for South Africans to stay safe online.");

                DisplayBotMessage("You can ask me about passwords, phishing scams, suspicious links, public Wi-Fi, and scams.");

                return;
            }

            // Exit command
            if (input.ToLower() == "exit")
            {
                DisplayBotMessage("Thank you for chatting with me. Stay safe online.");

                UserInputTextBox.IsEnabled = false;

                SubmitButton.IsEnabled = false;

                return;
            }

            // Get chatbot response
            string response = botBrain.GetResponse(input);

            DisplayBotMessage(response);
        }

        // Shows bot messages
        private void DisplayBotMessage(string message)
        {
            ChatLogDisplay.AppendText($"[BOT]: {message}\n\n");

            ChatScrollContainer.ScrollToEnd();
        }

        // Shows user messages
        private void DisplayUserMessage(string message)
        {
            ChatLogDisplay.AppendText($"[YOU]: {message}\n\n");

            ChatScrollContainer.ScrollToEnd();
        }

        // Shows system messages
        private void DisplaySystemMessage(string message)
        {
            ChatLogDisplay.AppendText($"[SYSTEM]: {message}\n\n");

            ChatScrollContainer.ScrollToEnd();
        }
    }
}