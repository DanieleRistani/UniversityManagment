using System;
using System.Diagnostics.Eventing.Reader;
using OPP.Entity;
using University.Interface;
using University.Repository;

namespace University.Service;

public class StudentsService
{
    public StudentRepository studentRepository { get; set; } = new();


    public void StudentsList()
    {



        bool exitLoop = false;
        while (!exitLoop)
        {
            List<String> options = [];
            studentRepository.Students.ForEach(f =>
            {
                options.Add(f.Name + " " + f.SureName);
            });
            String exit = "Esci";
            options.Add(exit);

            int selectedIndex = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
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
                    Console.WriteLine(studentRepository.Students.Find(f => f.Name == options[selectedIndex].Split(" ")[0] && f.SureName == options[selectedIndex].Split(" ")[1]).ToString());

                    return;
                }
            });

            if (exitLoop == false)
            {
                Console.WriteLine("Premere un tasto per tornare alla lista degli studentti");
                _ = Console.ReadKey();
            }

        }
        exitLoop = true;



    }

    public void StudentsList(List<Student> students)
    {



        bool exitLoop = false;
        while (!exitLoop)
        {
            List<String> options = [];
            students.ForEach(f =>
            {
                options.Add(f.Name + " " + f.SureName);
            });
            String exit = "Esci";
            options.Add(exit);

            int selectedIndex = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
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
                    Console.WriteLine(students.Find(f => f.Name == options[selectedIndex].Split(" ")[0] && f.SureName == options[selectedIndex].Split(" ")[1]).ToString());

                    return;
                }
            });

            if (exitLoop == false)
            {
                Console.WriteLine("Premere un tasto per tornare alla ricerca studentti");
                _ = Console.ReadKey();
            }

        }
        exitLoop = true;



    }
    public void SearchStudent()
    {

        Console.WriteLine("Inserisci nome e cognome del studente da cercare");

        bool isValidField = false;
        int xCursor = 0;
        int yCursor = 0;



        Console.WriteLine("Nome:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string name = string.Empty;

        while (!isValidField)
        {
            name = Console.ReadLine();

            if (int.TryParse(name, out _))
            {

                Console.WriteLine(ILog.AddNewLog("Valore non valido", "SearchStudent").PrintLog());
                Console.WriteLine("Valore numerico non valido");
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else if (name == string.Empty)
            {
                Console.WriteLine(ILog.AddNewLog("Valore non valido", "SearchStudent").PrintLog());

                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else
            {
                isValidField = true;
            }
        }
        isValidField = false;



        Console.WriteLine("Cognome:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string sureName = string.Empty;

        while (!isValidField)
        {
            sureName = Console.ReadLine();
            if (int.TryParse(sureName, out _))
            {

                ILog.AddNewLog("Valore non valido", "SearchStudent");
                Console.WriteLine("Valore numerico non valido");
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else if (sureName == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "SearchStudent").PrintLog();
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else
            {
                isValidField = true;
            }
        }

        try
        {
            if (studentRepository.Students.FindAll(f => f.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) && f.SureName.StartsWith(sureName, StringComparison.OrdinalIgnoreCase)).Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Studente non trovato");
            }
            else if (studentRepository.Students.FindAll(f => f.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) && f.SureName.StartsWith(sureName, StringComparison.OrdinalIgnoreCase)).Count == 1)
            {
                Console.Clear();
                Console.WriteLine(studentRepository.Students.FindAll(f => f.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) && f.SureName.StartsWith(sureName, StringComparison.OrdinalIgnoreCase))[0].ToString());
            }
            else
            {
                Console.Clear();
                StudentsList(studentRepository.Students.FindAll(f => f.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) && f.SureName.StartsWith(sureName, StringComparison.OrdinalIgnoreCase)));
            }

        }
        catch (Exception ex)
        {


            Console.WriteLine(ILog.AddNewLog(ex.Message, "SearchStudent").PrintLog());


        }



    }
    public void AddStudent(Student student)
    {
        studentRepository.Students.Add(student);
    }
}
