using System;
using System.Collections.Generic;

namespace CompanyY.Classes.Users
{
    public class UserManager
    {
        List<User> Candidates;

        public UserManager()
        {
            Candidates = new List<User>();
        }

        /// <summary>
        /// Gets the candidate.
        /// </summary>
        /// <returns>The candidate.</returns>
        /// <param name="name">Name.</param>
        /// <param name="lastname">Lastname.</param>

        public User GetCandidate(string name, int yob)
        {
            foreach (var candidate in Candidates)
            {
                if (candidate != null)
                    if (candidate.Name == name && candidate.YearofBirth == yob)
                        return candidate;
            }

            return null;
        }

        /// <summary>
        /// Gets all candicates.
        /// </summary>
        /// <returns>The all candicates.</returns>
       
        public List<User> GetAllCandicates()
        {
            if (Candidates.Count > 0)
                return Candidates;

            return null;
        }

        /// <summary>
        /// Shows all candidates.
        /// </summary>

        public void ShowAllCandidates()
        {
            Console.WriteLine("");

            foreach (var candidate in Candidates)
                Console.WriteLine("Förnamn: " + candidate.Name + "\n" +
                                  "Efternamn: "  + candidate.Lastname + "\n" +
                                  "Ålder: " + CompanyEnvironment.Texts.GetAge(candidate.YearofBirth) + "\n" +
                                  "Inriktning: " + candidate.Title + "\n\n");
        }

		public void ShowCandidate(User candidate)
		{
            if (candidate != null)
			    Console.WriteLine("Förnamn: " + candidate.Name + "\n" +
							  "Efternamn: " + candidate.Lastname + "\n" +
							  "Ålder: " + CompanyEnvironment.Texts.GetAge(candidate.YearofBirth) + "\n" +
							  "Inriktning: " + candidate.Title + "\n\n");
		}

        /// <summary>
        /// Gets the count candidates.
        /// </summary>
        /// <returns>The count candidates.</returns>

		public int GetCountCandidates()
		{
            return Candidates.Count;
		}


        /// <summary>
        /// Removes the candidate.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="lastname">Lastname.</param>

        public void RemoveCandidate(string name, string lastname)
        {
			foreach (var candidate in Candidates)
			{
                if (candidate != null)
                    if (candidate.Name == name && candidate.Lastname == lastname)
                        Candidates.Remove(candidate);
			}
        }

        /// <summary>
        /// Adds the candidate.
        /// </summary>
        /// <param name="candicate">Candicate.</param>

        public void AddCandidate(User candicate)
        {
            if (candicate != null)
                if (!Candidates.Contains(candicate))
                    Candidates.Add(candicate);
        }

        public User RegisterCandidate()
        {
            User user = new User();
            return user;
        }
    }
}
