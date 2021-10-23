using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public double sredn (List<DateTime> voz)
        {
            int[] a = new int[voz.Count];
            int i = 0;
            foreach (DateTime dates in voz)
            {
                var today = DateTime.Today;
                a[i] = today.Year - dates.Year;
                if (dates > today.AddYears(-a[i])) a[i]--;
                i++;
            }
            double s, o=0;
            int k;
            for (k = 0; k < a.Length; k++)
            {
                o += a[k];
            }
            s = o / k;
            return s;
        }
        public List<string> imena(List<string> nam, string n)
        {
            List<string> names;
            names = new List<string>();
            nam = nam.Where(x => x.Contains(n)).ToList();
            names = nam;// возвращаем результат в виде списка, к которому применялись активные фильтры
            return names;
        }
    }
}
