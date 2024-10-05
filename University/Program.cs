using OPP.Entity;
using University.Enum;
using University.Repository;
using University.Service;

namespace University
{
    internal class Program
    {

        static AppMenùService appMenùService = new AppMenùService();
    
        
        static void Main(string[] args)=>AppMenu();
        
            
        public static void AppMenu()
        {
            
            appMenùService.ImportAll();
            bool exitLoop = false;
            while (!exitLoop)
            {
                string[] options = { "Inserisci Studente", "Inserisci Docente", "Inserisci Esame", "Lista Facoltà", "Esci" };
                int selectedIndex = 0;
                ConsoleKeyInfo key;

                do
                {
                    Console.Clear();
                    for (int i = 0; i < options.Length; i++)
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
                        selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : options.Length - 1;
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = (selectedIndex < options.Length - 1) ? selectedIndex + 1 : 0;
                    }

                } while (key.Key != ConsoleKey.Enter);

                Console.Clear();

                switch (selectedIndex)
                {
                    case (int)AppMenuEnum.AddStudent:
                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        
                        break;
                    case (int)AppMenuEnum.AddTeacher:
                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        
                        break;
                    case (int)AppMenuEnum.AddExam:
                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        
                        break;
                    case (int)AppMenuEnum.Facultieslist:
                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        
                        break;
                    case (int)AppMenuEnum.Exit:
                        Console.WriteLine($"Uscita dall' Applicazione");
                        exitLoop = true;
                        break;
                }

                if(exitLoop==false){
                Console.WriteLine("Premere un tasto per tornare al menù principale");
                _ = Console.ReadKey();
                }

            }
            exitLoop = true;
        }
    }
}
