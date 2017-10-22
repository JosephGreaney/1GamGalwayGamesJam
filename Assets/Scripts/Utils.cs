using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Character
    {
        private static List<string> names = new List<string> { "Larry", "Bob", "Lucy" };
        private static List<string> weaknesses = new List<string> { "Anime", "BeerItem", "Food" };
        private string name;
        private string weakness;
        Dictionary<string, string[]> paths = new Dictionary<string, string[]>{
            {"v01",new string[]{"v02","v03","v04","v06","v11"}},
            {"v02",new string[]{"v01","v04","v05","v11","v12"}},
            {"v03",new string[]{"v01","v04","v09","v11"}},
            {"v04",new string[]{"v01","v02","v03","v11","v12"}},
            {"v05",new string[]{"v02","v07"}},
            {"v06",new string[]{"v01","v08"}},
            {"v07",new string[]{"v05"}},
            {"v08",new string[]{"v06"}},
            {"v09",new string[]{"v03","v13"}},
            {"v10",new string[]{"v13"}},
            {"v11",new string[]{"v01","v02","v03","v04","v12"}},
            {"v12",new string[]{"v02","v04","v11"}},
            {"v13",new string[]{"v09","v10"}}
        };

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

        public Dictionary<string, string[]> GetPaths()
        {
            return paths;
        }
    }
}