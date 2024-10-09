using System;
using OPP.Entity;
using University.Entity;
using University.Interface;
using University.Repository;

namespace University.Service;

public class ExamsService
{
    public ExamRepository examRepository { get; set; } = new();

    public void ExamsList()
    {

        bool exitLoop = false;
        while (!exitLoop)
        {
            List<String> options = [];

            examRepository.Exams.ForEach(e =>
            {
                options.Add(e.ExamCode + "|" + e.MatterExam.Name + "|" + e.MatterExam.DepartmentName);
            });
            String exit = "Esci";
            options.Add(exit);

            int selectedIndex = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleziona Esame:\n----------------------------------------------");
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
                    Console.WriteLine(examRepository.Exams.Find(e => e.ExamCode == options[selectedIndex].Split("|")[0]).ToString());

                    return;
                }
            });

            if (exitLoop == false)
            {
                Console.WriteLine("Premere un tasto per tornare alla lista Esami");
                _ = Console.ReadKey();
            }

        }
        exitLoop = true;
    }

    public void ExamsList(List<Exam> exams)
    {

        bool exitLoop = false;
        while (!exitLoop)
        {
            List<String> options = [];

            exams.ForEach(e =>
            {
                options.Add(e.ExamCode + "|" + e.MatterExam.Name + "|" + e.MatterExam.DepartmentName);
            });
            String exit = "Esci";
            options.Add(exit);

            int selectedIndex = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleziona Esame:\n----------------------------------------------");
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
                    Console.WriteLine(exams.Find(e => e.ExamCode == options[selectedIndex].Split("|")[0]).ToString());

                    return;
                }
            });

            if (exitLoop == false)
            {
                Console.WriteLine("Premere un tasto per tornare alla lista Esami");
                _ = Console.ReadKey();
            }

        }
        exitLoop = true;
    }

    public void SearchExam()
    {

        Console.WriteLine("Inserisci Codice Esame:");

        bool isValidField = false;
        int xCursor = 0;
        int yCursor = 0;




        Console.WriteLine("Codice Esame:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string examCode = string.Empty;
        bool Notfinded = true;


        while (!isValidField)
        {
            examCode = Console.ReadLine();

            examRepository.Exams.ForEach(e =>
            {
                if (e.ExamCode.Equals(examCode, StringComparison.OrdinalIgnoreCase))
                {

                    isValidField = true;
                    Notfinded = false;
                    return;

                }

            });

            if (Notfinded)
            {
                ILog.AddNewLog("Codice Esame non trovato", "SearchExam");
                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Codice Esame non trovato");
                Console.SetCursorPosition(xCursor, yCursor);
            }

        }

        try
        {
            if (examRepository.Exams.FindAll(e => e.ExamCode.Equals(examCode, StringComparison.OrdinalIgnoreCase)).Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Esame non trovato");
            }
            else if (examRepository.Exams.FindAll(e => e.ExamCode.Equals(examCode, StringComparison.OrdinalIgnoreCase)).Count == 1)
            {
                Console.Clear();
                Console.WriteLine(examRepository.Exams.FindAll(e => e.ExamCode.Equals(examCode, StringComparison.OrdinalIgnoreCase)).First().ToString());
            }
            else
            {
                Console.Clear();
                ExamsList(examRepository.Exams.FindAll(e => e.ExamCode.Equals(examCode, StringComparison.OrdinalIgnoreCase)));
            }


        }
        catch (Exception ex)
        {
            Console.WriteLine(ILog.AddNewLog(ex.Message, "SearchExam").PrintLog());
        }






    }

    public void AddExam(List<Exam> exams, List<Student> students, List<Teacher> teachers, List<Faculty> faculties)
    {


        Console.WriteLine("Inserimento nuovo esame:");


        bool isValidField = false;
        int xCursor = 0;
        int yCursor = 0;




        Console.WriteLine("Codice Esame:");
        xCursor = Console.GetCursorPosition().Left;
        yCursor = Console.GetCursorPosition().Top;
        string exameCode = string.Empty;


        while (!isValidField)
        {
            exameCode = Console.ReadLine();



            if (exameCode.Length == 5 && exameCode.ToCharArray()[0] == 'E' && exameCode.ToCharArray()[1] == 'X')
            {



                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                isValidField = true;



            }
            else if (exameCode == string.Empty)
            {
                ILog.AddNewLog("Valore non valido ,valore nullo", "AddExam");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Valore nullo");
                Console.SetCursorPosition(xCursor, yCursor);


            }
            else if (exameCode.Length != 5)
            {
                ILog.AddNewLog("Il codice esame deve avere  5 caratteri", "AddExam");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Codice esame non di 5 caratteri");
                Console.SetCursorPosition(xCursor, yCursor);


            }
            else if (int.TryParse(exameCode, out _) || exameCode.ToCharArray()[1] == 'X')
            {
                ILog.AddNewLog("Valore numerico non valido lettere iniziali non presenti", "AddExam");

                Console.SetCursorPosition(xCursor, yCursor);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.Write(new string(' ', Console.WindowWidth - xCursor));
                Console.SetCursorPosition(xCursor, yCursor + 1);
                Console.WriteLine("Lettere iniziale non presenti");
                Console.SetCursorPosition(xCursor, yCursor);

            }
        }
        isValidField = false;



        if (!exams.Select(e => e.ExamCode).Contains(exameCode))
        {


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





            string teacherCode = string.Empty;


            Console.WriteLine("Codice Professore:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            bool notfindedTeacher = true;
            bool notMatterMatch = true;

            while (!isValidField)
            {
                notfindedTeacher = true;
                notMatterMatch = true;
                teacherCode = Console.ReadLine();

                
                
                    if (teachers.Select(t=>t.TeacherCode).Contains(teacherCode))
                    {
                        if (teachers.Find(t => t.TeacherCode == teacherCode).TeachedMatter != matter)
                        {

                            notfindedTeacher = false;
                            notMatterMatch = true;
                            
                        }
                        else
                        {

                            isValidField = true;
                            notfindedTeacher = false;
                            notMatterMatch = false;
                            

                        }


                    }else{
                    notMatterMatch=false;
                    notfindedTeacher = true;
                    }


              

                if (notMatterMatch)
                {
                    ILog.AddNewLog("Professore non conforme alla materia", "AddExam");
                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Materia non insegnata da questo professore");
                    Console.SetCursorPosition(xCursor, yCursor); 

                }

                if (notfindedTeacher)
                {
                    ILog.AddNewLog("Codice Professore non trovato", "AddExam");
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








            Console.WriteLine("Matricola:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string mat = string.Empty;
            bool NotfindedMat = true;
           


            while (!isValidField)
            {
                                
                NotfindedMat = true;
            
                mat = Console.ReadLine();



                if (students.Select(s => s.Matricola).Contains(mat))
                {


                    isValidField = true;
                    NotfindedMat = false;
                    

                }
                else
                {
                    NotfindedMat = true;

                }


                if (NotfindedMat)
                {
                    ILog.AddNewLog("Matricola non trovata", "AddExam");
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







            Console.WriteLine("Data esame:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string date = string.Empty;
            DateTime dateExam = DateTime.Now;

            while (!isValidField)
            {
                date = Console.ReadLine();

                if (DateTime.TryParse(date, out dateExam) && dateExam < DateTime.Now)
                {

                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.CursorTop);
                    dateExam = DateTime.Parse(date);
                    isValidField = true;


                }
                else if (date == string.Empty)
                {
                    ILog.AddNewLog("Valore non valido ,valore nullo", "AddExam");

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
                    ILog.AddNewLog("Valore non valido formato Data errato", "AddExam");

                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Formato Data errato");
                    Console.SetCursorPosition(xCursor, yCursor);
                }



            }
            isValidField = false;






            Console.Write("Età:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string result;
            int resultInt = 0;

            while (!isValidField)
            {
                result = Console.ReadLine();

                if (int.TryParse(result, out resultInt) && resultInt >= 0 && resultInt <= 30)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.CursorTop);
                    resultInt = int.Parse(result);
                    isValidField = true;

                }
                else if (result == string.Empty)
                {
                    ILog.AddNewLog("Valore non valido", "AddExam");

                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Valore nullo");
                    Console.SetCursorPosition(xCursor, yCursor);
                }
                else if (!int.TryParse(result, out _))
                {
                    ILog.AddNewLog("Valore non valido", "AddExam");

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

                    ILog.AddNewLog("Voto non valido, fuori range", "AddExam");

                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Voto non valido valore fuori range [0-30]");
                    Console.SetCursorPosition(xCursor, yCursor);

                }
            }
            isValidField = false;


            Exam newExame = new Exam(exameCode, matter, teacherCode, mat, dateExam, resultInt);
            exams.Add(newExame);
            students.Find(s => s.Matricola == mat).Exams.Add(newExame);



        }
        else
        {

            Console.WriteLine("Matricola:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string mat = string.Empty;
            bool NotfindedMat = true;
            bool doYet = true;


            while (!isValidField)
            {
                NotfindedMat = true;
                doYet = true;

                     mat = Console.ReadLine();

                
                
                    if (students.Select(s=>s.Matricola).Contains(mat))
                    {
                        if (exams.Select(e=>e.StudentMatricola).Contains(mat))
                        {

                            doYet = true;
                            NotfindedMat = false;
                            
                        }
                        else
                        { 

                                isValidField = true;
                                NotfindedMat = false;
                                doYet = false;
                               

                        }

                    }else{
                    doYet = false;
                    NotfindedMat = true;
                    }

                


                if (NotfindedMat)
                {
                    ILog.AddNewLog("Matricola non trovata", "AddExam");
                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Matricola non trovata");
                    Console.SetCursorPosition(xCursor, yCursor);
                
                }

                if (doYet)
                {
                    ILog.AddNewLog("Matricola già associata a questo esame", "AddExam");
                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Matricola già associata");
                    Console.SetCursorPosition(xCursor, yCursor);
    
                }


            }
            isValidField = false;


            Exam newExame = new Exam(exameCode, exams.Find(e => e.ExamCode.Equals(exameCode)).MatterExam, exams.Find(e => e.ExamCode.Equals(exameCode)).TeacherCode, mat, exams.Find(e => e.ExamCode.Equals(exameCode)).ExamDate, exams.Find(e => e.ExamCode.Equals(exameCode)).Result);
            exams.Add(newExame);
            students.Find(s => s.Matricola == mat).Exams.Add(newExame);
        }






    }
}