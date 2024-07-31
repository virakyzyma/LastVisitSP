using Microsoft.Win32;

namespace LastVisitSP
{
    internal class Program
    {
        static void Main()
        {
            string keyPath = @"Software\MyApp";
            DateTime lastAccessTime = LoadLastTimeVisit(keyPath);
            if (lastAccessTime == DateTime.MinValue)
            {
                Console.WriteLine("Today is _31._07");
            }
            else
            {
                Console.WriteLine("Last visite: " + lastAccessTime);
            }
            SaveLastTimeVisit(keyPath, DateTime.Now);
        }
        static DateTime LoadLastTimeVisit(string keyPath)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    object value = key.GetValue("LastAccessTime");
                    if (value != null)
                    {
                        return Convert.ToDateTime(value);
                    }
                }
            }
            return DateTime.MinValue;
        }
        static void SaveLastTimeVisit(string keyPath, DateTime lastAccessTime)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                key.SetValue("LastAccessTime", lastAccessTime.ToString());
            }
        }
    }
}
