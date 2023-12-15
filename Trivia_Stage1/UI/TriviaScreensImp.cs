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
        private DbContext db = new TriviaDbContext();
        private UserDb currentUser = null;
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
                    Console.WriteLine("Write a password!");
                    mail = Console.ReadLine();
                }
                Console.WriteLine("Enter password");
                string pass = Console.ReadLine();
                while (pass == null)
                {
                    Console.WriteLine("Write a password!");
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
            Console.WriteLine("Do you want to manage the questions? If not, press (B) to go back, or anything else to continue");
            char c = Console.ReadKey(true).KeyChar;
            bool gate = true;
            while (c != 'B' && c != 'b' && this.currentUser.UserRankId == 1 && gate)
            {
                foreach (QuestionsDb q in context.QuestionsDbs)
                {
                    Console.WriteLine("Question Number : " + q.QuestionId);
                    Console.WriteLine(q.Subject);
                    Console.WriteLine(q.Text);
                }


                while (true)
                {
                    Console.WriteLine("Would you like to Edit a question? Press (s) to skip " +
                    "or anything else to continue");
                    char sg = Console.ReadKey(true).KeyChar;
                    if ((sg == 'S') || (sg == 's'))
                    {
                        break;
                    }
                    Console.WriteLine("Insert the question number of the question you would like to change");
                    int input = int.Parse(Console.ReadLine());
                    QuestionsDb quest = null;
                    foreach (QuestionsDb q in context.QuestionsDbs)
                    {
                        if (q.QuestionId == input)
                        {
                            quest = q;
                            break;
                        }
                    }
                    if (quest != null)
                        quest?.PrintQuestion();
                    else
                    {
                        Console.WriteLine("No Question Found");
                    }
                    Console.WriteLine("What would you like to change? 1-[SubjectID],2-[Text],3-[CorrectAns]," +
                        "4-[WrongAns1],5-[WrongAns2],6-[WrongAns3]");
                    int num = int.Parse(Console.ReadLine());
                    Console.WriteLine("What would you like to enter");
                    string str = Console.ReadLine();
                    bool b = true;
                    while (num != null && str != null)
                    {
                        if (num == 1)
                        {
                            if (str == "Sport")
                            {
                                quest.SubjectId = 1;

                            }
                            else if (str == "Politics")
                            {
                                quest.SubjectId = 2;

                            }
                            else if (str == "History")
                            {

                                quest.SubjectId = 3;
                            }
                            else if (str == "Science")
                            {

                                quest.SubjectId = 4;
                            }
                            else if (str == "Ramon Highschool")
                            {
                                quest.SubjectId = 5;

                            }
                            else
                            {
                                Console.WriteLine("Invalid Subject");
                                b = false;
                                break;
                            }
                        }
                        else if (num == 2)
                            quest.Text = str;

                        else if (num == 3)
                            quest.CorrectAns = str;

                        else if (num == 4)
                            quest.WrongAns1 = str;
                        else if (num == 5)
                            quest.WrongAns2 = str;
                        else if (num == 6)
                            quest.WrongAns3 = str;

                        foreach (QuestionsDb q in context.QuestionsDbs)
                        {
                            if (q.QuestionId == quest.QuestionId)
                            {
                                quest = q;
                                break;
                            }
                        }
                    }
                }
                CleareAndTtile("");

                while (true)
                {
                    Console.WriteLine("Would you like to add a question? Press (s) to skip " +
                    "or anything else to continue");
                    char sg = Console.ReadKey(true).KeyChar;
                    if ((sg == 'S') || (sg == 's'))
                    {
                        gate = false;
                        break;
                    }
                    string text, corAns, wAns1, wAns2, wAns3;
                    int subId;


                    Console.WriteLine("Enter a question's subject");
                    string str = Console.ReadLine();
                    if (str == "Sport")
                    {
                        subId = 1;
                    }
                    else if (str == "Politics")
                    {
                        subId = 2;
                    }
                    else if (str == "History")
                    {

                        subId = 3;
                    }
                    else if (str == "Science")
                    {

                        subId = 4;
                    }
                    else if (str == "Ramon Highschool")
                    {
                        subId = 5;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Subject");
                        subId = 6;
                    }



                    Console.WriteLine("Enter the question itself");
                    text = Console.ReadLine();

                    Console.WriteLine("Enter the correct answer");
                    corAns = Console.ReadLine();

                    Console.WriteLine("Enter the first wrong answer");
                    wAns1 = Console.ReadLine();

                    Console.WriteLine("Enter the second wrong answer");
                    wAns2 = Console.ReadLine();

                    Console.WriteLine("Enter the third wrong answer");
                    wAns3 = Console.ReadLine();

                    QuestionsDb q = new QuestionsDb();
                    q.AddQuestion(currentUser, text, corAns, wAns1, wAns2, wAns3, subId, context);

                }
            }
        }
        public void ShowPendingQuestions()
        {
                if(this.currentUser.UserRankId == 1 || this.currentUser.UserRankId == 2)
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
            TriviaDbContext db = new TriviaDbContext();
            foreach (QuestionsDb q in context.QuestionsDbs)
            {
                q.gamePrintQuestion();
                Console.WriteLine("Enter The num of your Ans: ");
                int User_ans = int.Parse(Console.ReadLine());
                if (User_ans == 0)
                {
                    Console.WriteLine("You are correct!");
                    currentUser.Score += 10;
                }
                else
                {
                    Console.WriteLine("You are incorrect!");
                    currentUser.Score -= 5;
                }
            }

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
