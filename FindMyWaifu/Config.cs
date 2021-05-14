using System;
using System.Configuration;
using System.Data.OleDb;
using System.IO;

namespace FindMyWaifu
{
    static class Config
    {
        static OleDbConnection conn;
        static string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static string connString
        {
            get
            {
                return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\waifu.mdb";
            }
        }

        public static string configFolder
        {
            get
            {
                if (!Directory.Exists(appData + @"\yansaan\FMW\"))
                    Directory.CreateDirectory(appData + @"\yansaan\FMW\");
                return appData + @"\yansaan\FMW\";
            }
        }

        public static int CountData
        {
            get
            {
                using (conn = new OleDbConnection(connString))
                using (OleDbCommand com = new OleDbCommand("SELECT * from waifu", conn))
                {
                    conn.Open();

                    Int32 count = (com.ExecuteScalar() != null) ? (Int32)com.ExecuteScalar() : 0;
                    conn.Close();
                    return count;
                }
            }
        }

        public static void CreateConfig()
        {
            GetFolder(@"config\");
            GetFolder(@"data\img\");

            if (!File.Exists(Config.configFolder + @"config\setting.set"))
            {
                //ConfigDefault();
            }

        }

        public static string GetFolder(string folder)
        {
            if (!Directory.Exists(Config.configFolder + folder))
                Directory.CreateDirectory(Config.configFolder + folder);

            return Path.Combine(configFolder, folder);
        }
    }
}
