using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerUtility
{
    public class StringResources
    {
        //Folders
        public const String SAVE_FOLDER_PATH = @"\Save\";
        public const String CONFIG_FOLDER_PATH = @"\CONFIG\";

        public const String INI_FILE_NAME = "Settings.ini";
        

        //Save Format
        public const String SAVE_FORMAT_YEAR_START = "<year value=\"{0}\">";
        public const String SAVE_FORMAT_MONTH_START = "<month value=\"{0}\">";
        public const String SAVE_FORMAT_DAY_START = "<day value=\"{0}\">";
        public const String SAVE_FORMAT_SHOPPING_ITEM_START = "<shoppin_item  category=\"{0}\" value=\"{1}\" description=\"{2}\"/>";
        public const String SAVE_FORMAT_YEAR_END = "</year>";
        public const String SAVE_FORMAT_MONTH_END = "</month>";
        public const String SAVE_FORMAT_DAY_END = "</day>";
        public const String SAVE_FORMAT_EXTENSION = ".xml";

        //Months
        public const String JANUARY = "JANUARY";
        public const String FEBRUARY = "FEBRUARY";
        public const String MARCH = "MARCH";
        public const String APRIL = "APRIL";
        public const String MAJ = "MAJ";
        public const String JUNE = "JUNE";
        public const String JULIE = "JULIE";
        public const String AUGUST = "AUGUST";
        public const String SEPTEMBER = "SEPTEMBER";
        public const String OKTOBER = "OKTOBER";
        public const String NOVEMBER = "NOVEMBER";
        public const String DECMBER = "DECMBEr";

        //import/export
        public const String SUM = "Sum";
        public const String ACTUAL_BALANCE = "Actual balance";

        //TXTimport/export
        public const String TXT_SEPARATOR_DAY = "#############################################################";
        public const String TXT_SEPARATOR_DAILY_LIST_END = "-------------------------------------------------------------";
        public const String TXT_END_SIGN = "=";

        //XMLImport/export
        public const String XML_SEPARATOR_DAY = "#############################################################";
        public const String XML_SEPARATOR_DAILY_LIST_END = "-------------------------------------------------------------";
        public const String XML_END_SIGN = "=";
        public const String XML_YEAR = "YEAR";

        public const String ERROR_MSG_TITLE = "Error";
        public const String ERROR_MSG_EMPTY_CONTENT = "The {0} field is empty";

        //
        public const char asd = ' ';
    }
}
