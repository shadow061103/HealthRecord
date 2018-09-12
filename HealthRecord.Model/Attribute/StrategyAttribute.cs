using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Model
{
    public class StrategyAttribute : Attribute
    {
        public int StrategyType { get; private set; }
        public StrategyAttribute(int strategyType)
        {
            StrategyType = strategyType;
        }
    }
}
