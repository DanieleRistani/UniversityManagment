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
                Console.WriteLine("Seleziona un studente:\n----------------------------------------------");
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
                Console.WriteLine("Seleziona un studente:\n----------------------------------------------");
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

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore numerico non valido");
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else if (name == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "SearchStudent");


                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore nullo");
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

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore numerico non valido");
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else if (sureName == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "SearchStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore nullo");
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

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore numerico non valido");
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else if (name == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "AddStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore nullo");
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

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore numerico non valido");
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else if (sureName == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "AddStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore nullo");
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
        int ageInt = 0;

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
            else if (age == string.Empty)
            {
                ILog.AddNewLog("Valore non valido", "AddStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);
            }
            else if (!int.TryParse(age, out _))
            {
                ILog.AddNewLog("Valore non valido", "AddStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore stringa non valido");
                Console.SetCursorPosition(xCursor, yCursor);
            }
            else
            {

                ILog.AddNewLog("Tentativo di inserimento minore", "AddStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Età non valida");
                Console.SetCursorPosition(xCursor, yCursor);

            }
        }
        isValidField = false;






        
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string gender = string.Empty;


        List<String> optionsGender = ["Maschio", "Femmina"];
        int selectedIndexGender = 0;
        ConsoleKeyInfo keyGender;

        do
        {
            Console.Clear();
            Console.WriteLine("Gender:");
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

                students.ForEach(s =>
                {

                    if (s.Matricola == mat)
                    {
                        ILog.AddNewLog("Matricola già esistente", "AddStudent");
                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', Console.WindowWidth - xCursor));
                        Console.SetCursorPosition(xCursor, yCursor + 1);
                        Console.Write(new string(' ', Console.WindowWidth - xCursor));
                        Console.SetCursorPosition(xCursor, yCursor + 1);
                        Console.WriteLine("Valore non accettato,matricola esistente");
                        Console.SetCursorPosition(xCursor, yCursor);


                        matUnique = false;
                        return;
                    }

                });


                if (matUnique)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.CursorTop);
                    isValidField = true;
                }

            }
            else if (mat == string.Empty)
            {
                ILog.AddNewLog("Valore non valido ,valore nullo", "AddStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);

                matUnique = true;
            }
            else if (mat.Length != 4)
            {
                ILog.AddNewLog("La matricola deve avere  4 caratteri", "AddStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Matricola non di 4 caratteri");
                Console.SetCursorPosition(xCursor, yCursor);

                matUnique = true;
            }
            else if (!int.TryParse(gender, out _))
            {
                ILog.AddNewLog("Valore numerico non valido lettera iniziale non presente", "AddStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Lettera iniziale non presente");
                Console.SetCursorPosition(xCursor, yCursor);
                matUnique = true;
            }
        }
        isValidField = false;





        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string department = string.Empty;


        List<String> options = ["Facoltà di Giurisprudenza", "Facoltà di Economia", "Facoltà di Ingegneria", "Facoltà di Medicina", "Facoltà di Lettere e Filosofia", "Facoltà di Scienze", "Facoltà di Architettura", "Facoltà di Scienze Politiche", "Facoltà di Psicologia"];
        int selectedIndex = 0;
        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            Console.WriteLine("Facoltà:");

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
        string date = string.Empty;
        int dateInt = 0;

        while (!isValidField)
        {
            date = Console.ReadLine();


            if (date.Length == 4 && int.TryParse(date, out _))
            {

                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                dateInt = int.Parse(date);
                isValidField = true;

            }
            else if (date == string.Empty)
            {
                ILog.AddNewLog("Valore non valido, valore nullo", "AddStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);

            }
            else
            {
                ILog.AddNewLog("Data non valida", "AddStudent");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Data non valida");
                Console.SetCursorPosition(xCursor, yCursor);
            }
        }
        isValidField = false;

        studentRepository.Students.Add(new Student(name, sureName, ageInt, gender, mat, department, dateInt));


    }
    public void UpdateStudent(List<Student> students)
    {
        Console.WriteLine("Inserisci Matricola del studente da modificare:");

        bool isValidField = false;
        int xCursor = 0;
        int yCursor = 0;

        try
        {

            Console.WriteLine("Matricola:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string mat = string.Empty;
            bool Notfinded = true;


            while (!isValidField)
            {
                mat = Console.ReadLine();

                students.ForEach(s =>
                {
                    if (s.Matricola.Equals(mat, StringComparison.OrdinalIgnoreCase))
                    {

                        isValidField = true;
                        Notfinded = false;
                        return;

                    }

                });

                if (Notfinded)
                {
                    ILog.AddNewLog("Matricola non trovata", "UpdateStudent");
                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Matricola non trovata");
                    Console.SetCursorPosition(xCursor, yCursor);
                }

            }
            isValidField = false;
            
            Student student = students.Find(s => s.Matricola.Equals(mat, StringComparison.OrdinalIgnoreCase));
            List<string> options = ["nome", "cognome", "eta", "sesso", "corso di laurea", "data di iscrizione"];



            int selectedIndex = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleziona il campo da modificare:");
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
                case 0:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    Console.WriteLine("Nome attuale: " + student.Name);
                    Console.WriteLine("Inserisci nuovo nome:");
                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    string name = string.Empty;

                    while (!isValidField)
                    {
                        name = Console.ReadLine();

                        if (int.TryParse(name, out _))
                        {

                            ILog.AddNewLog("Valore non valido", "AddStudent");

                            Console.SetCursorPosition(xCursor, yCursor);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.WriteLine("Valore numerico non valido");
                            Console.SetCursorPosition(xCursor, yCursor);

                        }
                        else if (name == string.Empty)
                        {
                            ILog.AddNewLog("Valore non valido", "AddStudent");

                            Console.SetCursorPosition(xCursor, yCursor);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.WriteLine("Valore nullo");
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

                    student.Name = name;
                    isValidField = false;


                    break;
                case 1:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    Console.WriteLine("Cognome attuale: " + student.SureName);
                    Console.WriteLine("Inserisci nuovo cognome:");
                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    string sureName = string.Empty;

                    while (!isValidField)
                    {
                        sureName = Console.ReadLine();

                        if (int.TryParse(sureName, out _))
                        {

                            ILog.AddNewLog("Valore non valido", "AddStudent");

                            Console.SetCursorPosition(xCursor, yCursor);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.WriteLine("Valore numerico non valido");
                            Console.SetCursorPosition(xCursor, yCursor);

                        }
                        else if (sureName == string.Empty)
                        {
                            ILog.AddNewLog("Valore non valido", "AddStudent");

                            Console.SetCursorPosition(xCursor, yCursor);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.WriteLine("Valore nullo");
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

                    student.SureName = sureName;
                    isValidField = false;

                    break;
                case 2:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    Console.WriteLine("Eta attuale: " + student.Age);
                    Console.WriteLine("Inserisci nuova eta:");
                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    string age;
                    int ageInt = 0;

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
                        else if (age == string.Empty)
                        {
                            ILog.AddNewLog("Valore non valido", "AddStudent");

                            Console.SetCursorPosition(xCursor, yCursor);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.WriteLine("Valore nullo");
                            Console.SetCursorPosition(xCursor, yCursor);
                        }
                        else if (!int.TryParse(age, out _))
                        {
                            ILog.AddNewLog("Valore non valido", "AddStudent");

                            Console.SetCursorPosition(xCursor, yCursor);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.WriteLine("Valore stringa non valido");
                            Console.SetCursorPosition(xCursor, yCursor);
                        }
                        else
                        {

                            ILog.AddNewLog("Tentativo di inserimento minore", "AddStudent");

                            Console.SetCursorPosition(xCursor, yCursor);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.WriteLine("Età non valida, minore di 18");
                            Console.SetCursorPosition(xCursor, yCursor);

                        }
                    }

                    student.Age = ageInt;
                    isValidField = false;

                    break;
                case 3:
                    

                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    string gender = string.Empty;


                    List<String> optionsGender = ["Maschio", "Femmina"];
                    int selectedIndexGender = 0;
                    ConsoleKeyInfo keyGender;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        Console.WriteLine("Sesso attuale: " + student.Gender);
                        Console.WriteLine("Inserisci nuovo sesso:");
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

                    student.Gender = gender;
                    isValidField = false;


                    break;
                case 4:
                    

                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    string department = string.Empty;


                    List<String> optionsDepartment = ["Facoltà di Giurisprudenza", "Facoltà di Economia", "Facoltà di Ingegneria", "Facoltà di Medicina", "Facoltà di Lettere e Filosofia", "Facoltà di Scienze", "Facoltà di Architettura", "Facoltà di Scienze Politiche", "Facoltà di Psicologia"];
                    int selectedIndexDepartment = 0;
                    ConsoleKeyInfo keyDepartment;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        Console.WriteLine("Facoltà attuale: " + student.Department);
                        Console.WriteLine("Inserisci nuova facoltà:");
                        for (int i = 0; i < optionsDepartment.Count; i++)
                        {
                            if (i == selectedIndexDepartment)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(optionsDepartment[i]);
                            Console.ResetColor();
                        }

                        keyDepartment = Console.ReadKey(true);

                        if (keyDepartment.Key == ConsoleKey.UpArrow)
                        {
                            selectedIndexDepartment = (selectedIndexDepartment > 0) ? selectedIndexDepartment - 1 : optionsDepartment.Count - 1;
                        }
                        else if (keyDepartment.Key == ConsoleKey.DownArrow)
                        {
                            selectedIndexDepartment = (selectedIndexDepartment < optionsDepartment.Count - 1) ? selectedIndexDepartment + 1 : 0;
                        }

                    } while (keyDepartment.Key != ConsoleKey.Enter);




                    switch (selectedIndexDepartment)
                    {
                        case 0:
                            department = optionsDepartment[selectedIndexDepartment];
                            break;
                        case 1:
                            department = optionsDepartment[selectedIndexDepartment];

                            break;
                        case 2:
                            department = optionsDepartment[selectedIndexDepartment];

                            break;
                        case 3:
                            department = optionsDepartment[selectedIndexDepartment];


                            break;
                        case 4:
                            department = optionsDepartment[selectedIndexDepartment];


                            break;
                        case 5:
                            department = optionsDepartment[selectedIndexDepartment];


                            break;
                        case 6:
                            department = optionsDepartment[selectedIndexDepartment];


                            break;
                        case 7:
                            department = optionsDepartment[selectedIndexDepartment];


                            break;
                        case 8:
                            department = optionsDepartment[selectedIndexDepartment];


                            break;

                    }

                    student.Department = department;
                    isValidField = false;

                    break;
                case 5:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    Console.WriteLine("Data di iscrizione attuale: " + student.AnnoDiIscrizione);
                    Console.WriteLine("Inserisci nuova data di iscrizione:");
                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    string date = string.Empty;
                    int dateInt = 0;

                    while (!isValidField)
                    {
                        date = Console.ReadLine();


                        if (date.Length == 4 && int.TryParse(date, out _))
                        {

                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(0, Console.CursorTop);
                            dateInt = int.Parse(date);
                            isValidField = true;

                        }
                        else if (date == string.Empty)
                        {
                            ILog.AddNewLog("Valore non valido, valore nullo", "AddStudent");

                            Console.SetCursorPosition(xCursor, yCursor);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.WriteLine("Valore nullo");
                            Console.SetCursorPosition(xCursor, yCursor);

                        }
                        else
                        {
                            ILog.AddNewLog("Data non valida", "AddStudent");

                            Console.SetCursorPosition(xCursor, yCursor);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.WriteLine("Data non valida");
                            Console.SetCursorPosition(xCursor, yCursor);
                        }
                    }

                    student.AnnoDiIscrizione = dateInt;
                    isValidField = false;



                    break;

            }



        }
        catch (Exception ex)
        {
            Console.WriteLine(ILog.AddNewLog(ex.Message, "UpdateStudent").PrintLog());
        }


    }
    public void DeleteStudent(List<Student> students){
        Console.WriteLine("Inserisci Matricola del studente da eliminare:");

        bool isValidField = false;
        int xCursor = 0;
        int yCursor = 0;

        try
        {

            Console.WriteLine("Matricola:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string mat = string.Empty;
            bool Notfinded = true;


            while (!isValidField)
            {
                mat = Console.ReadLine();

                students.ForEach(s =>
                {
                    if (s.Matricola.Equals(mat, StringComparison.OrdinalIgnoreCase))
                    {

                        isValidField = true;
                        Notfinded = false;
                        return;

                    }

                });

                if (Notfinded)
                {
                    ILog.AddNewLog("Matricola non trovata", "UpdateStudent");
                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Matricola non trovata");
                    Console.SetCursorPosition(xCursor, yCursor);
                }

            }
            isValidField = false;

            List<string> optionsDeleted = ["SI","NO"];
            int selectedIndexDeleted = 0;

            ConsoleKeyInfo keyDeleted;

        do
        {
            Console.Clear();
            Console.WriteLine("Sicuro di Voler eliminare questo studente?");
            for (int i = 0; i < optionsDeleted.Count; i++)
            {
                if (i == selectedIndexDeleted)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(optionsDeleted[i]);
                Console.ResetColor();
            }

            keyDeleted = Console.ReadKey(true);

            if (keyDeleted.Key == ConsoleKey.UpArrow)
            {
                selectedIndexDeleted = (selectedIndexDeleted > 0) ? selectedIndexDeleted - 1 : optionsDeleted.Count - 1;
            }
            else if (keyDeleted.Key == ConsoleKey.DownArrow)
            {
                selectedIndexDeleted = (selectedIndexDeleted < optionsDeleted.Count - 1) ? selectedIndexDeleted + 1 : 0;
            }

        } while (keyDeleted.Key != ConsoleKey.Enter);




        switch (selectedIndexDeleted)
        {
            case 0:
                students.Remove(students.Find(s => s.Matricola.Equals(mat, StringComparison.OrdinalIgnoreCase)));
                Console.WriteLine("Lo Studente è stato eliminato");
                break;
            case 1:
                Console.WriteLine("Lo Studente non è stato eliminato");
               

                break;
        }
        isValidField = false;


        }catch(Exception ex){

            Console.WriteLine(ILog.AddNewLog(ex.Message, "DeleteStudent").PrintLog());
        }






}}

