using System;

namespace Weather_Checker
{
    public static class TempConverter
    {
        public static double CelsiusConverter(double temperature)
        {
            return Math.Ceiling(temperature - 273.15);
        }

        public static double FarengateConverter(double temperature)
        {
            return Math.Ceiling((temperature - 273.15) * 9 / 5 + 32);
        }
    }
}