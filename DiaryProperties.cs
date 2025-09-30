using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp
{
    public class DiaryProperties
    {

        public static void AddEntry(string diaryFilePath)
        {
            Console.WriteLine("Ange anteckning att lägga till:");
            string? entry = Console.ReadLine();
            if (string.IsNullOrEmpty(entry))
            {
                Console.WriteLine("Din anteckning kan inte vara tom");
                return;
            }
            try
            {
                string entryWithTimestamp = $"{DateTime.Now:yyyy-MM-dd HH:mm}: {entry}";
                File.AppendAllText(diaryFilePath, entryWithTimestamp + Environment.NewLine);
                Console.WriteLine("Anteckning tillagd!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid tillägg av anteckning: {ex.Message}");
            }
        }

        public static void ShowAllEntries(string diaryFilePath)
        {
            {
                try
                {
                    if (File.Exists(diaryFilePath))
                    {
                        string[] entries = File.ReadAllLines(diaryFilePath);
                        if (entries.Length == 0)
                        {
                            Console.WriteLine("Inga anteckningar hittades.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Dina anteckningar är följande:");

                            for (int i = 0; i < entries.Length; i++)
                            {


                                Console.WriteLine($"{i + 1}. {entries[i]}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ingen dagboksfil hittades.");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Ett fel uppstod vid visning av anteckningar: {ex.Message}");
                }

            }
        }
    }
}

