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


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>

        public string Name
        {
            get { return _name; }
			set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        /// <value>The lastname.</value>

		public string Lastname
		{
            get { return _lastname; }
            set { _lastname = value; }
		}

        /// <summary>
        /// Gets or sets the yearof birth.
        /// </summary>
        /// <value>The yearof birth.</value>

        public int YearofBirth
		{
            get { return _yob; }
            set { _yob = value; }
		}

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CompanyY.Classes.Users.User"/> is recruit.
        /// </summary>
        /// <value><c>true</c> if recruit; otherwise, <c>false</c>.</value>

        public bool Recruit
        {
            get { return _recruit; }
            set { _recruit = value; }
        }
    }
}
