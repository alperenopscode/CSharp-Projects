using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Notes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool control = true;
            while (control)
            {
                string choiceResult = ChoiceScreen();
                switch (choiceResult)
                {
                    case "1":
                        Notes.AddNote();
                        break;
                    case "2":
                        Notes.DeleteNote();
                        break;
                    case "3":
                        Notes.ViewNote();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        control = false;
                        break;
                    default:
                        Console.WriteLine("\nWARNING: Invalid choice, please try again!!!");
                        break;
                }
            }

        }
        static string ChoiceScreen()
        {
            Console.WriteLine("1- Add new note");
            Console.WriteLine("2- Delete new note");
            Console.WriteLine("3- View notes");
            Console.WriteLine("4- Exit");

            Console.Write("\nYour Choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
    }
    internal class Notes// Notes Class
    {
        static string folder = @"c:\Notes";
        static string file = @"c:\Notes\Mynotes.txt";
        public static void AddNote()//Add Note Method
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            if (!File.Exists(file) && Directory.Exists(folder))
                File.WriteAllText(file, "");


            if (Directory.Exists(folder) && File.Exists(file))
            {
                Console.Clear();
                Console.Write("Type the note you want to enter: ");
                string inputNote = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputNote))
                {
                    int lineCount = File.ReadAllLines(file).Length + 1;
                    string note = $"{lineCount}. {inputNote}" + "\n";

                    File.AppendAllText(file, note);
                    Console.WriteLine("\nINFO: Note added successfully.");
                }
                else
                    Console.WriteLine("\nWARNING: Your note cannot be empty!!!");
            }
        }
        public static void DeleteNote()//Delete Note Method
        {
            if (File.Exists(file))
            {
                Console.Clear();
                string[] notes = File.ReadAllLines(file);
                if (notes.Length > 0)
                {
                    foreach (string note in notes)
                    {
                        Console.WriteLine(note);
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine("--------------------------------");

                    Console.Write("Which note do you want to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int noteNumber))
                    {
                        if (noteNumber > 0 && noteNumber <= notes.Length)
                        {
                            var updatedNotes = notes.Where((note, index) => index != noteNumber - 1).ToList();

                            // Notları yeniden numaralandır ve dosyayı güncelle
                            for (int i = 0; i < updatedNotes.Count; i++)
                            {
                                updatedNotes[i] = $"{i + 1}. {updatedNotes[i].Substring(updatedNotes[i].IndexOf(' ') + 1)}";
                            }
                            File.WriteAllLines(file, updatedNotes);
                            Console.WriteLine("\nINFO: Note deleted successfully.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nWARNING: There is no note for this number!!!");
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nWARNING: Please enter a number!!!");
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nWARNING: There is nothing in the note file!!!");
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nWARNING: Note file does not exist!!!");
            }

        }
        public static void ViewNote()//View Note Method
        {
            if (File.Exists(file))
            {
                Console.Clear();
                string[] notes = File.ReadAllLines(file);
                if (notes.Length > 0)
                {
                    Console.WriteLine("*** NOTES ***");
                    foreach (string note in notes)
                    {
                        Console.WriteLine(note);
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine("--------------------------------");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nWARNING: There is nothing in the note file!!!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nWARNING: Note file does not exist!!!");
            }
        }
    }
}
