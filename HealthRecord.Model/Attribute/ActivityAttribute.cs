using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Model
{
    public class ActivityAttribute : Attribute
    {
        public double Activitymulti { get; set; }//活動量乘數
        public ActivityAttribute(double activity)
        {
            Activitymulti = activity;
        }
    }
}
