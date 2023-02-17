using System;
namespace Final_Project 
{
public class Menu
	{
		protected List<string> Options { get; set; }
		protected string Prompt { get; set; }
		protected int selectedOption { get; set; }
        protected string Image { get; set; } = "";

		public Menu(string prompt, List<string> options)
		{
			Prompt = prompt;
			Options = options;
		}

        public Menu(string prompt, List<string> options, string image)
        {
            Prompt = prompt;
            Options = options;
            Image = image;
        }


        public Menu(string prompt, string image)
        {
            Prompt = prompt;
        }

        public Menu(string prompt)
        {
            Prompt = prompt;
        }

        /*-----------------------------------
           Main Function
        -----------------------------------*/

        public virtual string RunMenu()
		{
			bool looping = true;
            //int optionIndex = 0;

            
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
                        return Options[selectedOption];
                }
            }
            return null;
        }

        /*-----------------------------------
			Helper Functions 
		 -----------------------------------*/

        public virtual void DisplayOptions(int selectedOptionIndex)
		{
            if (Image != "")
            {
                Console.WriteLine(Image);
            }
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            Console.WriteLine($"\t{Prompt}");
            Console.WriteLine("\t═════════════════════════════════════════");
            for (int i = 0; i < Options.Count(); i++)
			{
				if(i == selectedOptionIndex)
				{
                    Console.WriteLine($"\t{i + 1}. {Options[i]}", Console.ForegroundColor = ConsoleColor.Cyan);
                }
				else
				{
                    Console.WriteLine($"\t{i + 1}. {Options[i]}");
                }
				Console.ResetColor();
			}

            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
        }

		public virtual void AddIndex()
		{
			if (selectedOption + 1 > Options.Count() - 1)
			{
                selectedOption = 0;
			}
			else
			{
                selectedOption++;
			}
		}

        public virtual void DeductIndex()
        {
            if (selectedOption - 1 < 0)
            {
                selectedOption = Options.Count() - 1;
            }
            else
            {
                selectedOption--;
            }
        }


    }
}

