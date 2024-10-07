using System;
using System.Configuration;
using System.Text.Json;
using OPP.Entity;
using University.Interface;

namespace University.Repository; 

public class StudentRepository
{
    FacultyRepository facultyRepository = new();
    public List<Student> Students { get; set; } = [];

    public void ImportStudents()
    {


        string url = ConfigurationManager.AppSettings["PathImportStudents"];
        try
        {
            string sStudent = File.ReadAllText(url);
            Students = JsonSerializer.Deserialize<List<Student>>(sStudent);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ILog.AddNewLog(ex.Message, "ImportStudents").PrintLog());
        }

    }


}
