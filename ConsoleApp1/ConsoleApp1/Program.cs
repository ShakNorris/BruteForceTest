using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace G17_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Shako\Passwords.txt";
            GenerationType type;
            Console.WriteLine("What is the minimum length of the password?");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the maximum length of the password?");
            int max = Convert.ToInt32(Console.ReadLine());

            string typeName = Console.ReadLine();
            if (typeName == "Letters")
            {
                type = GenerationType.OnlyLetters;
            }
            else if (typeName == "Digits")
            {
                type = GenerationType.OnlyDigits;
            }
            else
            {
                type = GenerationType.LettersAndDigits;
            }



            GenerateFile(path, min, max, type);

            Console.ReadKey();
        }

        static void GenerateFile(string filePath, int minLength, int maxLength, GenerationType type)
        {
            FileStream file = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);
            List<char> Characters = new List<char>();
            List<string> Passwords = new List<string>();
            string password = "";

            if (type == GenerationType.OnlyLetters)
            {
                AddLetters(Characters);
                for (int i = minLength; i <= maxLength; i++)
                {
                    GeneratePassword(Characters, Passwords, password, i);
                }
                foreach (var x in Passwords)
                {
                    writer.WriteLine(x);
                }
                writer.Close();
            }

            if (type == GenerationType.OnlyDigits)
            {
                AddDigits(Characters);
                for (int i = minLength; i <= maxLength; i++)
                {
                    GeneratePassword(Characters, Passwords, password, i);
                }
                foreach (var x in Passwords)
                {
                    writer.WriteLine(x);
                }
                writer.Close();
            }

            if (type == GenerationType.LettersAndDigits)
            {
                AddLettersAndDigits(Characters);
                for (int i = minLength; i <= maxLength; i++)
                {
                    GeneratePassword(Characters, Passwords, password, i);
                }
                foreach (var x in Passwords)
                {
                    writer.WriteLine(x);
                }
                writer.Close();
            }
        }

        static void AddLetters(List<char> l)
        {
            for (char i = 'a'; i <= 'z'; i++)
            {
                l.Add(i);
            }
            for (char i = 'A'; i < 'Z'; i++)
            {
                l.Add(i);
            }
        }

        static void AddDigits(List<char> l)
        {
            for (char i = '0'; i <= '9'; i++)
            {
                l.Add(i);
            }
        }

        static void AddLettersAndDigits(List<char> l)
        {
            AddLetters(l);
            AddDigits(l);
        }

        static void GeneratePassword(List<char> characters, List<string> passwords, string password, int limit)
        {

            for (int j = 0; j < characters.Count(); j++)
            {
                if (limit == 0)
                {
                    passwords.Add(password);
                    break;
                }
                string newPassword = password + characters[j];
                GeneratePassword(characters, passwords, newPassword, limit - 1);
            }
        }
    }

    public enum GenerationType
    {
        OnlyLetters,
        OnlyDigits,
        LettersAndDigits,
    }
}