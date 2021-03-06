﻿using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace OSBLEPlus.Logic.Utility
{
    public static class StringConstants
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["OSBLEData"].ConnectionString;
            }
        }

        public static string WebClientRoot
        {
            get
            {
#if DEBUG
                return "http://192.168.1.58/";                                     
                //return "http://demo.plus.osble.org/";                                     
#else

                return "https://plus.osble.org/";
#endif
            }
        }

        public static string DataServiceRoot
        {
            get
            {
#if DEBUG
                return "http://192.168.1.58/plusservices/";
                //return "http://demo.plus.osble.org/plusservices/";                                     
#else
                return "https://plus.osble.org/plusservices/";                
#endif
            }
        }

        public static string ActivityFeedUrl
        {
            get { return string.Format("{0}/Feed/OSBIDE", WebClientRoot); }
        }

        public static string AskTheProfessorUrl
        {
            get { return string.Format("{0}/PrivateQuestion", WebClientRoot); }
        }

        public static string CreateAccountUrl
        {
            get { return string.Format("{0}/Account/AcademiaRegister", WebClientRoot); }
        }

        public static string ChatUrl
        {
            get { return string.Format("{0}/Chat", WebClientRoot); }
        }

        public static string ProfileUrl
        {            
            get { return string.Format("{0}/Profile", WebClientRoot); }
        }

        public static string CommunityUrl
        {
            get { return string.Format("{0}/OSBLECommunity", WebClientRoot); }
        }

        public static string WhatsNewUrl
        {
            get { return string.Format("{0}/WhatsNew", WebClientRoot); }
        }

        public static string InterventionUrl
        {
            get { return string.Format("{0}/Intervention", WebClientRoot); }
        }

        public static string InterventionRefreshThreshold
        {
            get { return ConfigurationManager.AppSettings["InterventionRefreshThreshold"] ?? "5"; }
        }

        public static string UpdateUrl
        {
            get { return string.Format("{0}/Content/osble_plugin.zip", WebClientRoot); }
        }

        public static string LocalUpdatePath
        {
            get { return Path.Combine(DataRoot, "osble_plugin.vsix"); }
        }

        public static string DataRoot
        {
            get
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OSBLE");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        public static string LocalCacheDirectory
        {
            get
            {
#if DEBUG
                string path = Path.Combine(DataRoot, "cache_debug");
#else
                string path = Path.Combine(DataRoot, "cache_release");
#endif
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        public static string LocalErrorLogExtension
        {
            get
            {
                return ".log";
            }
        }

        public static string LocalErrorLogFileName
        {
            get
            {
                return DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        public static string LocalErrorLogPath
        {
            get
            {
                return Path.Combine(DataRoot, string.Format("{0}.{1}", LocalErrorLogFileName, LocalErrorLogExtension));
            }
        }

        public static string AesKeyCacheKey
        {
            get
            {
                return "AesKey";
            }
        }

        public static string AesVectorCacheKey
        {
            get
            {
                return "AesVector";
            }
        }

        public static string UserNameCacheKey
        {
            get
            {
                return "UserName";
            }
        }

        public static string PasswordCacheKey
        {
            get
            {
                return "Password";
            }
        }

        public static string AuthenticationCacheKey
        {
            get
            {
                return "AuthKey";
            }
        }

        public static string FileCacheKey
        {
            get { return "FileCacheKey"; }
        }

        public static string LibraryVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public static string DocumentationUrl
        {
            get
            {
                return "http://osble.codeplex.com/documentation";
            }
        }

        public static int OnlineActivtyMetricInMinutes
        {
            get
            {
                return 30;
            }
        }

        public const string SqlHelperLogIdVar = "@logId";

        public const string SqlHelperEventIdVar = "@eventId";
        public const string SqlHelperDocIdVar = "@docId";
        public const string SqlHelperIdVar = "@tempId";
    }
}
