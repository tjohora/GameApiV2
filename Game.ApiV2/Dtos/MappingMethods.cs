using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Dtos
{
    public static class MappingMethods
    {
        public static int GetCompanyAge(this DateTimeOffset dateTimeOffset)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - dateTimeOffset.Year;
            if (currentDate < dateTimeOffset.AddYears(age))
            {
                age--;
            }
            return age;
        }


    }
}
