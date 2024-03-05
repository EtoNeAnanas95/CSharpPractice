using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace diary
{
    internal class DatesManager
    {
        public  List<Date> dates = new List<Date>();

        public Date FindByDateTime(DateTime selectedDateTime)
        {
                int index = dates.FindIndex(dates => dates.datetime == selectedDateTime);

                if (index != -1)
                {
                    return dates[index];
                }
                else
                {
                    return null;
                }
        }


        public void Add(Date date) 
        {
            this.dates.Add(date);
        }
    }
}
