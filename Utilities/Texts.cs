using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CompanyY.Utilities
{
    public class Texts
    {

        public Texts()
        {
        }

        public int GetAge(int year)
        {
            return DateTime.Now.Year - year;
        }

        public bool ValidAge(int year)
        {
            if (year > (DateTime.Now.Year - 80) && year < DateTime.Now.Year)
                return true;

            return false;
        }

        public string ToUpperFirstLetter(string input)
        {
			//https://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance

			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        public int GiveInt(string input)
        {
            int output;
            int.TryParse(input, out output);

            return output;
        }

        public bool OnlyLetters(string input)
        {
            //https://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp

            if (Regex.IsMatch(input, @"^[a-öA-Ö]+$"))
                return true;

            return false;
        }

        public void WelcomeMessage()
        {
			Console.WriteLine("\t\t\tCompany Environment" +
							  Environment.NewLine +
							  Environment.NewLine);
            
            Console.WriteLine("Välkommen till Company Environment. " +
                              "I vår Environment kan du som rekryterare lägga " +
                              "till och ta bort kandidater. Söka upp specfika " +
                              "roller för att lista vilka kandidater som finns " +
                              "och eventuellt spara ihop listan i en fil om så " +
                              "önskas." +
                              Environment.NewLine);
            
            Console.WriteLine("Som kandidat kan du ifall en rekryterare har lagt " +
                              "till dig som intressant påbörja intervju. Har du " +
                              "redan varit på intervjun är du välkommen för nästa " +
                              "del som testar dina kunskaper inom området " +
                              "som du söker." + Environment.NewLine);

            Console.WriteLine("Är du varken en rekryterare eller kandidat? " +
                              "Ingen fara, då kan du tipsa om intressanta " +
                              "kandidater till våra rekryterare!" + 
                              Environment.NewLine);
        }

		public int Menu(string[] inArray)
		{
			//Källa
			//https://gist.github.com/Brogie/34dba368a34c57049b46

			bool loopComplete = false;
			int topOffset = Console.CursorTop;
			int bottomOffset = 0;
			int selectedItem = 0;
			ConsoleKeyInfo kb;

			Console.CursorVisible = false;

			/**
             * Drawing phase
             * */
			while (!loopComplete)
			{//This for loop prints the array out
				for (int i = 0; i < inArray.Length; i++)
				{
					if (i == selectedItem)
					{//This section is what highlights the selected item
						Console.BackgroundColor = ConsoleColor.Gray;
						Console.ForegroundColor = ConsoleColor.Black;
						Console.WriteLine("- " + inArray[i]);
						Console.ResetColor();
					}
					else
					{//this section is what prints unselected items
						Console.WriteLine("- " + inArray[i]);
					}
				}

				bottomOffset = Console.CursorTop;

				/*
                 * User input phase
                 * */

				kb = Console.ReadKey(true); //read the keyboard

				switch (kb.Key)
				{ //react to input
					case ConsoleKey.UpArrow:
						if (selectedItem > 0)
						{
							selectedItem--;
						}
						else
						{
							selectedItem = (inArray.Length - 1);
						}
						break;

					case ConsoleKey.DownArrow:
						if (selectedItem < (inArray.Length - 1))
						{
							selectedItem++;
						}
						else
						{
							selectedItem = 0;
						}
						break;

					case ConsoleKey.Enter:
                        {
                            loopComplete = true;
                        }
						break;
				}
				//Reset the cursor to the top of the screen
				Console.SetCursorPosition(0, topOffset);
			}
			//set the cursor just after the menu so that the program can continue after the menu
			Console.SetCursorPosition(0, bottomOffset);

			Console.CursorVisible = true;
			return selectedItem;
		}
    }
}
