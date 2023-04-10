using System;
using System.IO;
using System.Reflection;

namespace WinClient.Utils.Helpers
{
    public static class ClientHelper
    {
        #region Client
        public static string VERSION => Assembly.GetExecutingAssembly()!.GetName()!.Version!.ToString();
        public const string CLIENT_DISPLAY_NAME = "Anno 1800 Stamp Manager";
        public const string CLIENT_PHYSICAL_NAME = "Nx.Anno1800.StampManager.WinClient";
        #endregion

        #region Vendor
        public static string DIR_VENDORS =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vendor");
        public static string DIR_VENDOR_ANNO_MODS =>
            Path.Combine(DIR_VENDORS, "anno-mods");
        public static string DIR_FILE_DB_READER =>
            Path.Combine(DIR_VENDOR_ANNO_MODS, "FileDBReader");
        public static string EXE_FILE_DB_READER =>
            Path.Combine(DIR_FILE_DB_READER, "FileDBReader.exe");
        public static string INTPRET_FILE_STAMPS =>
            Path.Combine(DIR_FILE_DB_READER, "FileFormats", "stamp.xml");
        #endregion
    }
}
