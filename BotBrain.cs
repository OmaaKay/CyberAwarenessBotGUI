
using System;

namespace CyberAwarenessBotGUI
{
    public class BotBrain
    {
        // Random generator
        private Random random = new Random();

        // Password responses
        private string[] passwordResponses =
        {
            "Use strong and unique passwords with uppercase letters, lowercase letters, numbers, and symbols. Avoid using personal information.",
            
            "Make sure your passwords are long and unique. A strong password should combine letters, numbers, and symbols and should not be reused across accounts.",
            
            "Avoid using personal information like your name or birthdate in passwords. Reusing passwords can place multiple accounts at risk if one account is hacked."
        };

        // Phishing responses
        private string[] phishingResponses =
        {
            "Be careful of emails or messages asking for personal information or banking details. Always verify the sender before clicking links.",
            
            "Phishing attacks often come from fake emails pretending to be banks or trusted companies. Always check the sender carefully.",
            
            "If a message creates urgency such as 'your account will be closed', pause and verify it directly from the official website instead of clicking links."
        };

        // Link responses
        private string[] linkResponses =
        {
            "Always hover over links before clicking them to check where they really lead.",
            
            "Cybercriminals often disguise malicious links to look legitimate. Always preview the URL before clicking.",
            
            "When unsure about a link, avoid clicking it and instead type the website address manually into your browser."
        };

        // Wi-Fi responses
        private string[] wifiResponses =
        {
            "Avoid entering sensitive information while connected to public Wi-Fi networks.",
            
            "Public Wi-Fi networks are often unsecured, which means hackers may intercept your data or passwords.",
            
            "If you must use public Wi-Fi, avoid banking or sensitive logins unless you are using a secure VPN."
        };

        // Scam responses
        private string[] scamResponses =
        {
            "Be cautious of fake WhatsApp messages pretending to be family members or investment companies.",
            
            "Scammers often pretend to be someone you know in order to trick you into sending money or personal information.",
            
            "Be careful of online offers promising quick money or investments that seem too good to be true."
        };

        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "Please enter a question.";
            }

            string cleanInput = userInput.ToLower().Trim();

            // Basic conversation
            if (cleanInput.Contains("how are you"))
            {
                return "I am functioning perfectly and ready to help you stay safe online.";
            }

            else if (cleanInput.Contains("purpose") || cleanInput.Contains("who are you"))
            {
                return "My purpose is to educate South African citizens about cybersecurity awareness.";
            }

            else if (cleanInput.Contains("help") || cleanInput.Contains("what can i ask"))
            {
                return "You can ask me about passwords, phishing scams, suspicious links, public Wi-Fi, and online scams.";
            }

            // Password safety
            else if (cleanInput.Contains("password"))
            {
                return passwordResponses[random.Next(passwordResponses.Length)];
            }

            // Phishing
            else if (cleanInput.Contains("phishing"))
            {
                return phishingResponses[random.Next(phishingResponses.Length)];
            }

            // Links
            else if (cleanInput.Contains("link"))
            {
                return linkResponses[random.Next(linkResponses.Length)];
            }

            // Public Wi-Fi
            else if (cleanInput.Contains("wifi") || cleanInput.Contains("public"))
            {
                return wifiResponses[random.Next(wifiResponses.Length)];
            }

            // WhatsApp scams
            else if (cleanInput.Contains("whatsapp") || cleanInput.Contains("scam"))
            {
                return scamResponses[random.Next(scamResponses.Length)];
            }

            // Exit
            else if (cleanInput.Contains("bye"))
            {
                return "Goodbye. Stay safe online.";
            }

            // Default response
            else
            {
                return "I am not sure how to answer that yet. Try asking about passwords, phishing, or scams.";
            }
        }
    }
}
