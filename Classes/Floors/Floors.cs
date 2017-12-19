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


        public void ShowNewCandidates()
        {
            
        }

        public void UserLogOut(User user)
        {
            Console.Clear();
            Console.WriteLine("Du har nu loggat ut, välkommen åter!");
            Main();
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
                        CompanyEnvironment.Userregister.NewRegister();
						break;
					}

				case 1:
                    {
                        Console.Clear();
                        CompanyEnvironment.Userlogin.CheckLogin();
                        break;
                    }
			}
        }

		public void HintRecruit()
		{
			Console.Clear();

            CompanyEnvironment.Texts.Menu(CompanyEnvironment.Titles);
		}
    }
}
