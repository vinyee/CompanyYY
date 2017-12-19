using System;
namespace CompanyY.Classes.Users
{
    public class UserRegister
    {
        public UserRegister()
        {
        }

		public void NewRegister()
		{
            User user = CompanyEnvironment.Usermanager.RegisterNewUser();

			CompanyEnvironment.Userregister.Register(user, 0, false);
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

        public void RegisterFinished(User user)
        {
            Console.Clear();
            Console.WriteLine("Du har nu registrerat dig, innan vi går vidare " +
                              "kommer vi att visa din data, är det något du vill ändra på? " +
                              Environment.NewLine);

            CompanyEnvironment.Usermanager.ShowUserData(user);

			string[] Options = new string[2];
			Options[0] = "Jag är klar, ta mig vidare!";
			Options[1] = "Jag tror jag vill ändra på något mer";

			int option = CompanyEnvironment.Texts.Menu(Options);

            if (option == 0)
            {
                Console.Clear();
                CompanyEnvironment.Usermanager.AddUser(user, CompanyEnvironment.Usermanager.Users);
                CompanyEnvironment.Floor.UserLoginRegister();
                return;
            }
            else
            {
                //Loop så man kan ändra sina uppgifter tills man är klar
                while (true)
                {
					string[] Alts = new string[5];
					Alts[0] = "Namn";
					Alts[1] = "Efternamn";
					Alts[2] = "Födelseår";
					Alts[3] = "Titel";
					Alts[4] = "Jag är klar!";

                    Console.Clear();
                    CompanyEnvironment.Usermanager.ShowUserData(user);

					int alts = CompanyEnvironment.Texts.Menu(Alts);

                    switch (alts)
                    {
                        case 0:
                            RegisterName(user, 0, true);
                            break;

                        case 1:
                            RegisterLastname(user, 1, true);
                            break;

                        case 2:
                            RegisterAge(user, 2, true);
                            break;

                        case 3:
                            RegisterTitle(user, 3, true);
                            break;

						case 4:
							{
                                //Lägg till i listan på ny medlem
                                CompanyEnvironment.Usermanager.AddUser(user, 
                                                                       CompanyEnvironment.Usermanager.Users);
								Console.Clear();
								Console.WriteLine("Grattis du är nu medlem, " +
												  "du kan logga in!" +
												  Environment.NewLine);

								CompanyEnvironment.Floor.UserLoginRegister();
							}
							return;
                    }
                }
            }
        }

        public void RegisterTitle(User user, int level, bool finished = false)
        {
            Console.WriteLine("Är du en utvecklare, arkitekt eller säljare?");

            int option = CompanyEnvironment.Texts.Menu(CompanyEnvironment.Titles);

            user.Title = CompanyEnvironment.Titles[option];

            if (!finished)
                RegisterFinished(user);

        }

        public void RegisterAge(User user, int level, bool finished = false)
        {
            int yob;
			
            Console.WriteLine("Vilket år är du född då?");

            int.TryParse(Console.ReadLine(), out yob);

            if (CompanyEnvironment.Texts.ValidAge(yob))
            {
                user.YearofBirth = yob;

				if (!finished)
				{
					level++;
					Register(user, level);
				}
            }
            else
            {
				Console.WriteLine("Något blev fel, " +
				  "se till att inga tecken och bokstäver finns med!");

                Register(user, level, finished);
            }
        }

        public void RegisterName(User user, int level, bool finished = false)
        {
            string name;

            Console.WriteLine("Vad heter du?");

            name = Console.ReadLine().ToLower();

			if (!CompanyEnvironment.Texts.ValidName(name))
			{
				Console.WriteLine("Något blev fel, " +
								  "se till att inga tecken och siffror finns med!");

                Register(user, level, finished);
			}
			else
			{
                user.Name = CompanyEnvironment.Texts.ToUpperFirstLetter(name);

                if (!finished)
                {
                    level++;
                    Register(user, level);
                }
			}
        }

		public void RegisterLastname(User user, int level, bool finished = false)
		{
			string name;

            Console.WriteLine("Vad heter du i efternamn?");

            name = Console.ReadLine().ToLower();

            if (!CompanyEnvironment.Texts.ValidName(name))
			{
				Console.WriteLine("Något blev fel, " +
								  "se till att inga tecken och siffror finns med!");

                Register(user, level, finished);
			}
			else
			{
                user.Lastname = CompanyEnvironment.Texts.ToUpperFirstLetter(name);
				
                if (!finished)
				{
					level++;
					Register(user, level);
				}
			}
		}
    }
}
