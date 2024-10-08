using System;
using System.ComponentModel.DataAnnotations;
using University.Entity;
namespace OPP.Entity;

public class Teacher : Person
{
    [Key]
    public string TeacherCode { get; set; }
    public Matter TeachedMatter { get; set; }
    public string Department { get; set; }
    public TeacherRoleEnum Role{ get; set; }

    public Teacher(string name, string sureName, int age, string gender,string department,string teacherCode,Matter teachedMatter,TeacherRoleEnum role)
        : base(name,sureName, age, gender)
    {
        TeacherCode = teacherCode;
        TeachedMatter = teachedMatter;
        Department = department;
        Role = role;
        
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nMateria: {TeachedMatter.MatterCode} - {TeachedMatter.Name}\nDipartimento: {Department}\nRole: {Role}";
    }

}

