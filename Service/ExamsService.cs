using System;
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
                }else{
                    Console.Clear();
                    ExamsList(examRepository.Exams.FindAll(e => e.ExamCode.Equals(examCode, StringComparison.OrdinalIgnoreCase)));
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ILog.AddNewLog(ex.Message, "SearchExam").PrintLog());
            }






    }
    }