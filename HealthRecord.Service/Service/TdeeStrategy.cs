using HealthRecord.Model;
using HealthRecord.Service.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Service
{
   public class TdeeStrategy
    {
        public Human Human { get; set; }
        ICalculate _calculate;

        public TdeeStrategy(double deduct)
        {
            _calculate = GenericFactory.CreateInastance<ICalculate>(typeof(CalculateService), new object[] { deduct });
        }
        public double BMR
        {
            get
            {

                return _calculate.CalculateBMR(Human);
            }
        }
        public double TDEE
        {
            get
            {

                return _calculate.CalculateTdee(Human);
            }
        }
        public Nutrition Nutrituon
        {
            get
            {
                return _calculate.CalculateNutrition(Human);
            }
        }


    }
    public class ManTdeeStrategy : TdeeStrategy
    {
        public ManTdeeStrategy() : base(5)
        {

        }
    }
    public class WomanTdeeStrategy : TdeeStrategy
    {
        public WomanTdeeStrategy() : base(-161)
        {

        }
    }
}
