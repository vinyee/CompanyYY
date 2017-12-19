using System;
using CompanyY.Classes.Users;

namespace CompanyY.Classes.Floors
{
    public class FloorLoggedIn
    {
        public FloorLoggedIn()
        {
        }

		public void RecruitWelcome(User user, bool loggedIn = false)
		{
			Console.Clear();

            if (!loggedIn)
            {
                Console.WriteLine("Välkommen " + user.Name + "!");
                Console.WriteLine("Här kan du som rekryterare hitta potentiella arbetssökare, " +
                                  "kolla vilka som har sökt jobb samt kalla till intervju!" +
                                  Environment.NewLine);
            }

			string[] Options = new string[4];
			Options[0] = "Visa mig potentiella kandidater";
			Options[1] = "Visa mig vilka som har sökt jobb till oss";
			Options[2] = "Kalla på intervju";
            Options[3] = "Logga ut";

			int option = CompanyEnvironment.Texts.Menu(Options);

			switch (option)
			{
				case 0:
					{
						Console.Clear();
                        CompanyEnvironment.FloorJobs.ShowPotentialCandidates(user);
						break;
					}

				case 1:
					{
						Console.Clear();
						CompanyEnvironment.FloorJobs.ShowCandidates(user);
						break;
					}

				case 2:
					break;

				case 3:
					CompanyEnvironment.Floor.UserLogOut(user);
					break;
			}
		}

		public void UserWelcome(User user, bool loggedIn = false, bool clear = false)
		{
            if (clear)
				Console.Clear();

            if (!loggedIn)
            {
                Console.WriteLine("Välkommen " + user.Name + "!");
                Console.WriteLine("Här är din sida med flera alternativ " +
                                  "som gör att du enkelt håller dig själv uppdaterad." +
                                  Environment.NewLine);
                Console.WriteLine("Kanske har du tur och en intervju väntar på dig? " +
                                  "Är du redo så är det bara att påbörja :)" +
                                  Environment.NewLine);
            }

			string[] Options = new string[4];
			Options[0] = "Visa mig alla jobb, både lediga och sökta";
			Options[1] = "Har jag några intervjuer att gå på";
            Options[2] = "Finns det några jobb som har hört av sig efter intervju";
            Options[3] = "Logga ut";

			int option = CompanyEnvironment.Texts.Menu(Options);

            switch (option)
            {
                case 0:
                    {
                        Console.Clear();
                        CompanyEnvironment.FloorJobs.ShowMeAvailableJobs(user);
                        break;
                    }

                case 1:

                    CompanyEnvironment.Usermanager.ShowMeMyJobs(user);
                    break;

                case 2:
                    break;

                case 3:
                    CompanyEnvironment.Floor.UserLogOut(user);
                    break;
            }

		}
    }
}
