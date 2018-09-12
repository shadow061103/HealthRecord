using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Model
{
    public class GoalAttribute : Attribute
    {
        public double TdeePlus { get; set; }//活動量乘數
        public GoalAttribute(double plus)
        {
            TdeePlus = plus;
        }
    }
}
