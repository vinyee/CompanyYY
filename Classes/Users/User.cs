using System;
namespace CompanyY.Classes.Users
{
    public class User
    {
        private string _name;
        private string _lastname;
        private string _title;
        private bool _recruit;

        //year of birth
        private int _yob;

        public User()
        {
            
        }

        public User(string name, string lastname, int yob, string title, bool recruit = false)
        {
            _name = name;
            _lastname = lastname;
            _title = title;
            _yob = yob;
            _recruit = recruit;
        }

        public string Name
        {
            get { return _name; }
			set { _name = value; }
        }

		public string Lastname
		{
            get { return _lastname; }
            set { _lastname = value; }
		}

        public int YearofBirth
		{
            get { return _yob; }
            set { _yob = value; }
		}

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public bool Recruit
        {
            get { return _recruit; }
            set { _recruit = value; }
        }
    }
}
