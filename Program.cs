using System.IO;

namespace DiaryApp
{
    internal class Program
    {
        private static readonly string diaryFilePath = "diary.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen Till DagboksAppen!");

            while (true)
            {
                Console.WriteLine("\nVad vill du göra?");
                Console.WriteLine("1. Skriv ny anteckning");
                Console.WriteLine("2. Visa alla anteckningar ");
                Console.WriteLine("3. Sök anteckning på datum");
                Console.WriteLine("4. Spara till fil");
                Console.WriteLine("5. Läs från fil");
                Console.WriteLine("6. Avsluta Appen");
                Console.WriteLine("Skriv in din val");

                MenuChoices choice = GetMenuChoices();

                switch (choice)
                {
                    case MenuChoices.AddEntry:
                        Console.WriteLine("Skriv in din anteckning");
                        DiaryProperties.AddEntry(diaryFilePath);
                        break;

                    case MenuChoices.ShowAllEntries:
                        DiaryProperties.ShowAllEntries(diaryFilePath);
                        break;

                    case MenuChoices.SearchEntries:
                        SearchEntries();
                        break;

                    case MenuChoices.SaveToFile:
                        SaveToFile();
                        break;

                    case MenuChoices.ReadFromFile:
                        ReadFromFile();
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
