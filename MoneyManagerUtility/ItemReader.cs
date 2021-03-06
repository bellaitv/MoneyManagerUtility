﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Parser;
using IniParser.Model.Configuration;

namespace MoneyManagerUtility
{
    public class ItemReader
    {
        //todo creating folder structure
        private String INI_FILE_PATH = String.Format("{0}{1}{2}", Environment.CurrentDirectory, StringResources.CONFIG_FOLDER_PATH, StringResources.INI_FILE_NAME);

        public INIFile File { get; private set; }

        public ItemReader()
        {
            InitFile();
        }

        private void InitFile()
        {
            //todo read config file, or ini file
            File = new INIFile(INI_FILE_PATH);
            File.Read();
        }

        public bool IsCategory(String value)
        {
            return File.ISCategory(value);
        }
    }
}
