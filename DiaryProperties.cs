using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiaryApp
{
    public class DiaryProperties
    {
        public static List<string> Entries = new List<string>();

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
                Entries.Add(entryWithTimestamp);// Lägg till i minnet
                File.WriteAllLines(diaryFilePath, Entries);//Spara listan till filen
                Console.WriteLine("Anteckning tillagd!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid tillägg av anteckning: {ex.Message}");
            }
        }

        public static void ShowAllEntries(string diaryFilePath)
        {           
           try
           {
                if (!File.Exists(diaryFilePath))
                {
                    Console.WriteLine("Ingen dagbokfil hittades.");
                    return;
                }
              
                ReadFromFile(diaryFilePath);
                if (Entries.Count == 0)
                 {
                  Console.WriteLine("Inga anteckningar hittades.");
                  return;
                 }
                                               
                 Console.WriteLine("Dina anteckningar är följande:");
                 for (int i = 0; i < Entries.Count; i++)
                 {
                   Console.WriteLine($"{i + 1}. {Entries[i].Split(": ", 2)[1]}");
                 }  //Skriver ut endast texten, utan tidstämplingar                                        
           }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ett fel uppstod vid visning av anteckningar: {ex.Message}");
                }           
        }
        public static void SearchEntries(string diaryFilePath)
        {
            Console.WriteLine("Ange datum du söker efter (format: yyyy-MM-dd):");
            string? inputDate = Console.ReadLine();
            if (!DateTime.TryParse(inputDate, out DateTime searchDate))
            {
                Console.WriteLine("Ogiltigt datum, försök igen.");
                return;
            }

            try
            {
                
                ReadFromFile(diaryFilePath);//Uppdatera Entries från filen
                bool found = false;

                foreach (string entry in Entries)
                {
                    if (entry.StartsWith(searchDate.ToString("yyyy-MM-dd")))
                    {
                        Console.WriteLine(entry);
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Inga anteckningar hittades för angiven datumet.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid läsningen av filen: {ex.Message}");
            }
        }

        public static void SaveToFile(string diaryFilePath)
        {
            try
            {
                File.WriteAllLines(diaryFilePath, Entries);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid sparning: {ex.Message}");
            }
        }

        public static void ReadFromFile(string diaryFilePath)
        {
            try
            {
                if (File.Exists(diaryFilePath))
                {
                    Entries = File.ReadAllLines(diaryFilePath).ToList();
                }
                else
                {
                    Console.WriteLine("Filen hittades inte.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid läsning: {ex.Message}");
            }


        }
                
    }
}

