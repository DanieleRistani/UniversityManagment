using System;
using University.Repository;
using University.Service;

namespace University.Service;

public class AppMenùService
{

    private ExamsService examService = new ExamsService();
    private FacultiesService facultyService = new FacultiesService();
    private TeacherService teacherService = new TeacherService();
    private StudentsService studentService = new StudentsService();


    public void ImportAll()
    {
        facultyService.facultyRepository.ImportFaculty();
        studentService.studentRepository.ImportStudents();
        teacherService.teacherRepository.ImportTeacher();
        examService.examRepository.ImportExams();


        facultyService.facultyRepository.Faculties.ForEach(f =>
        {
            studentService.studentRepository.Students.ForEach(s =>
            {
                if (s.Department.Equals(f.Name, StringComparison.OrdinalIgnoreCase))
                {
                    f.Students.Add(s);
                }
            });
        });



        facultyService.facultyRepository.Faculties.ForEach(f =>
        {
            teacherService.teacherRepository.Teachers.ForEach(t =>
            {
                if (t.Department.Equals(f.Name, StringComparison.OrdinalIgnoreCase))
                {
                    f.Teachers.Add(t);
                }
            });
        });


        examService.examRepository.Exams.ForEach(e =>
       {
           studentService.studentRepository.Students.ForEach(s =>
           {
               if (e.StudentMatricola.Equals(s.Matricola, StringComparison.OrdinalIgnoreCase))
               {
                   s.Exams.Add(e);

               }
           });
       });



       facultyService.facultyRepository.ExportFaculty();
    }
}
