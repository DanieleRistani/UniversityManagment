using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using OPP.Entity;
using University.Entity;
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



        Console.Write("Nome:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string name = string.Empty;

        while (!isValidField)
        {
            name = Console.ReadLine();

            if (int.TryParse(name, out _))
            {

                ILog.AddNewLog("Valore non valido", "SearchStudent");
                Console.WriteLine("Valore numerico non valido");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else if (name == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "SearchStudent");

                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                isValidField = true;
            }
        }
        isValidField = false;



        Console.Write("Cognome:");
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
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else if (sureName == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "SearchStudent");
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
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
    public void AddStudent(List<Student> students)
    {

        Console.WriteLine("Inserimento nuovo studente");

        bool isValidField = false;
        int xCursor = 0;
        int yCursor = 0;



        Console.Write("Nome:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string name = string.Empty;

        while (!isValidField)
        {
            name = Console.ReadLine();

            if (int.TryParse(name, out _))
            {

                ILog.AddNewLog("Valore non valido", "AddStudent");
                Console.WriteLine("Valore numerico non valido");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else if (name == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "AddStudent");
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                isValidField = true;
            }
        }
        isValidField = false;





        Console.Write("Cognome:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string sureName = string.Empty;

        while (!isValidField)
        {
            sureName = Console.ReadLine();

            if (int.TryParse(sureName, out _))
            {

                ILog.AddNewLog("Valore non valido", "AddStudent");
                Console.WriteLine("Valore numerico non valido");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else if (sureName == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "AddStudent");
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                isValidField = true;
            }
        }
        isValidField = false;






        Console.Write("Età:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string age;
        int ageInt=0;

        while (!isValidField)
        {
            age = Console.ReadLine();

            if (int.TryParse(age, out ageInt) && ageInt >= 18)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                ageInt = int.Parse(age);
                isValidField = true;

            }
            else if (sureName == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "AddStudent");
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);
            }
            else if (!int.TryParse(age, out _))
            {
                ILog.AddNewLog("Valore non valido", "AddStudent");
                Console.WriteLine("Valore stringa non valido");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);
            }
            else
            {

                ILog.AddNewLog("Tentativo di inserimento minore", "AddStudent");
                Console.WriteLine("Età non valida");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);

            }
        }
        isValidField = false;






        Console.WriteLine("Gender:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string gender = string.Empty;


        List<String> optionsGender = ["Maschio","Femmina"];
        int selectedIndexGender = 0;
        ConsoleKeyInfo keyGender;

        do
        {
            Console.Clear();
            for (int i = 0; i < optionsGender.Count; i++)
            {
                if (i == selectedIndexGender)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(optionsGender[i]);
                Console.ResetColor();
            }

            keyGender = Console.ReadKey(true);

            if (keyGender.Key == ConsoleKey.UpArrow)
            {
                selectedIndexGender = (selectedIndexGender > 0) ? selectedIndexGender - 1 : optionsGender.Count - 1;
            }
            else if (keyGender.Key == ConsoleKey.DownArrow)
            {
                selectedIndexGender = (selectedIndexGender < optionsGender.Count - 1) ? selectedIndexGender + 1 : 0;
            }

        } while (keyGender.Key != ConsoleKey.Enter);

       


        switch (selectedIndexGender)
        {
            case 0:
                gender = optionsGender[selectedIndexGender];
                break;
            case 1:
                gender = optionsGender[selectedIndexGender];

                break;
        }
        isValidField = false;





        Console.WriteLine("Matricola:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string mat = string.Empty;
        bool matUnique = true;

        while (!isValidField)
        {
            mat = Console.ReadLine();

            

            if (mat.Length == 4 && char.IsAsciiLetter(mat.ToCharArray()[0]))
            {

                students.ForEach(s =>{   

                 if(s.Matricola==mat){
                 ILog.AddNewLog("Matricola già esistente", "AddStudent");
                 Console.WriteLine("Valore non accettato,matricola esistente");
                 Console.SetCursorPosition(xCursor, yCursor);
                 Console.Write(new string(' ', Console.WindowWidth - xCursor));
                 Console.SetCursorPosition(xCursor, yCursor);
                 matUnique = false;
                 return;
                 }

                });


                if(matUnique){
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                isValidField = true;
                }

            }
            else if (mat == string.Empty)
            {
                ILog.AddNewLog("Valore non valido ,valore nullo", "AddStudent");
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);
                matUnique = true;
            }
            else if (mat.Length != 4)
            {
                ILog.AddNewLog("La matricola deve avere  4 caratteri", "AddStudent");
                Console.WriteLine("Matricola non di 4 caratteri");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);
                matUnique = true;
            }
            else if (!int.TryParse(gender, out _))
            {
                ILog.AddNewLog("Valore numerico non valido lettera iniziale non presente", "AddStudent");
                Console.WriteLine("Lettera iniziale non presente");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);
                matUnique = true;
            }
        }
        isValidField = false;





        Console.WriteLine("Facoltà:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string department = string.Empty;


        List<String> options = ["Facoltà di Giurisprudenza","Facoltà di Economia","Facoltà di Ingegneria","Facoltà di Medicina","Facoltà di Lettere e Filosofia","Facoltà di Scienze","Facoltà di Architettura","Facoltà di Scienze Politiche","Facoltà di Psicologia"];
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

       


        switch (selectedIndex)
        {
            case 0:
                department = options[selectedIndex];
                break;
            case 1:
                department = options[selectedIndex];

                break;
            case 2:
                department = options[selectedIndex];

                break;
            case 3:
                department = options[selectedIndex];


                break;
            case 4:
                department = options[selectedIndex];


                break;
            case 5:
                department = options[selectedIndex];


                break;
            case 6:
                department = options[selectedIndex];


                break;
            case 7:
                department = options[selectedIndex];


                break;
            case 8:
                department = options[selectedIndex];


                break;

        }
        isValidField = false;

        Console.WriteLine("Anno di iscrizione:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string date= string.Empty;
        int dateInt=0;       

        while (!isValidField)
        {
            date = Console.ReadLine();

           
            if (date.Length==4 && int.TryParse(date, out _))
            {

                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                dateInt = int.Parse(date);
                isValidField = true;

            }else if (date == string.Empty)
            {
                ILog.AddNewLog("Valore non valido, valore nullo", "AddStudent");
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);

            }else{
                ILog.AddNewLog("Data non valida", "AddStudent");
                Console.WriteLine("Data non valida");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor);
            }
        }
        isValidField = false;

        studentRepository.Students.Add(new Student(name, sureName, ageInt ,gender,mat,department,dateInt));
       

    }









}

