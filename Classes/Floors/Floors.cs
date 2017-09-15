using System;
using CompanyY.Classes.Users;

namespace CompanyY.Classes.Floors
{
    public class Floors
    {
        public Floors()
        {
        }

		public void Main()
		{
			string[] Options = new string[2];
			Options[0] = "Ta mig vidare";
			Options[1] = "Tipsa rekryterare";

            int option = CompanyEnvironment.Texts.Menu(Options);

			switch (option)
			{
				case 0:
                    {
                        Console.Clear();
                        UserLoginRegister();
                        break;
                    }

                case 1:
                    HintRecruit();
					break;
			}
		}

		public void RecruitLoggedIn()
		{
            Console.Clear();
			string[] Options = new string[2];
			Options[0] = "Lista potentiella kandidater";
			Options[1] = "Lista nuvarande kandidater";

            int option = CompanyEnvironment.Texts.Menu(Options);

			switch (option)
			{
				case 0:
					ShowNewCandidates();
					break;

				case 1:
					ShowAcceptedCandidates();
					break;
			}
		}

        public void ShowNewCandidates()
        {
            
        }

        public void ShowAcceptedCandidates()
        {
            Console.Clear();
            int Candidates = CompanyEnvironment.Usermanager.GetCountCandidates();

            if (Candidates == 1)
				Console.WriteLine("Vi har för nuvarande: " + Candidates
				 + " kandidat");
            else
                Console.WriteLine("Vi har för nuvarande: " + Candidates
                             + " kandidater");

            CompanyEnvironment.Usermanager.ShowAllCandidates();
        }

        public void UserLoginRegister()
        {
			string[] Options = new string[2];
			Options[0] = "Registrera dig";
			Options[1] = "Logga in";

			int option = CompanyEnvironment.Texts.Menu(Options);

			switch (option)
			{
				case 0:
					{
						Console.Clear();
						UserRegister();
						break;
					}

				case 1:
                    {
                        Console.Clear();
                        UserLogin();
                        break;
                    }
			}
        }

        public void UserRegister()
        {
            User Candidate = CompanyEnvironment.Usermanager.RegisterCandidate();

            CompanyEnvironment.Userregister.Register(Candidate, 0, false);
        }

        public void TryLogin(string name, int yob)
        {
            User user = CompanyEnvironment.Usermanager.GetCandidate(name, yob);

            if (user != null)
            {
                //Sparar denna session = vi är inloggad som hen
                CompanyEnvironment.user = user;
				Console.Clear();
				Console.WriteLine("Välkommen " + user.Name + "!");

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Din användare kunde inte hittas, " +
                                  "vill du försöka igen eller gå tillbaka till menyn?");
                while (true)
                {
                    switch (Console.ReadLine())
                    {
                        case "försök igen":
                        case "försöka igen":
                                UserLogin();
                            break;

                        case "tillbaka":
                        case "gå tillbaka":
                            {
                                CompanyEnvironment.Floor.Main();
                            }
                            break;
                    }
                }
            }
        }

		public void UserLogin()
		{
            string name = "";
            int yob = 0;
            int level = 0;

			Console.WriteLine("Nu ska vi logga in, då behöver vi två av dina " +
                              "uppgifter för att kontrollera vem du är."
                              + Environment.NewLine);

            while (true)
            {
                switch (level)
                {
                    case 0:
                        {
                            Console.WriteLine("Vad heter du?");
                            name = Console.ReadLine();

                            if (CompanyEnvironment.Texts.OnlyLetters(name))
                                level = 1;
                            else
                            {
								Console.WriteLine("Något blev fel, ditt namn får inte " +
	                                "innehålla siffror eller tecken. Försök igen");

								level = 0;
                            }
                        }
                        break;

                    case 1:
                        {
                            Console.WriteLine("Vilket år är du född?");
                            yob = CompanyEnvironment.Texts.GiveInt(Console.ReadLine());

                            if (CompanyEnvironment.Texts.ValidAge(yob))
                            {
                                TryLogin(name, yob);
                                return;
                            }
                            else
                            {
								Console.WriteLine("Något blev fel, ditt födelseår får inte " +
	                                "innehålla bokstäver eller tecken. Försök igen");

                                level = 1;
                            }
                        }
                        break;

                }
            }
		}

		public void HintRecruit()
		{
			Console.Clear();
			string[] Options = new string[3];
			Options[0] = "Arkitekt";
			Options[1] = "Utvecklare";
            Options[2] = "Säljare";

            CompanyEnvironment.Texts.Menu(Options);
		}
    }
}
