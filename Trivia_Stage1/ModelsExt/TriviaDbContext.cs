﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using Trivia_Stage1.UI;

namespace Trivia_Stage1.Models;

public partial class TriviaDbContext : DbContext
{

    //פעולת עזר שמקבלת שם אימייל סיסמא ומזירה שחקן חדש שנוסף לבסיס נתונים
    public UserDb SignUp(string username, string password, string usermail)
    {
        UserDb userDb = new UserDb()
        {
            UserName = username,
            Password = password,
            UserMail = usermail,
            UserRankId = 2,
            Score = 0

        };

        this.Entry(userDb).State = EntityState.Added;
        SaveChanges();

        return userDb;
    }

    //פעולת עזר שמקבלת  אימייל סיסמא ובודקת האם הוא קיים בבסיס  הנתונים
    public UserDb Login(string password, string usermail)
    {
        foreach (UserDb user in UserDbs)
        {
            if (user.Password == password && user.UserMail == usermail)
            {
                return user;
            }
        }
        return null;
    }

    //פעולת עזר שמקבלת שחקן ומעדכנת את הנתונים שלו בבסיס הנתונים
    public void UpdatePlayer(UserDb p)
    {
        Entry(p).State = EntityState.Modified;
        SaveChanges();
    }
    //פעולת עזר שמקבל עצם מטיפוס שאלה ומוסיפה אותה לבסיס הנתונים
    public void EnterQustion(QuestionsDb Question)
    {
        Entry(Question).State = EntityState.Added;
        SaveChanges();
    }
    
    // פעולה שמטרתה לבדוק האם ביכולת וברצון המשתמש להוסיף שאלה למאגר השאלות
    public bool canAddQuestion(UserDb U)
    {
        bool b = true;
        while (b)
        {
            string wants;
            if (U.UserRankId == 1 || U.Score != 100)
            {
                break;
            }
            Console.WriteLine("Do you want to add another question? (Yes/No)");
            wants = Console.ReadLine();
            if (wants == "Yes" || wants == "yes" || wants == "y")
            {
                return true;
            }
            else if (wants == "No" || wants == "no" || wants == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please answer a valid answer");
            }
        }
        return false;
    }
}
