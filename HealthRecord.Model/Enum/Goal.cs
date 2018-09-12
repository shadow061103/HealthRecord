using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Model
{
    public enum Goal
    {
        [Goal(0.05)]
        BuildMuscle_less = 0,
        [Goal(0.1)]
        BuildMuscle_Normal = 1,
        [Goal(0.15)]
        BuildMuscle_More = 2,
        [Goal(0)]
        Mailtain = 3,
        [Goal(-0.15)]
        LoseFat_less = 4,
        [Goal(-0.2)]
        LoseFat_Normal = 5,
        [Goal(-0.25)]
        LoseFat__More = 6
    }
}
