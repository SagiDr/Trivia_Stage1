using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Trivia_Stage1.Models;

public partial class QuestionsDb
{
    public QuestionsDb AddQuestion(UserDb user, string question, string CorrectAns, string WrongAns1, string WrongAns2, string WrongAns3, int SubId, TriviaDbContext context)
    {
        QuestionsDb Q = new QuestionsDb();
        {
            Q.Text = question;
            Q.CorrectAns = CorrectAns;
            Q.WrongAns1 = WrongAns1;
            Q.WrongAns2 = WrongAns2;
            Q.WrongAns3 = WrongAns3;
            Q.SubjectId = SubId;
            Q.QuestionStatusId = 1;
            Q.UserId = user.UserId;
        }
        context.QuestionsDbs.Add(Q);
        context.SaveChanges();
        return Q;
    }
    public void PrintQuestion()
    {
        Console.WriteLine($"The questions's Subject {this.Subject}\n The question's text {this.Text}, \n " +
        $"The question's correct answer{this.CorrectAns} \n The question's Wrong anawer#1 {this.WrongAns1}\n " +
        $"The question's Wrong anawer#2 {this.WrongAns1}\n The question's Wrong anawer#3 {this.WrongAns3} ");
    }
    public int  gamePrintQuestion()
    {
        int count = 0;
        int importantIndex = -1;
        Console.WriteLine($"The Subject is {this.Subject}\nThe question is {this.Text}");
        string[] stringsArray = { this.CorrectAns, this.WrongAns1, this.WrongAns2, this.WrongAns3 };

        // Creating a random number generator
        Random random = new Random();

        // Create a list to store indices
        var indices = new List<int>();

        // Generate indices for each string
        for (int i = 0; i < stringsArray.Length; i++)
        {
            indices.Add(i);
            if (stringsArray[i] == this.CorrectAns)
            {
                importantIndex = i; // Save the index of the important string
            }
        }

        // Shuffle the indices 
        for (int i = indices.Count - 1; i > 0; i--)
        {
            count++;
            Console.WriteLine($"Question number:{count}");
            int j = random.Next(0, i + 1);
            int temp = indices[i];
            indices[i] = indices[j];
            indices[j] = temp;
            if (indices[i] == 0)
            {
                importantIndex = indices[i];
            }
        }

        // Print the strings in random order
        Console.WriteLine("Randomly selected strings:");

        foreach (int index in indices)
        {
            Console.WriteLine($"{index} {stringsArray[index]}");
        }
        return importantIndex;
    }
}


