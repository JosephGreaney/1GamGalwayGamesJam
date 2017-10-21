using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public class Character
	{
        private static List<string> names = new List<string> { "Larry", "Bob", "Lucy" };
        private static List<string> weaknesses = new List<string> { "Anime", "Beer", "Food" };
        private string name;
		private string weakness;

        public Character()
		{
            name = names[Random.Range(0, names.Count - 1)];
            weakness = weaknesses[Random.Range(0, weaknesses.Count - 1)];
            names.Remove(name);
            weaknesses.Remove(weakness);
        }

		public string GetName()
		{
			return name;
		}

		public string GetWeakness()
		{
			return weakness;
		}
	}
}