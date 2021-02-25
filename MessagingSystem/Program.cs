using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingSystem
{
    class Message
    {
        string body;
        public string subject;
        string sender;
        DateTime timestamp;

        public Message(string uiBody, string uiSubject, string uiSender)
        {
            body = uiBody;
            subject = uiSubject;
            sender = uiSender;
            timestamp = DateTime.Now;
        }

        public void printMessage()
        {
            Console.WriteLine("Subject: " + subject);
            Console.WriteLine(body);
            Console.WriteLine("Sender: " + sender);
            Console.WriteLine(timestamp);

        }
    }
    class Program
    {
        private static List<Message> messages = new List<Message>();
        private static bool userSaysContinue = true;

        static void Main(string[] args)
        {
            while(userSaysContinue)
            {
                dispatchMenuChoice(menu().ToLower());
            }
        }

        private static string menu()
        {
            Console.WriteLine("Would you like to C)reate a new message R)ead an Existing message S)ee list of messages Q)uit");
            string userChoice = Console.ReadLine();
            return userChoice;
        }

        private static Message createMessage()
        {            
            Console.WriteLine("What would you like to set as a subject?");
            string subj = Console.ReadLine();
            Console.WriteLine("What would you like to set as the Body?");
            string bod = Console.ReadLine();
            Console.WriteLine("Who is sending this message?");
            string send = Console.ReadLine();
            Message thisMessage = new Message(bod, subj, send);
            return thisMessage;
        }

        private static void dispatchMenuChoice(string choice)
        {
            if (choice == "c")
            {
                Message message = createMessage();
                messages.Add(message);
                Console.WriteLine("Message saved as number " + (messages.Count - 1));
            }
            else if (choice == "r")
            {
                int messageNumber = 0;
                Console.WriteLine("Which Message Number would you like to see? (please input message number or see all messages to see message numbers)");
                try
                {
                    messageNumber = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("please input a number!");
                    dispatchMenuChoice(menu().ToLower());
                }
                if (messageNumber < messages.Count)
                {
                    readMessage(messageNumber);
                }
                else
                {
                    Console.WriteLine("You didn't enter a valid message number please try again, or see list of all messages");
                    dispatchMenuChoice(menu().ToLower());
                }
            }
            else if (choice == "s")
            {
                printMessages();
            }
            else if (choice == "q")
            {
                userSaysContinue = false;
            }
            else
            {
                Console.WriteLine("You didn't enter a valid choice, please choose again");
                dispatchMenuChoice(menu().ToLower()) ;
            }
            
        }

        private static void printMessages()
        {
            int i = 0;
            foreach(Message msg in messages)
            {
                Console.WriteLine(i + ") subject: " + msg.subject);
                i++;
            }
        }

        private static void readMessage(int id)
        {
            messages[id].printMessage();
        }
    }
}
