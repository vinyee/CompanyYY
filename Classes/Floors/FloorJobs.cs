using System;
using System.Collections.Generic;
using CompanyY.Classes.Users;

namespace CompanyY.Classes.Floors
{
    public class FloorJobs
    {
        public FloorJobs()
        {
            
        }

        public void CallForAnInterview(User user, List<User> list)
        {
            
			Console.WriteLine("");

            int option = CompanyEnvironment.Texts.Menu(
                CompanyEnvironment.Usermanager.ShowAlluserDataOption(list));


            CompanyEnvironment.Usermanager.AddUserToList(list[option], 
                                                         CompanyEnvironment.Usermanager.MyWantedList(user));

			Console.Clear();

            Console.WriteLine("Du har nu kallat " + list[option].Name + " "
                              + list[option].Lastname + " till intervju!");
            
            ShowPotentialCandidates(user);
        }

        public void ShowPotentialCandidates(User user)
        {
            string[] Options = new string[2];
            Options[0] = "Kalla på intervju";
            Options[1] = "Ta mig tillbaka till menyn";

            Console.WriteLine("Det här är potentiella arbetssökande:");

            CompanyEnvironment.Usermanager.ShowAllUsersAvailableForSameJob(user, true);

            int menu = CompanyEnvironment.Texts.Menu(Options);

            switch (menu)
            {
                case 0:
                    CallForAnInterview(user, CompanyEnvironment.Usermanager.ShowAllUsersAvailableForSameJob(user));
                    break;

                case 1:
                    CompanyEnvironment.FloorUserLoggedIn.RecruitWelcome(user, true);
                    break;
            }
		}

		public void ShowCandidates(User user)
		{
			string[] Options = new string[2];
			Options[0] = "Kalla på intervju";
			Options[1] = "Ta mig tillbaka till menyn";

            Console.WriteLine("Det här är våra nuvarande arbetssökande:");

            CompanyEnvironment.Usermanager.ShowAllUsersWantedForSameJob(user, true);

			int menu = CompanyEnvironment.Texts.Menu(Options);

			switch (menu)
			{
				case 0:
					CallForAnInterview(user, CompanyEnvironment.Usermanager.ShowAllUsersAvailableForSameJob(user));
					break;

				case 1:
					CompanyEnvironment.FloorUserLoggedIn.RecruitWelcome(user, true);
					break;
			}
		}

        public void PickOrRemoveJob(User user, List<User> list, int job, bool pick = true)
        {
            if (!CompanyEnvironment.Usermanager.UserExist(user, list))
			{
                CompanyEnvironment.Usermanager.AddUser(user,
															list);
				Console.Clear();
				Console.WriteLine("Du har nu ansökt till " +
								  CompanyEnvironment.Titles[job] +
								  "! Nu tar vi dig tillbaka till menyn");
				CompanyEnvironment.FloorUserLoggedIn.UserWelcome(user, true, false);
			}
            else if (CompanyEnvironment.Usermanager.UserExist(user, list))
			{
                CompanyEnvironment.Usermanager.RemoveUser(user, list);
				Console.Clear();
				Console.WriteLine("Du har nu tagit bort din ansökan till " +
								  CompanyEnvironment.Titles[job] +
								  "! Nu tar vi dig tillbaka till menyn");
				CompanyEnvironment.FloorUserLoggedIn.UserWelcome(user, true);
			}

        }

        public void ShowMeMyJobs()
        {
            Console.Clear();
            Console.WriteLine("Kul att du har tagit dig hit, " +
                              "nu ska vi se om du har några intervju att gå på!");


            
        }

        public void ShowMeAvailableJobs(User user)
        {
            bool PickJob = true;
            string[] Options = new string[4];
			Options[3] = "Ta mig tillbaka till menyn";

            Console.WriteLine("Du har följande jobb som du kan söka eller ta bort: " +
                              Environment.NewLine);

            /* Skulle gå att göra snyggare med loop,
             * blir dock jobbigt med olika listor
             * skulle krävas en ny lista som håller alla listor
             */

            if (!CompanyEnvironment.Usermanager.ITJobSearched.Contains(user) &&
                !CompanyEnvironment.Usermanager.ITWanted.Contains(user))
                Options[0] = "Ansök till " + CompanyEnvironment.Titles[0];
            else
            {
                Options[0] = "Ta bort ansökan till " + CompanyEnvironment.Titles[0];
                PickJob = false;
            }
            if (!CompanyEnvironment.Usermanager.ArkJobSearched.Contains(user) &&
                !CompanyEnvironment.Usermanager.ArkWanted.Contains(user))
                Options[1] = "Ansök till " + CompanyEnvironment.Titles[1];
            else
            {
                Options[1] = "Ta bort ansökan till " + CompanyEnvironment.Titles[1];
                PickJob = false;
            }

            if (!CompanyEnvironment.Usermanager.SellerJobSearched.Contains(user) &&
                !CompanyEnvironment.Usermanager.SellerWanted.Contains(user))
                Options[2] = "Ansök till " + CompanyEnvironment.Titles[2];
            else
            {
                Options[2] = "Ta bort ansökan till " + CompanyEnvironment.Titles[2];
                PickJob = false;
            }


			Console.WriteLine(Environment.NewLine);

            int menu = CompanyEnvironment.Texts.Menu(Options);

            switch (menu)
            {
                case 0:
                    PickOrRemoveJob(user, 
                                    CompanyEnvironment.Usermanager.ITJobSearched, menu, PickJob);
                    break;

                case 1:
                    PickOrRemoveJob(user, 
                                    CompanyEnvironment.Usermanager.ArkJobSearched, menu, PickJob);
                    break;

                case 2:
                    PickOrRemoveJob(user, 
                                    CompanyEnvironment.Usermanager.SellerJobSearched, menu, PickJob);
                    break;

                case 3:
                    {
                        Console.Clear();
                        CompanyEnvironment.FloorUserLoggedIn.UserWelcome(user, true);
                        break;
                    }
            }
        }
    }
}
