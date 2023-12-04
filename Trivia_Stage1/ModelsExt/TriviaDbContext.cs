using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

public partial class TriviaDbContext : DbContext
{
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

    public UserDb Login(string username, string password, string usermail)
    {
        foreach(UserDb user in UserDbs)
        {
            if(user.UserName == username && user.Password == password && user.UserMail == usermail)
            {
                return user;
            }
        }
        return null;
    }
}
