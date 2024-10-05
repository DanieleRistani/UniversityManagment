using System;
using System.ComponentModel.DataAnnotations;
using OPP.Entity;

namespace University.Entity;

public class Faculty
{
    [Key]
    public string Name { get; set; }
    public string Location { get; set; }
    public List<Matter> Matters { get; set; }
    public List<Student> Students { get; set;}= [];
    public List<Teacher> Teachers { get; set;}= [];

    public Faculty(string name, string location)
    {
        Name = name;
        Location = location;
        Matters = new List<Matter>();
        Students = new List<Student>();
        Teachers = new List<Teacher>();
    }

    public override string ToString()
    {
        string table=String.Empty; 
        
        table += $"{Name} \n";
        table += "--------------------------------------------\n";
        table += $"Location: {Location}\n";
        table += "--------------------------------------------\n";
        table += "Materie:\n";
        table += "--------------------------------------------\n";
        foreach (var matter in Matters)
        {
            table += $"- {matter.Name}\n";
        }

        table += "--------------------------------------------\n";
        table += "Studenti:\n";
        table += "--------------------------------------------\n";

        foreach (var student in Students)
        {
            table += $"- {student.Name} {student.SureName}\n";
        }

        table += "--------------------------------------------\n";
        table += "Docenti:\n";
        table += "--------------------------------------------\n";

        foreach (var teacher in Teachers)
        {
            table += $"- {teacher.Name} {teacher.SureName}\n";
        }
        table += "--------------------------------------------\n";
        return table;
    }
            
        

    
}

    

