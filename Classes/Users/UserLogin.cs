using System;
namespace CompanyY.Classes.Users
{
    public class UserLogin
    {
        public UserLogin()
        {
        }

		public void CheckLogin()
		{
			string name = "";
			int yob = 0;
			int level = 0;

			Console.WriteLine("Nu ska vi logga in, då behöver vi två av dina " +
							  "uppgifter för att kontrollera vem du är."
							  + Environment.NewLine);

			//loop tills namn och födelseår är rätt skrivet
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

		public void TryLogin(string name, int yob)
		{
            User user = CompanyEnvironment.Usermanager.ControlUser(name, yob, 
                                                                   CompanyEnvironment.Usermanager.Users);

			User recruit = CompanyEnvironment.Usermanager.ControlUser(name, yob,
                                                                       CompanyEnvironment.Usermanager.Recruiter);


            if (recruit != null)
                CompanyEnvironment.FloorUserLoggedIn.RecruitWelcome(recruit);
            else if (user != null)
                CompanyEnvironment.FloorUserLoggedIn.UserWelcome(user);
			else
			{
				Console.Clear();
				Console.WriteLine("Din användare kunde inte hittas, " +
								  "vill du försöka igen eller gå tillbaka till menyn?");

				string[] Options = new string[2];
				Options[0] = "Jag vill försöka igen";
				Options[1] = "Ta mig tillbaka till menyn istället";

				int option = CompanyEnvironment.Texts.Menu(Options);

                if (option == 0)
                {
                    Console.Clear();
                    CheckLogin();
                    return;
                }
                else
                {
                    Console.Clear();
                    CompanyEnvironment.Floor.Main();
                }
			}
		}
    }
}
