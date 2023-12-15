﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Trivia_Stage1.Models;
public delegate bool Operation(int x, int y);
public partial class QuestionsDb
{
    public QuestionsDb AddQuestion(UserDb user, TriviaDbContext context)
    {
        string text, corAns, wAns1, wAns2, wAns3;
        int subId = 6;


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
        
        QuestionsDb Q = new QuestionsDb();
        {
            Q.Text = text;
            Q.CorrectAns = CorrectAns;
            Q.WrongAns1 = WrongAns1;
            Q.WrongAns2 = WrongAns2;
            Q.WrongAns3 = WrongAns3;
            Q.SubjectId = subId;
            Q.QuestionStatusId = 1;
            Q.UserId = user.UserId;
        }
        context.QuestionsDbs.Add(Q);
        context.SaveChanges();
        return Q;
    }
    public void PrintQuestion()
    {
        Console.WriteLine($"The questions's Subject: {this.Subject.Subject} \nThe question's text: {this.Text}, \n" +
        $"The question's correct answer is: {this.CorrectAns} \nThe question's Wrong anawer#1: {this.WrongAns1} \n" +
        $"The question's Wrong anawer#2: {this.WrongAns1} \nThe question's Wrong anawer#3: {this.WrongAns3} ");
    }
    public int gamePrintQuestion(int counter, int totalCount)
    {
        int importantIndex = -1;
        Console.WriteLine("Question number: " + counter + "/" + totalCount);
        Console.WriteLine($"The Subject is {this.Subject.Subject}\nThe question is {this.Text}");
        string[] stringsArray = { this.CorrectAns, this.WrongAns1, this.WrongAns2, this.WrongAns3 };
        stringsArray = stringsArray.OrderBy(s => Guid.NewGuid()).ToArray();
        for (int i = 0; i < stringsArray.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {stringsArray[i]}");
            if (stringsArray[i].Equals(CorrectAns))
            {
                importantIndex = i;
            }
        }
        return importantIndex + 1;
    }
    public static void PrintQusetionsArry(TriviaDbContext context)
    {
        List<QuestionsDb> Quests = context.QuestionsDbs.Include(q => q.Subject).ToList();
        foreach (QuestionsDb q in Quests)
        {
            q.PrintQuestion();
        }
    }

    public static QuestionsDb filter(TriviaDbContext context, Operation compare, int input)
    {
        List<QuestionsDb> Quests = context.QuestionsDbs.Include(q => q.Subject).ToList();
        foreach (QuestionsDb q in Quests)
        {
            if (compare(q.QuestionId, input))
            {
                return q;
            }
        }
        return null;
    }

    public static void PrintAllQuestions(TriviaDbContext context)
    {
        int counter = 0;
        List<QuestionsDb> Quests = context.QuestionsDbs.Include(q => q.Subject).ToList();
        foreach (QuestionsDb q in Quests)
        {
            counter++;
            Console.WriteLine("");
            Console.WriteLine("Question number: " + counter);
            Console.WriteLine("");
            q.PrintQuestion();
            int delay = 300;
            Thread.Sleep(delay);
        }
    }
}


