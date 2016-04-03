using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UBVid
{
    public class SerieMoyenne : IComparable
    {
        Serie serie;
        double moyenne;

        public SerieMoyenne(Serie s,double m)
        {
            serie = s;
            moyenne = m;
        }

        public Serie Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        public Double Moyenne
        {
            get { return moyenne; }
            set { moyenne = value; }
        }


        int IComparable.CompareTo(object obj)
        {
            SerieMoyenne c = (SerieMoyenne)obj;
            int res=0;
            if (c.moyenne == moyenne) res = 0;
            else if (c.moyenne > moyenne) res = 1;
            else if (c.moyenne < moyenne) res = -1;
            return res;

        }
 
    }
}
