﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.OfficeProPlus.Downloader
{
    public class AppSettings
    {
        private const string MBranchVersionUrl = "https://github.com/OfficeDev/Office-IT-Pro-Deployment-Scripts/raw/master/Office-ProPlus-Deployment/BranchVersions.json";

        public static string BranchVersionUrl
        {
            get
            {
                var objConfig = GetAppSetting<string>("BranchVersionUrl").ToString();
                return String.IsNullOrEmpty(objConfig) ? MBranchVersionUrl : objConfig;
            }
        }

        private static dynamic GetAppSetting<T>(string name)
        {
            var objConfig = ConfigurationManager.AppSettings[name] ?? "";

            if (typeof(T) == typeof(string))
            {
                return objConfig;
            }
            if (typeof(T) == typeof(int))
            {
                return Convert.ToInt32(objConfig);
            }
            return objConfig;
        } 

    }
}
