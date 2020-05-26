using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckDup
{
    public class CheckForDuplicates
    {
        public Tuple<int, List<string>> checkDupl(List<int> inlist)
        {
            int currcode = 0;
            List<string> currvalue = new List<string> { };

            void replaceCode(int oldcode, int newcode, List<string> oldvalue, string newvalue)
            {
                currcode = newcode;
                currvalue.Add(newvalue);
            }

            Tuple<int, List<string>> getTuple()
            {
                Tuple<int, List<string>> returnvalue = new Tuple<int, List<string>>(currcode, currvalue);
                return returnvalue;
            }

            List<string> errorlist = new List<string>
            {
                "No error code started",
                "Duplicates Found",
                "No duplicates",
                "Unknown error"
            };

            List<int> query = inlist.GroupBy(x => x)
                                    .Where(y => y.Count() > 1)
                                    .Select(z => z.Key).ToList();
            if (query.Count > 0)
            {
                foreach (int item in query)
                {
                    replaceCode(currcode, 1, currvalue, item.ToString());
                }
                if (currcode == 1)
                {
                    return getTuple();
                }
            } else {
                replaceCode(currcode, 2, currvalue, errorlist[2]);
                return getTuple();
            }

            replaceCode(currcode, 3, currvalue, "Unknown error");
            return getTuple();
        }
    }
}
