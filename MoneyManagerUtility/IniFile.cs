using System;
using System.Collections.Generic;
using System.IO;

namespace MoneyManagerUtility
{
    public class INIFile
    {
        public const String COMMENT = ";";
        public const String START_SECTION = "[";
        public const String SUM = "Sum";
        public const String ACTUAL_BALANCE = "Actual balance";

        public ItemCategory CATEGORY_SUM = new ItemCategory() { Description = SUM, Title = SUM };
        public ItemCategory CATEGORY_ACTUAL_BALANCE = new ItemCategory() { Description = ACTUAL_BALANCE, Title = ACTUAL_BALANCE };

        public string path { get; private set; }
        //Items_Categories
        private List<ItemCategory> categories = new List<ItemCategory>();
        private List<Item> items = new List<Item>();

        public INIFile(string INIPath)
        {
            path = INIPath;
        }

        public void Read()
        {
            String[] lines = File.ReadAllLines(path);
            String actualSection = String.Empty;
            int itemssSum = 0;
            for (int i = 0; i < lines.Length - 1; i++)
            {
                String line = lines[i];
                if (line.Equals(string.Empty))
                    continue;
                if (line[0].ToString().Equals(COMMENT))
                    continue;
                if (line[0].ToString().Equals("["))
                {
                    actualSection = line;
                    continue;
                }
                switch (actualSection)
                {
                    case "[Items_Categories]":
                        {
                            String[] splittedLine = line.Split('=');
                            ItemCategory actual = new ItemCategory() { Title = splittedLine[0], Description = splittedLine[1] };
                            categories.Add(actual);
                            break;
                        }
                    case "[Items]":
                        {
                            String[] splittedLine = line.Split('=');
                            //todo description not [1]
                            Item actual = new Item() { Category = categories[itemssSum],Value = splittedLine[1], Description = splittedLine[1] };
                            items.Add(actual);
                            itemssSum++;
                            break;
                        }
                    default:
                        { //todo errorMsg or ignore
                            break;
                        }
                }
            }
            categories.Add(CATEGORY_SUM);
            categories.Add(CATEGORY_ACTUAL_BALANCE);
        }

        public bool ISCategory(String value)
        {
            foreach (ItemCategory actualItem in categories)
                if (actualItem.Title.Equals(value))
                    return true;
            return false;
        }

        public List<Item> GetItems() {
            return items;
        }

        public List<ItemCategory> GetCategories() {
            return categories;
        }
    }
}
