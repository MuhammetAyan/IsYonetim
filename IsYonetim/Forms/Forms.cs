using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsYonetim.Forms
{
    public static class Forms
    {
        public static List<Home> Homes { get; set; } = new List<Home>();

        public static void Load(Form form)
        {
            var ClassName = form.GetType().Name;
            switch (ClassName)
            {
                case "Home":
                    Homes.Add((Home)form);
                    form.FormClosing += Home_FormClosing;
                    break;
                default:
                    break;
            }
        }

        private static void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Homes.Remove((Home)sender);
        }
    }
}
