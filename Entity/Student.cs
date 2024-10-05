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
        return $"{base.ToString()}|Matricola: {Matricola}| Corso: {Department}| Anno di iscrizione: {AnnoDiIscrizione}";
    }
}
