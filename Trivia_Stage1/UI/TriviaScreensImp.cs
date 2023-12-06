using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Trivia_Stage1.Models;

namespace Trivia_Stage1.UI
{
    public class TriviaScreensImp : ITriviaScreens
    {

        private TriviaDbContext context = new TriviaDbContext();
        //Place here any state you would like to keep during the app life time
        //For example, player login details...
        private DbContext db = new TriviaDbContext();
        private UserDb currentUser = null;
        //Implememnt interface here
        public bool ShowLogin()
        {

            Console.WriteLine("Do you want to login? press Enter or anything else to continue If not, press (B) to go back");
            char c = Console.ReadKey(true).KeyChar;

            while (c != 'B' && c != 'b' && this.currentUser == null)
            {
                CleareAndTtile("Login");
                Console.WriteLine("Enter mail");
                string mail = Console.ReadLine();
                while (mail == null)
                {
                    Console.WriteLine("write a password!");
                    mail = Console.ReadLine();
                }
                Console.WriteLine("Enter password");
                string pass = Console.ReadLine();
                while (pass == null)
                {
                    Console.WriteLine("write a password!");
                    pass = Console.ReadLine();
                }

               
                Console.WriteLine("Logging in...");

                TriviaDbContext db = new TriviaDbContext();
                UserDb user = db.Login(pass, mail);
                if (user != null)
                {
                    Console.WriteLine("Login Successful!");
                    this.currentUser = user;
                }
                else
                {
                    Console.WriteLine("Failed to login");
                    int delay = 1000;
                    Thread.Sleep(delay);
                }
            }
            Console.ReadKey(true);
            return true;
        }
        public bool ShowSignup()
        {
            //Logout user if anyone is logged in!
            //A reference to the logged in user should be stored as a member variable
            //in this class! Example:
            this.currentUser = null;

            //Loop through inputs until a user/player is created or 
            //user choose to go back to menu
            char c = ' ';
            while (c != 'B' && c != 'b' && this.currentUser == null)
            {
                //Clear screen
                CleareAndTtile("Signup");

                Console.Write("Please Type your email: ");
                string email = Console.ReadLine();
                while (!IsEmailValid(email))
                {
                    Console.Write("Bad Email Format! Please try again:");
                    email = Console.ReadLine();
                }

                Console.Write("Please Type your password: ");
                string password = Console.ReadLine();
                while (!IsPasswordValid(password))
                {
                    Console.Write("password must be at least 4 characters! Please try again: ");
                    password = Console.ReadLine();
                }

                Console.Write("Please Type your Name: ");
                string name = Console.ReadLine();
                while (!IsNameValid(name))
                {
                    Console.Write("name must be at least 3 characters! Please try again: ");
                    name = Console.ReadLine();
                }


                Console.WriteLine("Connecting to Server...");

                try
                {
                    TriviaDbContext db = new TriviaDbContext();
                    this.currentUser = db.SignUp(name, password, email);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to signup! Email may already exist in DB!");
                    Console.WriteLine(ex.Message);
                }


                Console.WriteLine("Press (B)ack to go back or any other key to signup again...");
                c = Console.ReadKey(true).KeyChar;
            }
            //return true if signup suceeded!
            return (false);
        }

        public void ShowAddQuestion()
        {
            Console.WriteLine("Not implemented yet! Press any key to continue...");
            Console.ReadKey(true);
        }

        public void ShowPendingQuestions()
        {
            Console.WriteLine("Pending Question");
            char c = '9';
            foreach (QuestionsDb q in context.QuestionsDbs)
            {
                if (q.QuestionStatusId == 1)
                {
                    Console.WriteLine(q.Text);
                    Console.WriteLine(q.CorrectAns);
                    Console.WriteLine(q.WrongAns1);
                    Console.WriteLine(q.WrongAns2);
                    Console.WriteLine(q.WrongAns3);
                    Console.WriteLine("Press 1 to accept, 2 to reject");

                    while (c == '9')
                    {
                        c = Console.ReadKey().KeyChar;
                        if (c == 1)
                        { q.QuestionStatusId = 2; }
                        else if (c == 2)
                        { q.QuestionStatusId = 3; }
                        else
                        { c = '5'; }

                    }
                }
            }
        }
        public void ShowGame()
        {
            Console.WriteLine("Not implemented yet! Press any key to continue...");
            Console.ReadKey(true);
        }
        public void ShowProfile()
        {
            CleareAndTtile("PROFILE");
            TriviaDbContext db = new TriviaDbContext();
            char c = ' ';

            while (c != 'b' && c != 'B')
            {
                if (currentUser == null)
                {
                    Console.WriteLine("Log in first!");
                    Console.ReadKey(true);
                    return;
                }
                Console.WriteLine($"Name: {this.currentUser.UserName}");
                Console.WriteLine($"Mail: {this.currentUser.UserMail}");
                Console.WriteLine($"Passworde: {this.currentUser.Password}");
                Console.WriteLine($"Player Id: {this.currentUser.UserId}");
                Console.WriteLine($"Score: {this.currentUser.Score}");

                Console.WriteLine("Update (M)ail, (N)ame, (P)assword, (B)ack... press Enter every time your update somthing");
                c = Console.ReadKey(true).KeyChar;
                bool updated = false;
                if (c == 'm' || c == 'M')
                {
                    Console.WriteLine("Enter youre new Email");
                    string? mail = Console.ReadLine();
                    while (!IsEmailValid(mail))
                    {
                        Console.Write("Bad Email Format! Please try again:");
                        mail = Console.ReadLine();
                    }
                    this.currentUser.UserMail = mail;
                    updated = true;
                }
                if (c == 'n' || c == 'N')
                {
                    Console.WriteLine("Enter your new name");
                    string? name = Console.ReadLine();
                    while (!IsNameValid(name))
                    {
                        Console.Write("name must be at least 3 characters! Please try again: ");
                        name = Console.ReadLine();
                    }
                    this.currentUser.UserName = name;
                    updated = true;
                }
                if (c == 'p' || c == 'P')
                {
                    Console.Write("Please Type your password: ");
                    string? password = Console.ReadLine();
                    while (!IsPasswordValid(password))
                    {
                        Console.Write("password must be at least 4 characters! Please try again: ");
                        password = Console.ReadLine();
                    }
                    this.currentUser.UserName = password;
                    updated = true;
                }
                if (updated == true)
                {
                    try
                    {
                        db.UpdatePlayer(this.currentUser);
                        Console.WriteLine("your changes succeeded");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed changes!");
                    }
                }
                Console.ReadKey(true);

            }
        }

        //Private helper methodfs down here...
        private void CleareAndTtile(string title)
                {
                    Console.Clear();
                    Console.WriteLine($"\t\t\t\t\t{title}");
                    Console.WriteLine();
                }

                private bool IsEmailValid(string emailAddress)
                {
                    var pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

                    var regex = new Regex(pattern);
                    return regex.IsMatch(emailAddress);
                }

                private bool IsPasswordValid(string password)
                {
                    return password != null && password.Length >= 3;
                }

                private bool IsNameValid(string name)
                {
                    return name != null && name.Length >= 3;
                }      
    }
}
