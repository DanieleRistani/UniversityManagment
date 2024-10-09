using System;
using OPP.Entity;
using University.Entity;
using University.Interface;
using University.Repository;

namespace University.Service;

public class TeacherService
{
    public TeacherRepository teacherRepository { get; set; } = new();

    public void TeachersList()
    {

        bool exitLoop = false;
        while (!exitLoop)
        {
            List<String> options = [];

            teacherRepository.Teachers.ForEach(f =>
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
                Console.WriteLine("Seleziona un Professore:\n----------------------------------------------");
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
                    Console.WriteLine(teacherRepository.Teachers.Find(f => f.Name == options[selectedIndex].Split(" ")[0] && f.SureName == options[selectedIndex].Split(" ")[1]).ToString());

                    return;
                }
            });

            if (exitLoop == false)
            {
                Console.WriteLine("Premere un tasto per tornare alla lista Professori");
                _ = Console.ReadKey();
            }

        }
        exitLoop = true;


    }
    public void TeachersList(List<Teacher> teachers)
    {

        bool exitLoop = false;
        while (!exitLoop)
        {
            List<String> options = [];

            teachers.ForEach(f =>
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
                Console.WriteLine("Seleziona un Professore:\n----------------------------------------------");
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
                    Console.WriteLine(teachers.Find(f => f.Name == options[selectedIndex].Split(" ")[0] && f.SureName == options[selectedIndex].Split(" ")[1]).ToString());

                    return;
                }
            });

            if (exitLoop == false)
            {
                Console.WriteLine("Premere un tasto per tornare alla ricerca Professori");
                _ = Console.ReadKey();
            }

        }
        exitLoop = true;


    }
    public void SearchTeacher()
    {
        Console.WriteLine("Inserisci nome e cognome del Professore da cercare");

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

                ILog.AddNewLog("Valore non valido", "SearchTeacher");

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
                ILog.AddNewLog("Valore non valido", "SearchTeacher");


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

                ILog.AddNewLog("Valore non valido", "SearchTeacher");

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
                ILog.AddNewLog("Valore non valido", "SearchTeacher");

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
            if (teacherRepository.Teachers.FindAll(f => f.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) && f.SureName.StartsWith(sureName, StringComparison.OrdinalIgnoreCase)).Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Professore non trovato");
            }
            else if (teacherRepository.Teachers.FindAll(f => f.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) && f.SureName.StartsWith(sureName, StringComparison.OrdinalIgnoreCase)).Count == 1)
            {
                Console.Clear();
                Console.WriteLine(teacherRepository.Teachers.FindAll(f => f.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) && f.SureName.StartsWith(sureName, StringComparison.OrdinalIgnoreCase))[0].ToString());
            }
            else
            {
                Console.Clear();
                TeachersList(teacherRepository.Teachers.FindAll(f => f.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) && f.SureName.StartsWith(sureName, StringComparison.OrdinalIgnoreCase)));
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ILog.AddNewLog(ex.Message, "SearchTeacher").PrintLog());
        }




    }

    public void AddTeacher(List<Teacher> teachers, List<Faculty> faculties)
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

                ILog.AddNewLog("Valore non valido", "AddTeacher");

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
                ILog.AddNewLog("Valore non valido", "AddTeacher");

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

                ILog.AddNewLog("Valore non valido", "AddTeacher");

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
                ILog.AddNewLog("Valore non valido", "AddTeacher");

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
                ILog.AddNewLog("Valore non valido", "AddTeacher");

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
                ILog.AddNewLog("Valore non valido", "AddTeacher");

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

                ILog.AddNewLog("Tentativo di inserimento minore", "AddTeacher");

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








        Console.WriteLine("Codice Professore:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string teacherCode = string.Empty;
        bool tcUnique = true;

        while (!isValidField)
        {
            teacherCode = Console.ReadLine();



            if (teacherCode.Length == 6 && teacherCode.ToCharArray()[4].ToString() == "_" && char.IsAsciiLetter(teacherCode.ToCharArray()[0]))
            {

                teachers.ForEach(t =>
                {

                    if (t.TeacherCode == teacherCode)
                    {
                        ILog.AddNewLog("Codice Professore già esistente", "AddTeacher");
                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', Console.WindowWidth - xCursor));
                        Console.SetCursorPosition(xCursor, yCursor + 1);
                        Console.Write(new string(' ', Console.WindowWidth - xCursor));
                        Console.SetCursorPosition(xCursor, yCursor + 1);
                        Console.WriteLine("Valore non accettato,matricola esistente");
                        Console.SetCursorPosition(xCursor, yCursor);


                        tcUnique = false;
                        return;
                    }

                });


                if (tcUnique)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.CursorTop);
                    isValidField = true;
                }

            }
            else if (teacherCode == string.Empty)
            {
                ILog.AddNewLog("Valore non valido ,valore nullo", "AddTeacher");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);

                tcUnique = true;
            }
            else if (teacherCode.Length != 6)
            {
                ILog.AddNewLog("Il codice Professore deve avere 6 caratteri", "AddTeacher");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Codice non di 6  caratteri");
                Console.SetCursorPosition(xCursor, yCursor);

                tcUnique = true;
            }
            else if (int.TryParse(teacherCode, out _))
            {
                ILog.AddNewLog("Valore numerico non valido lettera iniziale non presente", "AddTeacher");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Lettera iniziale non presente");
                Console.SetCursorPosition(xCursor, yCursor);
                tcUnique = true;
            }
            else if (teacherCode.ToCharArray()[4].ToString() != "_")
            {
                ILog.AddNewLog("Valore non valido UnderScore come 5° carattere non presente", "AddTeacher");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("UnderScore come 5° carattere non presente");
                Console.SetCursorPosition(xCursor, yCursor);
                tcUnique = true;
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






        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        List<String> optionsMatter = faculties.Find(f => f.Name == department).Matters.Select(m => m.Name).ToList();
        Matter matter = new();
        int selectedIndexMatter = 0;
        ConsoleKeyInfo keyMatter;

        do
        {
            Console.Clear();
            Console.WriteLine("Materia:");
            for (int i = 0; i < optionsMatter.Count; i++)
            {
                if (i == selectedIndexMatter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(optionsMatter[i]);
                Console.ResetColor();
            }

            keyMatter = Console.ReadKey(true);

            if (keyMatter.Key == ConsoleKey.UpArrow)
            {
                selectedIndexMatter = (selectedIndexMatter > 0) ? selectedIndexMatter - 1 : optionsMatter.Count - 1;
            }
            else if (keyMatter.Key == ConsoleKey.DownArrow)
            {
                selectedIndexMatter = (selectedIndexMatter < optionsMatter.Count - 1) ? selectedIndexMatter + 1 : 0;
            }

        } while (keyMatter.Key != ConsoleKey.Enter);

        Console.Clear();

        optionsMatter.ForEach(o =>
        {


            if (optionsMatter.IndexOf(o) == selectedIndexMatter)
            {

                matter = faculties.Find(f => f.Name == department).Matters.Find(m => m.Name == o);
                return;
            }
        });
        isValidField = false;






        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        TeacherRoleEnum Role = new();


        List<String> optionsRole = ["Professore", "Assistente"];
        int selectedIndexRole = 0;
        ConsoleKeyInfo keyRole;

        do
        {
            Console.Clear();
            Console.WriteLine("Ruolo:");
            for (int i = 0; i < optionsRole.Count; i++)
            {
                if (i == selectedIndexRole)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(optionsRole[i]);
                Console.ResetColor();
            }

            keyRole = Console.ReadKey(true);

            if (keyRole.Key == ConsoleKey.UpArrow)
            {
                selectedIndexRole = (selectedIndexRole > 0) ? selectedIndexRole - 1 : optionsRole.Count - 1;
            }
            else if (keyRole.Key == ConsoleKey.DownArrow)
            {
                selectedIndexRole = (selectedIndexRole < optionsRole.Count - 1) ? selectedIndexRole + 1 : 0;
            }

        } while (keyRole.Key != ConsoleKey.Enter);




        switch (selectedIndexRole)
        {
            case 0:
                Role = TeacherRoleEnum.Teacher;
                break;
            case 1:
                Role = TeacherRoleEnum.Assistant;

                break;
        }
        isValidField = false;


        teacherRepository.Teachers.Add(new Teacher(name, sureName, ageInt, gender, department, teacherCode, matter, Role));



    }

    public void UpdateTeacher(List<Teacher> teachers, List<Faculty> faculties)
    {
        Console.WriteLine("Inserisci Codice Professore del professore da modificare:");

        bool isValidField = false;
        int xCursor = 0;
        int yCursor = 0;

        try
        {

            Console.WriteLine("Codice Professore:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string teacherCode = string.Empty;
            bool Notfinded = true;


            while (!isValidField)
            {
                teacherCode = Console.ReadLine();

                teachers.ForEach(t =>
                {
                    if (t.TeacherCode.Equals(teacherCode, StringComparison.OrdinalIgnoreCase))
                    {

                        isValidField = true;
                        Notfinded = false;
                        return;

                    }

                });

                if (Notfinded)
                {
                    ILog.AddNewLog("Codice Professore non trovato", "UpdateTeacher");
                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Codice Professore non trovato");
                    Console.SetCursorPosition(xCursor, yCursor);
                }

            }
            isValidField = false;

            Teacher teacher = teachers.Find(t => t.TeacherCode.Equals(teacherCode, StringComparison.OrdinalIgnoreCase));
            List<string> options = ["nome", "cognome", "eta", "sesso", "dipartimento", "materia", "ruolo"];


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
                    Console.WriteLine("Nome attuale: " + teacher.Name);
                    Console.WriteLine("Inserisci nuovo nome:");
                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    string name = string.Empty;

                    while (!isValidField)
                    {
                        name = Console.ReadLine();

                        if (int.TryParse(name, out _))
                        {

                            ILog.AddNewLog("Valore non valido", "Addteacher");

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
                            ILog.AddNewLog("Valore non valido", "Addteacher");

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

                    teacher.Name = name;
                    isValidField = false;


                    break;
                case 1:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    Console.WriteLine("Cognome attuale: " + teacher.SureName);
                    Console.WriteLine("Inserisci nuovo cognome:");
                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    string sureName = string.Empty;

                    while (!isValidField)
                    {
                        sureName = Console.ReadLine();

                        if (int.TryParse(sureName, out _))
                        {

                            ILog.AddNewLog("Valore non valido", "Addteacher");

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
                            ILog.AddNewLog("Valore non valido", "Addteacher");

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

                    teacher.SureName = sureName;
                    isValidField = false;

                    break;
                case 2:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    Console.WriteLine("Eta attuale: " + teacher.Age);
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
                            ILog.AddNewLog("Valore non valido", "Addteacher");

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
                            ILog.AddNewLog("Valore non valido", "Addteacher");

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

                            ILog.AddNewLog("Tentativo di inserimento minore", "Addteacher");

                            Console.SetCursorPosition(xCursor, yCursor);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.Write(new string(' ', Console.WindowWidth - xCursor));
                            Console.SetCursorPosition(xCursor, yCursor + 1);
                            Console.WriteLine("Età non valida, minore di 18");
                            Console.SetCursorPosition(xCursor, yCursor);

                        }
                    }

                    teacher.Age = ageInt;
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
                        Console.WriteLine("Sesso attuale: " + teacher.Gender);
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

                    teacher.Gender = gender;
                    isValidField = false;


                    break;
                case 4:


                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    List<String> optionsDepartment = ["Facoltà di Giurisprudenza", "Facoltà di Economia", "Facoltà di Ingegneria", "Facoltà di Medicina", "Facoltà di Lettere e Filosofia", "Facoltà di Scienze",
                    "Facoltà di Architettura", "Facoltà di Scienze Politiche", "Facoltà di Psicologia"];
                    string department = string.Empty;
                    int selectedIndexDepartment = 0;
                    ConsoleKeyInfo keyDepartment;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        Console.WriteLine("Facoltà attuale: " + teacher.Department);
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

                    teacher.Department = department;
                    isValidField = false;

                    break;
                case 5:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    Console.WriteLine("Materia attuale: " + teacher.TeachedMatter.ToString());
                    Console.WriteLine("Inserisci nuova materia:");
                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    List<String> optionsMatter = faculties.Find(f => f.Name == teacher.Department).Matters.Select(m => m.Name).ToList();
                    Matter matter = new();
                    int selectedIndexMatter = 0;
                    ConsoleKeyInfo keyMatter;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Materia:");
                        for (int i = 0; i < optionsMatter.Count; i++)
                        {
                            if (i == selectedIndexMatter)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(optionsMatter[i]);
                            Console.ResetColor();
                        }

                        keyMatter = Console.ReadKey(true);

                        if (keyMatter.Key == ConsoleKey.UpArrow)
                        {
                            selectedIndexMatter = (selectedIndexMatter > 0) ? selectedIndexMatter - 1 : optionsMatter.Count - 1;
                        }
                        else if (keyMatter.Key == ConsoleKey.DownArrow)
                        {
                            selectedIndexMatter = (selectedIndexMatter < optionsMatter.Count - 1) ? selectedIndexMatter + 1 : 0;
                        }

                    } while (keyMatter.Key != ConsoleKey.Enter);

                    Console.Clear();

                    optionsMatter.ForEach(o =>
                    {


                        if (optionsMatter.IndexOf(o) == selectedIndexMatter)
                        {

                            matter = faculties.Find(f => f.Name == teacher.Department).Matters.Find(m => m.Name == o);
                            return;
                        }
                    });

                    teacher.TeachedMatter = matter;
                    isValidField = false;

                    break;
                case 6:
                    Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                    Console.WriteLine("Ruolo attuale: " + teacher.Role);
                    Console.WriteLine("Inserisci nuovo ruolo:");
                    xCursor = Console.GetCursorPosition().Left;
                    yCursor = Console.GetCursorPosition().Top;
                    TeacherRoleEnum Role = new();


                    List<String> optionsRole = ["Professore", "Assistente"];
                    int selectedIndexRole = 0;
                    ConsoleKeyInfo keyRole;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Ruolo:");
                        for (int i = 0; i < optionsRole.Count; i++)
                        {
                            if (i == selectedIndexRole)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(optionsRole[i]);
                            Console.ResetColor();
                        }

                        keyRole = Console.ReadKey(true);

                        if (keyRole.Key == ConsoleKey.UpArrow)
                        {
                            selectedIndexRole = (selectedIndexRole > 0) ? selectedIndexRole - 1 : optionsRole.Count - 1;
                        }
                        else if (keyRole.Key == ConsoleKey.DownArrow)
                        {
                            selectedIndexRole = (selectedIndexRole < optionsRole.Count - 1) ? selectedIndexRole + 1 : 0;
                        }

                    } while (keyRole.Key != ConsoleKey.Enter);




                    switch (selectedIndexRole)
                    {
                        case 0:
                            teacher.Role = TeacherRoleEnum.Teacher;
                            break;
                        case 1:
                            teacher.Role = TeacherRoleEnum.Assistant;

                            break;
                    }
                    isValidField = false;

                    break;


            }



        }
        catch (Exception ex)
        {
            Console.WriteLine(ILog.AddNewLog(ex.Message, "UpdateStudent").PrintLog());
        }

    }

    public void DeleteTeacher(TeacherRepository teacherRepository)
    {
       Console.WriteLine("Inserisci Codice Professore del professore da modificare:");

        bool isValidField = false;
        int xCursor = 0;
        int yCursor = 0;
        try
        {
            Console.WriteLine("Codice Professore:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string teacherCode = string.Empty;
            bool Notfinded = true;


            while (!isValidField)
            {
                teacherCode = Console.ReadLine();
                
                teacherRepository.Teachers.ForEach(t =>
                {
                    if (t.TeacherCode.Equals(teacherCode, StringComparison.OrdinalIgnoreCase))
                    {

                        isValidField = true;
                        Notfinded = false;
                        return;

                    }

                });

                if (Notfinded)
                {
                    ILog.AddNewLog("Codice Professore non trovato", "DeleteTeacher");
                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Codice Professore non trovato");
                    Console.SetCursorPosition(xCursor, yCursor);
                }

            }
            isValidField = false;


            List<string> optionsDeleted = ["SI", "NO"];
            int selectedIndexDeleted = 0;

            ConsoleKeyInfo keyDeleted;

            do
            {
                Console.Clear();
                Console.WriteLine("Sicuro di Voler eliminare questo Professore?");
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
                    teacherRepository.Teachers.Remove(teacherRepository.Teachers.Find(t => t.TeacherCode.Equals(teacherCode, StringComparison.OrdinalIgnoreCase)));
                    Console.WriteLine("Il Professore è stato eliminato");
                    break;
                case 1:
                    Console.WriteLine("Il Professore non è stato eliminato");


                    break;
            }
            isValidField = false;


        }
        catch (Exception ex)
        {

            Console.WriteLine(ILog.AddNewLog(ex.Message, "DeleteTeacher").PrintLog());
        }





    }
}