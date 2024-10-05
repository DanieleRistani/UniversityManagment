using System;

namespace OPP;

public abstract class Person
{
    public string Name { get; set; }
    public string SureName { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public Person(string name, string sureName, int age, string gender)
    {
        Name = name;
        SureName = sureName;
        Age = age;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"Nome: {Name}|Cognome: {SureName}|Età: {Age}anni|Genere: {Gender}";
    }
}
