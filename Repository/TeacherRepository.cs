using System;
using System.Configuration;
using System.Text.Json;
using OPP.Entity;
using University.Interface;

namespace University.Repository;

public class TeacherRepository
{
    FacultyRepository facultyRepository = new();
    public List<Teacher> Teachers { get; set; } = [];

    public void ImportTeacher()
    {


        string url = ConfigurationManager.AppSettings["PathImportTeachers"];
        try
        {
            string sTeacher = File.ReadAllText(url);
            Teachers = JsonSerializer.Deserialize<List<Teacher>>(sTeacher);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ILog.AddNewLog(ex.Message, "ImportTeacher").PrintLog());
        }
       
    }

}
