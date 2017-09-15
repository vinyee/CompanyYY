using System;
namespace CompanyY.Classes.Users
{
    public class UserRegister
    {
        public UserRegister()
        {
        }

        public void Register(User candidate, int level = 0, bool finished = false)
        {
            switch (level)
            {
                case 0:
                    RegisterName(candidate, level, finished);
                    break;

                case 1:
                    RegisterLastname(candidate, level, finished);
                    break;

                case 2:
                    RegisterAge(candidate, level, finished);
                    break;

                case 3:
                    RegisterTitle(candidate, level, finished);
                    break;
            }
        }

        public bool ValidName(string name)
        {
            if (name.Length > 2 && name.Length < 10)
                if (CompanyEnvironment.Texts.OnlyLetters(name))
                    return true;

            return false;
        }

        public void RegisterFinished(User candidate)
        {
            string choice;

            Console.Clear();
            Console.WriteLine("Du har nu registrerat dig, innan vi går vidare " +
                              "kommer vi att visa din data, är det något du vill ändra på? " +
                              "Skriv fortsätt annars skriv ändra." + 
                              Environment.NewLine);

            CompanyEnvironment.Usermanager.ShowCandidate(candidate);

            choice = Console.ReadLine().ToLower();

            while (true)
            {
                if (choice.ToLower() == "fortsätt")
                {
                    
                    CompanyEnvironment.Usermanager.AddCandidate(candidate);
                    CompanyEnvironment.Floor.UserLoginRegister();
                    return;
                }
                else if (choice.ToLower() == "ändra")
                {
                    while (true)
                    {
                        Console.Clear();
                        CompanyEnvironment.Usermanager.ShowCandidate(candidate);

                        Console.WriteLine("Vad vill du ändra? " + Environment.NewLine +
                                          "namn, efternamn, födelseår, titel" + 
                                          Environment.NewLine);

                        Console.WriteLine("Ifall du är klar, skriv fortsätt" + 
                                          Environment.NewLine);

                        switch (Console.ReadLine().ToLower())
                        {
                            case "fortsätt":
                            case "klar":
                                {
                                    CompanyEnvironment.Usermanager.AddCandidate(candidate);

                                    Console.Clear();
                                    Console.WriteLine("Grattis du är nu medlem, " +
                                                      "du kan logga in!" + 
                                                      Environment.NewLine);
                                    
                                    CompanyEnvironment.Floor.UserLoginRegister();
                                }
								return;

                            case "namn":
                                RegisterName(candidate, 0, true);
                                break;

                            case "efternamn":
                                RegisterLastname(candidate, 1, true);
                                break;

                            case "födelseår":
                                RegisterAge(candidate, 2, true);
                                break;

                            case "titel":
                                RegisterTitle(candidate, 3, true);
                                break;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Du kan bara välja mellan fortsätt och ändra just nu.");
                    Console.WriteLine("Vill du ändra eller fortsätta? Skriv " +
                                      "fortsätt annars skriv ändra" + 
                                      Environment.NewLine);
                }
            }

        }

        public void RegisterTitle(User candidate, int level, bool finished = false)
        {
            Console.WriteLine("Är du en utvecklare, arkitekt eller säljare?");
            string title = Console.ReadLine();

            if (title.ToLower() != "utvecklare" &&
                title.ToLower() != "arkitekt" &&
                title.ToLower() != "säljare")
            {
                Console.WriteLine("Något blev fel, " +
                    "se till att du skriver antingen utvecklare, arkitekt eller säljare!");

                Register(candidate, level, finished);
            }
            else
            {
                candidate.Title = CompanyEnvironment.Texts.ToUpperFirstLetter(title);

                if (!finished)
                    RegisterFinished(candidate);
            }
        }

        public void RegisterAge(User candidate, int level, bool finished = false)
        {
            int yob;
			
            Console.WriteLine("Vilket år är du född då?");

            int.TryParse(Console.ReadLine(), out yob);

            if (CompanyEnvironment.Texts.ValidAge(yob))
            {
                candidate.YearofBirth = yob;

				if (!finished)
				{
					level++;
					Register(candidate, level);
				}
            }
            else
            {
				Console.WriteLine("Något blev fel, " +
				  "se till att inga tecken och bokstäver finns med!");

                Register(candidate, level, finished);
            }
        }

        public void RegisterName(User candidate, int level, bool finished = false)
        {
            string name;

            Console.WriteLine("Vad heter du?");

            name = Console.ReadLine();

			if (!ValidName(name))
			{
				Console.WriteLine("Något blev fel, " +
								  "se till att inga tecken och siffror finns med!");

                Register(candidate, level, finished);
			}
			else
			{
                candidate.Name = CompanyEnvironment.Texts.ToUpperFirstLetter(name);

                if (!finished)
                {
                    level++;
                    Register(candidate, level);
                }
			}
        }

		public void RegisterLastname(User candidate, int level, bool finished = false)
		{
			string name;

            Console.WriteLine("Vad heter du i efternamn?");

			name = Console.ReadLine();

			if (!ValidName(name))
			{
				Console.WriteLine("Något blev fel, " +
								  "se till att inga tecken och siffror finns med!");

                Register(candidate, level, finished);
			}
			else
			{
                candidate.Lastname = CompanyEnvironment.Texts.ToUpperFirstLetter(name);
				
                if (!finished)
				{
					level++;
					Register(candidate, level);
				}
			}
		}
    }
}
