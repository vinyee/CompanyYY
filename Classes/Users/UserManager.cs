using System;
using System.Collections.Generic;

namespace CompanyY.Classes.Users
{
    public class UserManager
    {
        //Listan på medlemmar
        public List<User> Users;

        //Listan på folk som söker jobb
        public List<User> UserJobSearching;

        //Listan på rekryterare
        public List<User> Recruiter;

        //Listan på folk som har sökt jobb till rollerna
        public List<User> ITJobSearched;
        public List<User> ArkJobSearched;
        public List<User> SellerJobSearched;

        //Listan när en rekryterare har lagt till för intervju
        public List<User> ITWanted;
        public List<User> ArkWanted;
        public List<User> SellerWanted;

        //Listan för när man gjort bra på intervjun aka viktiga kandidater
        public List<User> ITImportant;
        public List<User> ArkImportant;
        public List<User> SellerImportant;

        public UserManager()
        {
            Users = new List<User>();

            UserJobSearching = new List<User>();
            Recruiter = new List<User>();

            ITJobSearched = new List<User>();
            ArkJobSearched = new List<User>();
            SellerJobSearched = new List<User>();

            ITWanted = new List<User>();
            ArkWanted = new List<User>();
            SellerWanted = new List<User>();

            ITImportant = new List<User>();
            ArkImportant = new List<User>();
            SellerImportant = new List<User>();
        }

        public User ControlUser(string name, int yob, List<User> list)
        {
            if (list.Count > 0)
            {
                foreach (var candidate in list)
                {
                    if (candidate != null)
                        if (candidate.Name.ToLower() == name.ToLower() && candidate.YearofBirth == yob)
                            return candidate;
                }
            }
            return null;
        }

        public void AddUserToList(User user, List<User> list)
        {
            switch (user.Title.ToLower())
            {
                case "utvecklare":
                    AddUser(user, ITWanted);
                    break;

                case "arkitekt":
                    AddUser(user, ArkWanted);
                    break;

                case "säljare":
                    AddUser(user, SellerWanted);
                    break;
            }
        }

        public bool UserExist(User user, List<User> list)
        {
            if (list.Contains(user))
                return true;

            return false;
        }

        /*
        public void ShowAllUsersData(List<User> list, bool usersOnly = true, List<User> ignorelist = null)
        {
            if (list.Count > 0)
            {
                if (ignorelist != null)
                {
                    foreach (var user in list)
                        if (usersOnly)
                        {
                            if (!user.Recruit && !ignorelist.Contains(user))
                                ShowUserData(user);
                        }
                        else
                        {
                            if (!ignorelist.Contains(user))
                                ShowUserData(user);
                        }
                }
                else
                {
                    foreach (var user in list)
                        if (usersOnly)
                        {
                            if (!user.Recruit)
                                ShowUserData(user);
                        }
                        else
                        {
                            ShowUserData(user);
                        }
                }
            }
        }
        */

        public List<User> ShowAllUsersAvailableForSameJob(User user, bool showdata = false)
        {
            List<User> Temp = CompanyEnvironment.Usermanager.UserJobSearching;

            foreach (User target in CompanyEnvironment.Usermanager.MyWantedList(user))
			    if (Temp.Contains(target))
                    Temp.Remove(target);


            foreach (User target in CompanyEnvironment.Usermanager.MyCandidatesList(user))
				if (Temp.Contains(target))
					Temp.Remove(target);
            
            if (showdata)
            {
                foreach (User target in Temp)
                    ShowUserData(target);
            }

            return Temp;
        }

		public void ShowMeMyJobs(User user, bool showdata = false)
		{
            if (UserExist(user, CompanyEnvironment.Usermanager.ArkWanted))
                Console.WriteLine("")

			foreach (User target in CompanyEnvironment.Usermanager.MyWantedList(user))
				if (Temp.Contains(target))
					Temp.Remove(target);


			foreach (User target in CompanyEnvironment.Usermanager.MyCandidatesList(user))
				if (Temp.Contains(target))
					Temp.Remove(target);

			if (showdata)
			{
				foreach (User target in Temp)
					ShowUserData(target);
			}

			return Temp;
		}

        public List<User> ShowAllUsersWantedForSameJob(User user, bool showdata = false)
        {
            foreach (User target in CompanyEnvironment.Usermanager.MyCandidatesList(user))
                ShowUserData(target);

            return CompanyEnvironment.Usermanager.MyCandidatesList(user);
            
        }

		public string[] ShowAlluserDataOption(List<User> list, bool usersOnly = true)
		{
            //usersOnly ifall vi bara vill visa upp arbetssökande och inte rekryterare
            string[] args = new string[list.Count];

			if (list.Count > 0)
			{
                for (int x = 0; x < list.Count; x++)
                    args[x] = list[x].Name + " " +
                                     list[x].Lastname;
			}

            return args;
		}

		public void ShowUserData(User user)
		{
			//usersOnly ifall vi bara vill visa upp arbetssökande och inte rekryterare

			if (user != null)
			    Console.WriteLine("Förnamn: " + user.Name + "\n" +
							  "Efternamn: " + user.Lastname + "\n" +
							  "Ålder: " + CompanyEnvironment.Texts.GetAge(user.YearofBirth) + "\n" +
							  "Inriktning: " + user.Title + "\n\n");
		}

		public int GetCountUsers(List<User> list, bool usersOnly = true, List<User> ignorelist = null)
		{
            int count = 0;

            if (!usersOnly && ignorelist == null)
                return list.Count;

            foreach (var user in list)
            {
                if (user != null)
                    if (!user.Recruit)
                        if (ignorelist != null)
                        {
                            if (!ignorelist.Contains(user))
                                count++;
                        }
                        else
                            count++;
            }

            return count;
		}

        public void RemoveUser(string name, string lastname, List<User> list)
        {
            //extracheck, fick error tidigare
            if (list.Count > 0)
            {
                foreach (var user in list)
                {
                    if (user != null)
                        if (user.Name.ToLower() == name.ToLower() 
                            && user.Lastname.ToLower() == lastname.ToLower())
                        {
                            /* så fort vi har hittat vår candidate kör vi break
                            * annars kraschar foreachen för vi loopar fortfarande
                            * medan vi ändrar listan samtidigt
                            */

                            list.Remove(user);
                            break;
                        }
                }
            }
        }

        public List<User> MyWantedList(User user)
        {
            switch (user.Title.ToLower())
            {
                case "utvecklare":
                    return ITWanted;

                case "arkitekt":
                    return ArkWanted;

                case "säljare":
                    return SellerWanted;
            }

            return null;
        }

		public List<User> MyImporttantList(User user)
		{
			switch (user.Title.ToLower())
			{
				case "utvecklare":
                    return ITImportant;

				case "arkitekt":
                    return ArkImportant;

				case "säljare":
                    return SellerImportant;
			}

			return null;
		}

		public List<User> MyCandidatesList(User user)
		{
			switch (user.Title.ToLower())
			{
				case "utvecklare":
                    return ITJobSearched;

				case "arkitekt":
                    return ArkJobSearched;

				case "säljare":
                    return SellerJobSearched;
			}

			return null;
		}

        public void RemoveUser(User user, List<User> list)
        {
            //extracheck, fick error tidigare
            if (list.Count > 0)
                if (list.Contains(user))
                    list.Remove(user);
        }
        public void AddUser(User user, List<User> list)
        {
            if (user != null)
                if (!list.Contains(user))
                    list.Add(user);
        }

        public User RegisterNewUser()
        {
            User user = new User();
            return user;
        }
    }
}
