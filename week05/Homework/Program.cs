using System;

using Homework;


var a = new Assignment("Samuel Bennett", "Multiplication");
Console.WriteLine(a.GetSummary());

Console.WriteLine();


var m = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
Console.WriteLine(m.GetSummary());
Console.WriteLine(m.GetHomeworkList());
Console.WriteLine();


var w = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
Console.WriteLine(w.GetSummary());
Console.WriteLine(w.GetWritingInformation());

