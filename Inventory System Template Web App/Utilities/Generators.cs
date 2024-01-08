using System.Text;

namespace Inventory_System_Template_Web_App.Utilities
{
    public class Generators
    {
        public static string NewId()
        {
            Random rd = new Random();
            uint id;
            string getYear;
            id = (uint)rd.Next(100000000, 200000000);
            getYear = DateTime.Now.Year.ToString();
            StringBuilder sb = new StringBuilder(id.ToString() + "-" + getYear, 14);
            return sb.ToString();
        }
    }
}
