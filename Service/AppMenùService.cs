using System;
using University.Enum;
using University.Interface;
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

    public void FacultiesList()
    {

        bool exitLoop = false;
        while (!exitLoop)
        {
            List<String> options = [];
            facultyService.facultyRepository.Faculties.ForEach(f =>
            {
                options.Add(f.Name);
            });
            String exit = "Esci";
            options.Add(exit);


            int selectedIndex = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleziona una facolta':\n----------------------------------------------");
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : options.Count - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < options.Count - 1) ? selectedIndex + 1 : 0;
                }

            } while (key.Key != ConsoleKey.Enter);

            Console.Clear();


            options.ForEach(o =>
            {

                if (o.Equals(exit, StringComparison.OrdinalIgnoreCase) && options.IndexOf(o) == selectedIndex)
                {
                    exitLoop = true;
                    return;
                }
                else if (options.IndexOf(o) == selectedIndex)
                {
                    Console.Clear();
                    Console.WriteLine(facultyService.facultyRepository.Faculties.Find(f => f.Name == options[selectedIndex]).ToString());

                    return;
                }
            });

            if (exitLoop == false)
            {
                Console.WriteLine("Premere un tasto per tornare alla lista delle facoltà");
                _ = Console.ReadKey();
            }

        }
        exitLoop = true;
    }

    public void StudentsManagment()
    {
        bool exitLoop = false;
        while (!exitLoop)
        {
            List<String> options = ["Lista studenti","Cerca Studente","Aggiungi studente", "Modifica studente", "Cancella studente", "Esci"];

            int selectedIndex = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("Menù Gestione studenti:\n----------------------------------------------");
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : options.Count - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < options.Count - 1) ? selectedIndex + 1 : 0;
                }

            } while (key.Key != ConsoleKey.Enter);

            Console.Clear();


            switch (selectedIndex)
            {
                case (int)StudentsManagmentEnum.GetAllStudents:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    studentService.StudentsList();
                    break;
                case (int)StudentsManagmentEnum.SearchStudent:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    studentService.SearchStudent();
                break;
                case (int)StudentsManagmentEnum.AddStudent:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    studentService.AddStudent(studentService.studentRepository.Students);
                    break;
                case (int)StudentsManagmentEnum.UpdateStudent:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    studentService.UpdateStudent(studentService.studentRepository.Students);
                    break;
                case (int)StudentsManagmentEnum.DeleteStudent:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    studentService.DeleteStudent(studentService.studentRepository);
                    break;
                case (int)StudentsManagmentEnum.Exit:

                    exitLoop = true;
                    break;
            }


            if (exitLoop == false)
            {
                Console.WriteLine("Premere un tasto per tornare al menù gestione studenti");
                _ = Console.ReadKey();
            }

        }
        exitLoop = true;
    }

     public void TeachersManagment()
    {
        bool exitLoop = false;
        while (!exitLoop)
        {
            List<String> options = ["Lista Professiri","Cerca Professore","Aggiungi Professore", "Modifica Professore", "Cancella Professore", "Esci"];

            int selectedIndex = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("Menù Gestione Professori:\n----------------------------------------------");
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : options.Count - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < options.Count - 1) ? selectedIndex + 1 : 0;
                }

            } while (key.Key != ConsoleKey.Enter);

            Console.Clear();


            switch (selectedIndex)
            {
                case (int)TeachersManagmentEnum.GetAllTeachers:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    teacherService.TeachersList();
                    break;
                case (int)TeachersManagmentEnum.SearchTeacher:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                     teacherService.SearchTeacher();
                break;
                case (int)TeachersManagmentEnum.AddTeacher:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    teacherService.AddTeacher(teacherService.teacherRepository.Teachers,facultyService.facultyRepository.Faculties);
                    break;
                case (int)TeachersManagmentEnum.UpdateTeacher:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    teacherService.UpdateTeacher(teacherService.teacherRepository.Teachers,facultyService.facultyRepository.Faculties);
                    break;
                case (int)TeachersManagmentEnum.DeleteTeacher:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    teacherService.DeleteTeacher(teacherService.teacherRepository);
                    break;
                case (int)TeachersManagmentEnum.Exit:

                    exitLoop = true;
                    break;
            }


            if (exitLoop == false)
            {
                Console.WriteLine("Premere un tasto per tornare al menù gestione Professori");
                _ = Console.ReadKey();
            }

        }
        exitLoop = true;
    }

     public void ExamsManagment()
    {
        bool exitLoop = false;
        while (!exitLoop)
        {
            List<String> options = ["Lista Esami","Cerca Esame","Aggiungi Esame", "Modifica Esame", "Cancella esame", "Esci"];

            int selectedIndex = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("Menù Gestione Esami:\n----------------------------------------------");
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : options.Count - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < options.Count - 1) ? selectedIndex + 1 : 0;
                }

            } while (key.Key != ConsoleKey.Enter);

            Console.Clear();


            switch (selectedIndex)
            {
                case (int)ExamsManagmentEnum.GetAllExams:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    examService.ExamsList();
                    break;
                case (int)ExamsManagmentEnum.SearchExam:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                     examService.SearchExam();
                break;
                case (int)ExamsManagmentEnum.AddExam:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                     examService.AddExam(examService.examRepository.Exams,studentService.studentRepository.Students,teacherService.teacherRepository.Teachers,facultyService.facultyRepository.Faculties);
                    break;
                case (int)ExamsManagmentEnum.UpdateExam:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    
                    break;
                case (int)ExamsManagmentEnum.DeleteExam:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    examService.DeleteExam(examService.examRepository,studentService.studentRepository.Students);
                    break;
                case (int)ExamsManagmentEnum.Exit:

                    exitLoop = true;
                    break;
            }


            if (exitLoop == false)
            {
                Console.WriteLine("Premere un tasto per tornare al menù gestione Esami");
                _ = Console.ReadKey();
            }

        }
        exitLoop = true;
    }

}
