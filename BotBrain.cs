
using System;

namespace CyberAwarenessBotGUI
{
    public class BotBrain
    {
        // Random object for varied responses
        private Random random = new Random();

        // Memory variable for conversation flow
        private string currentTopic = "";

        // Sentiment memory
        private string lastSentiment = "";

        // Password responses
        private string[] passwordResponses =
        {
            "Use strong and unique passwords with uppercase letters, lowercase letters, numbers, and symbols. Avoid using personal information.",

            "Make sure your passwords are long and unique. A strong password should combine letters, numbers, and symbols and should not be reused across accounts.",

            "Avoid using personal information like your name or birthdate in passwords. Reusing passwords can place multiple accounts at risk if one account is hacked."
        };

        // Password follow-up responses
        private string[] passwordFollowUps =
        {
            "Using a password manager can help you generate and safely store strong passwords for different accounts.",

            "Changing your important passwords regularly reduces the risk of long-term account compromise.",

            "Multi-factor authentication adds another layer of protection even if someone discovers your password."
        };

        // Phishing responses
        private string[] phishingResponses =
        {
            "Be careful of emails or messages asking for personal information or banking details. Always verify the sender before clicking links.",

            "Phishing attacks often come from fake emails pretending to be banks or trusted companies. Always check the sender carefully.",

            "If a message creates urgency such as 'your account will be closed', pause and verify it directly from the official website instead of clicking links."
        };

        // Phishing follow-up responses
        private string[] phishingFollowUps =
        {
            "Phishing scams sometimes use fake websites that look almost identical to real banking websites.",

            "Attachments in suspicious emails may contain malware that can steal personal information from your device.",

            "Always contact the company directly through official channels if you are unsure whether a message is legitimate."
        };

        // Link responses
        private string[] linkResponses =
        {
            "Always hover over links before clicking them to check where they really lead.",

            "Cybercriminals often disguise malicious links to look legitimate. Always preview the URL before clicking.",

            "When unsure about a link, avoid clicking it and instead type the website address manually into your browser."
        };

        // Link follow-up responses
        private string[] linkFollowUps =
        {
            "Shortened links can hide dangerous websites, so be cautious before opening them.",

            "Secure websites usually begin with HTTPS, which helps protect your information online.",

            "Fake links are often designed to steal login details by redirecting users to cloned websites."
        };

        // Wi-Fi responses
        private string[] wifiResponses =
        {
            "Avoid entering sensitive information while connected to public Wi-Fi networks.",

            "Public Wi-Fi networks are often unsecured, which means hackers may intercept your data or passwords.",

            "If you must use public Wi-Fi, avoid banking or sensitive logins unless you are using a secure VPN."
        };

        // Wi-Fi follow-up responses
        private string[] wifiFollowUps =
        {
            "Hackers on public Wi-Fi can sometimes monitor unprotected network traffic.",

            "Turning off automatic Wi-Fi connection settings can reduce your exposure to fake networks.",

            "Avoid downloading sensitive files while connected to unknown public hotspots."
        };

        // Scam responses
        private string[] scamResponses =
        {
            "Be cautious of fake WhatsApp messages pretending to be family members or investment companies.",

            "Scammers often pretend to be someone you know in order to trick you into sending money or personal information.",

            "Be careful of online offers promising quick money or investments that seem too good to be true."
        };

        // Scam follow-up responses
        private string[] scamFollowUps =
        {
            "Scammers often use emotional pressure to make victims act quickly without thinking carefully.",

            "Never share OTP codes or banking PINs with anyone through WhatsApp or SMS.",

            "Reporting scams helps protect other people from becoming victims of cybercrime."
        };

        private string DetectSentiment(string input)
        {
            input = input.ToLower();

            if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid"))
            {
                return "worried";
            }

            if (input.Contains("frustrated") || input.Contains("annoyed") || input.Contains("angry"))
            {
                return "frustrated";
            }

            if (input.Contains("curious") || input.Contains("interested") || input.Contains("wondering"))
            {
                return "curious";
            }

            return "";
        }

        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "Please enter a question.";
            }

            string cleanInput = userInput.ToLower().Trim();

            // Follow-up conversation flow
            if (cleanInput.Contains("tell me more") ||
                cleanInput.Contains("explain more") ||
                cleanInput.Contains("please elaborate") ||
                cleanInput.Contains("another tip") ||
                cleanInput.Contains("more details"))
            {
                if (currentTopic == "password")
                {
                    return passwordFollowUps[random.Next(passwordFollowUps.Length)];
                }

                else if (currentTopic == "phishing")
                {
                    return phishingFollowUps[random.Next(phishingFollowUps.Length)];
                }

                else if (currentTopic == "link")
                {
                    return linkFollowUps[random.Next(linkFollowUps.Length)];
                }

                else if (currentTopic == "wifi")
                {
                    return wifiFollowUps[random.Next(wifiFollowUps.Length)];
                }

                else if (currentTopic == "scam")
                {
                    return scamFollowUps[random.Next(scamFollowUps.Length)];
                }

                else
                {
                    return "Please ask about a cybersecurity topic first so I can continue helping you.";
                }
            }

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
                currentTopic = "password";

                return passwordResponses[random.Next(passwordResponses.Length)];
            }

            // Phishing
            else if (cleanInput.Contains("phishing"))
            {
                currentTopic = "phishing";

                return phishingResponses[random.Next(phishingResponses.Length)];
            }

            // Links
            else if (cleanInput.Contains("link"))
            {
                currentTopic = "link";

                return linkResponses[random.Next(linkResponses.Length)];
            }

            // Public Wi-Fi
            else if (cleanInput.Contains("wifi") || cleanInput.Contains("public"))
            {
                currentTopic = "wifi";

                return wifiResponses[random.Next(wifiResponses.Length)];
            }

            // WhatsApp scams
            else if (cleanInput.Contains("whatsapp") || cleanInput.Contains("scam"))
            {
                currentTopic = "scam";

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






















/*
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
*/