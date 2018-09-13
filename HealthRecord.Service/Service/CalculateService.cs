using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthRecord.Model;

namespace HealthRecord.Service
{
    public class CalculateService : ICalculate
    {
        private double _deduct; //BMR 減去值
        private double _bmr;
        private double _tdee;
        public CalculateService(double deduct)
        {
            this._deduct = deduct;
        }

        public double CalculateBMR(Human human)
        {

            if (human.Weight > 0 && human.Height > 0 && human.Age > 0)
            {
                _bmr = (10 * human.Weight) + (6.25 * human.Height) - (5 * human.Age) + _deduct; //BMR公式
            }
            else
            {
                _bmr = -1;
            }
            return _bmr;
        }
        //計算每天所需營養素
        public Nutrition CalculateNutrition(Human human)
        {
            CalculateTdee(human);
            double _weightbylbl = human.Weight * 2.2; //體重換算成磅計算
            double protein = 0, fat = 0, carbon = 0;
            protein = _weightbylbl; //每磅體重1g蛋白
            fat = _weightbylbl * 0.4;//每磅體重0.4g脂肪
            carbon = (_tdee - (protein * 4) - (fat * 9)) / 4;
            var temp = new Nutrition() {
                Carbon = carbon,
                Protein = protein,
                Fat = fat,
                Tdee = _tdee,
                BMR = _bmr,
                CreateDate = DateTime.Now,
                Description=$"身高{human.Height},體重{human.Weight},年齡{human.Age}",
                HumanId=human.Id

            };

            return temp;
        }

        public double CalculateTdee(Human human)
        {
            CalculateBMR(human); //先取得BMR
            
            double multi = human.Activity + (human.isHighintensity ? 0.08 : 0) + (human.isLabor ? 0.25 : 0);//活動量
            _tdee = _bmr * multi * (1 + human.Goal);//目標值

            return _tdee;
        }
    }
}
