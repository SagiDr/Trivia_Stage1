using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

        public partial class QuestionsDb
        {
            public void PrintQuestion()
            {
        Console.WriteLine($" The questions's Subject {this.Subject}\\ The question's text {this.Text}, \\ " +
            $"The question's correct answer{this.CorrectAns} \\ The question's Wrong anawer#1 {this.WrongAns1}\\ " +
            $"The question's Wrong anawer#2 {this.WrongAns1}\\ The question's Wrong anawer#3 {this.WrongAns3} ");
    }      
        }

