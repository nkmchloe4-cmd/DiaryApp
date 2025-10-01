using System.IO;

namespace DiaryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string diaryFilePath = "diary.txt";

            // Läs in befintliga anteckningar
            DiaryProperties.ReadFromFile(diaryFilePath);

            while (true)
            {            
                Console.WriteLine("Välkommen Till DagboksAppen!");

                Console.WriteLine("\nVad vill du göra?");
                Console.WriteLine("1. Skriv ny anteckning");
                Console.WriteLine("2. Visa alla anteckningar ");
                Console.WriteLine("3. Sök anteckning på datum");
                Console.WriteLine("4. Spara till fil");
                Console.WriteLine("5. Läs från fil");
                Console.WriteLine("6. Avsluta Appen");

                Console.WriteLine("\nSkriv in din val 1-6:");
                
                MenuChoices choice = GetMenuChoices();

                switch (choice)
                {
                    case MenuChoices.AddEntry:
                        Console.WriteLine("Skriv in din anteckning");
                        DiaryProperties.AddEntry(diaryFilePath);
                        Console.WriteLine("\nTryck Enter för att fortsätta");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case MenuChoices.ShowAllEntries:
                        DiaryProperties.ShowAllEntries(diaryFilePath);
                        Console.WriteLine("\nTryck Enter för att fortsätta");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case MenuChoices.SearchEntries:
                        DiaryProperties.SearchEntries(diaryFilePath);
                        Console.WriteLine("\nTryck Enter för att fortsätta");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case MenuChoices.SaveToFile:
                        DiaryProperties.SaveToFile(diaryFilePath);
                        Console.WriteLine("Dagboken har sparats");
                        Console.WriteLine("\nTryck Enter för att fortsätta");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case MenuChoices.ReadFromFile:
                        DiaryProperties.ReadFromFile(diaryFilePath);
                        Console.WriteLine("Filen har lästs in.");
                        DiaryProperties.ShowAllEntries(diaryFilePath);
                        Console.WriteLine("\nTryck Enter för att fortsätta");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case MenuChoices.Exit:
                        Console.WriteLine("Avslutar Appen. Hej då!");
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen!");
                        break;
                }                           
            }
        }       
        private static MenuChoices GetMenuChoices()
        {
            string? input = Console.ReadLine();
            if (Enum.TryParse<MenuChoices>(input, true, out MenuChoices choice) 
                && Enum.IsDefined(typeof(MenuChoices), choice))
            {
                return choice;
            }
            Console.WriteLine("Ogiltigt val. Försök igen.");
            return GetMenuChoices();
        }
    }
}
