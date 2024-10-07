using System;
using System.Configuration;
using System.Text.Json;
using University.Entity;
using University.Interface;

namespace University;

public class FacultyRepository
{
    public List<Faculty> Faculties {get;set;}=[];

    public void ImportFaculty(){

            
            string url = ConfigurationManager.AppSettings["PathImportFaculties"];
            try
            {
                string sFaculty=File.ReadAllText(url);
                Faculties = JsonSerializer.Deserialize<List<Faculty>>(sFaculty);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ILog.AddNewLog(ex.Message, "ImportFaculty").PrintLog());
            }
           
    }
    
    public void ExportFaculty(){
        string url = ConfigurationManager.AppSettings["PathExportFaculties"];
        string sFaculties = JsonSerializer.Serialize(Faculties);
        File.WriteAllText(url,sFaculties);
    }
}
