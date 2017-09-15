using System;
using CompanyY.Classes.Floors;
using CompanyY.Classes.Users;
using CompanyY.Utilities;

namespace CompanyY
{
    public static class CompanyEnvironment
    {
        public static UserRegister Userregister = new UserRegister();
        public static Texts Texts = new Texts();
        public static Floors Floor = new Floors();
        public static UserManager Usermanager = new UserManager();
        public static User user = null;

        public static void Start()
        {
            user = new User();
            user.Name = "Vincent";
            user.Lastname = "Yeemayor";
            user.Title = "Utvecklare";
            user.YearofBirth = 1991;

            Usermanager.AddCandidate(user);

            Texts.WelcomeMessage();
            Floor.Main();
        }
    }
}
