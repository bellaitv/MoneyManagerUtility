using System;
namespace MoneyManagerUtility
{
    public class Months
    {
        //NOTE: 0. index is JANUARY
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
            return (month >= 0 && month <= 11);
        }

        public static String GetMonth(int index)
        {
            return months[index];
        }

        public static int WhichMonth(String month)
        {
            for (int i = 0; i < months.Length; i++)
            {
                String actual = months[i];
                if (month.Equals(actual))
                    return i;
            }
            return -1;
        }

    }
}
