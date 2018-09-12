using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Model
{
   public enum ActivityType
    {
        [Activity(1.2)]
        None = 0,
        [Activity(1.38)]
        THree_Week = 1,
        [Activity(1.42)]
        Four_Week = 2,
        [Activity(1.46)]
        Five_Week = 3,
        [Activity(1.5)]
        Six_Week = 4,
        [Activity(1.64)]
        Seven_Week=5
    }
}
