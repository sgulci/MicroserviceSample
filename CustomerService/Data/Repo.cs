using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRegistery
{
    public class Repo
    {
        private static List<string> db;

        private Repo() { }

        public static List<string > DB
        {
            get
            {
                if (db == null)
                {
                    db = new List<string>();
                }
                return db;
            }
        }
    }
}
