using System;
using University.Interface;
using University.Repository;

namespace University.Service;

public class ExamsService
{
 public ExamRepository examRepository  {get; set;}= new();

 public void ExamsList(){

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
}
