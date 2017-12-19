using System;
using CompanyY.Classes.Floors;
using CompanyY.Classes.Users;
using CompanyY.Utilities;

namespace CompanyY
{
    public static class CompanyEnvironment
    {
        public static Texts Texts = new Texts();

        public static UserManager Usermanager = new UserManager();

        public static UserLogin Userlogin = new UserLogin();
        public static UserRegister Userregister = new UserRegister();

        public static Floors Floor = new Floors();
        public static FloorJobs FloorJobs = new FloorJobs();
        public static FloorLoggedIn FloorUserLoggedIn = new FloorLoggedIn();

        public static string[] Titles = new string[3];

        public static void Start()
        {
            Titles[0] = "Utvecklare";
            Titles[1] = "Arkitekt";
            Titles[2] = "Säljare";

            User user2 = new User()
            {
                Name = "Olle",
                Lastname = "Larson",
                Title = "Säljare",
                YearofBirth = 1985,
                Recruit = false
            };

            User user1 = new User()
            {
                Name = "Bjorn",
                Lastname = "Mohammed",
                Title = "Arkitekt",
                YearofBirth = 1999,
                Recruit = false
            };

            User user = new User()
            {
                Name = "Sven",
                Lastname = "Goran",
                Title = "Utvecklare",
                YearofBirth = 1960,
                Recruit = true
            };

            Usermanager.AddUser(user1, CompanyEnvironment.Usermanager.Users);
            Usermanager.AddUser(user2, CompanyEnvironment.Usermanager.Users);
            Usermanager.AddUser(user1, CompanyEnvironment.Usermanager.UserJobSearching);

            Usermanager.AddUser(user, CompanyEnvironment.Usermanager.Users);
            Usermanager.AddUser(user, CompanyEnvironment.Usermanager.Recruiter);

            Texts.WelcomeMessage();
            Floor.Main();
        }
    }
}
