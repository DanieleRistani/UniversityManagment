using System;
using System.ComponentModel.DataAnnotations;
using University.Entity;

namespace OPP.Entity;

public class Student : Person
{
     [Key]
    public string Matricola { get; set; }
    public string Department { get; set; }
    public int AnnoDiIscrizione { get; set; }
    public List<Exam> Exams { get; set; }=new();

   
    
    public Student(string name, string sureName, int age, string gender, string matricola,string department, int annoDiIscrizione)
        : base(name,sureName, age, gender)
    {
        Department = department;
        Matricola = matricola;
        AnnoDiIscrizione = annoDiIscrizione;
    }

    public override string ToString()
    {
        string table=String.Empty;

        table += $"Studente\n";
        table += "--------------------------------------------------------\n";
        table += $"{base.ToString()}";
        table += $"Matricola: {Matricola}\n";
        table += $"Corso: {Department}\n";
        table += $"Anno di iscrizione: {AnnoDiIscrizione}\n";

        table += "--------------------------------------------------------\n";
        table += "Esami:\n";
        table += "--------------------------------------------------------\n";

        foreach (var exam in Exams)
        {
            table += $"- {exam.ToString()}\n";
        }

        table += "--------------------------------------------------------\n";

        return table;
    }

}
