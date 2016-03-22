using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRegistery
{
    public class Repo
    {
        private static Dictionary<string, List<string>> db;

        private Repo() { }

        public static Dictionary<string, List<string>> DB
        {
            get
            {
                if (db == null)
                {
                    db = new Dictionary<string, List<string>>();
                }
                return db;
            }
        }
    }
}
