using System;
using System.Numerics;

namespace Final_Project
{
    public class StoreMenu : Menu
    {
        public List<KeyValuePair<string, string>> ItemOptions { get; private set; }

        public StoreMenu(string prompt, List<KeyValuePair<string, string>> itemOptions) : base(prompt)
        {
            ItemOptions = itemOptions;
            Prompt = prompt; 
        }

        public StoreMenu(string prompt, List<KeyValuePair<string, string>> itemOptions, string image) : base(prompt, image)
        {
            ItemOptions = itemOptions;
            Prompt = prompt;
            Image = image;
        }

        public override string RunMenu()
        {
            bool looping = true;
            while (looping)
            {
                Console.Clear();
                DisplayOptions(selectedOption);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        AddIndex();
                        break;


                    case ConsoleKey.UpArrow:
                        DeductIndex();
                        break;

                    case ConsoleKey.Enter:
                        looping = false;
                        return ItemOptions[selectedOption].Key;
                }
            }
            return null;
        }

        public override void DisplayOptions(int selectedOptionIndex)
        {
            if(Image != "")
            {
                Console.WriteLine(Image);
            }
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            Console.WriteLine($"\t{Prompt}");
            Console.WriteLine("\t═════════════════════════════════════════");
            int j = 0;
            foreach(var kvp in ItemOptions)
            {
                if(j == selectedOptionIndex)
                {
                    if(kvp.Key == "Exit")
                    {
                        Console.WriteLine($"\t{j + 1} Exit", Console.ForegroundColor = ConsoleColor.Cyan);
                    }
                    else if(kvp.Key == "- Exit -")
                    {
                        Console.WriteLine($"\t{j + 1} - Exit -", Console.ForegroundColor = ConsoleColor.Cyan);
                    }
                    else if (kvp.Key.Contains("PURCHASED"))
                    {
                        PrintPurchasedOption(kvp, j);
                    }
                    else
                    {
                        PrintUnPurchasedOption(kvp, j);
                    }
                }
                else
                {
                    Console.WriteLine($"\t{j + 1}. {kvp.Key}");
                }
                Console.ResetColor();
                j++;
            }
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
        }

        private void PrintPurchasedOption(KeyValuePair<string, string> item, int j)
        {
            Console.WriteLine($"\t{j + 1}. {item.Key}", Console.ForegroundColor = ConsoleColor.Gray);
            Console.ResetColor();
            Console.WriteLine("\t═════════════════════════════════");
            Console.WriteLine(item.Value);
            Console.WriteLine("\t═════════════════════════════════");
        }

        private void PrintUnPurchasedOption(KeyValuePair<string, string> item, int j)
        {
            Console.WriteLine($"\t{j + 1}. {item.Key}", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.ResetColor();
            Console.WriteLine("\t═════════════════════════════════");
            Console.WriteLine(item.Value);
            Console.WriteLine("\t═════════════════════════════════");
        }

        /*-------------------------------------
            Helper Functions 
         -------------------------------------*/

        public override void AddIndex()
        {
            if (selectedOption + 1 > ItemOptions.Count() - 1)
            {
                selectedOption = 0;
            }
            else
            {
                selectedOption++;
            }
        }

        public override void DeductIndex()
        {
            if (selectedOption - 1 < 0)
            {
                selectedOption = ItemOptions.Count() - 1;
            }
            else
            {
                selectedOption--;
            }
        }
    }
}

