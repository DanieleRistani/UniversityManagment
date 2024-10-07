using System;
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


    public void AddStudent(Student student)
    {
        studentRepository.Students.Add(student);
    }
}
