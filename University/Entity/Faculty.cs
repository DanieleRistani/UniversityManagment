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

    
}

    

