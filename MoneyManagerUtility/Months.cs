using System;
namespace MoneyManagerUtility
{
    public class Months
    {
        public static String[] months = { StringResources.JANUARY, StringResources.FEBRUARY, StringResources.MARCH,
           StringResources.APRIL, StringResources.MAJ, StringResources.JUNE, StringResources.JULIE,
        StringResources.AUGUST, StringResources.SEPTEMBER, StringResources.OKTOBER,StringResources.NOVEMBER,StringResources.DECMBER};

        public static bool IsMonth(String month)
        {
            foreach (String actual in months)
                if (month.Equals(actual))
                    return true;
            return false;
        }

        public static bool IsMonth(int month)
        {
            return (month >= 1 && month <= 12);
        }
    }
}
