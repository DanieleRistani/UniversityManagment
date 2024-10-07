using System;
using System.Configuration;
using System.Text.Json;
using University.Entity;
using University.Interface;

namespace University.Repository;

public class ExamRepository
{
  public List<Exam> Exams { get; set; } = [];

  public void ImportExams()
  {
    string url = ConfigurationManager.AppSettings["PathImportExams"];
    try
    {
      string sExams = File.ReadAllText(url);
      Exams = JsonSerializer.Deserialize<List<Exam>>(sExams);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ILog.AddNewLog(ex.Message, "ImportExams").PrintLog());
    }
  }
}
