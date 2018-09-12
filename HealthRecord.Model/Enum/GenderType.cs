using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Model
{
    public enum GenderType
    {
        [Strategy(0)]
        Man = 0,
        [Strategy(1)]
        Woman = 1
    }
}
