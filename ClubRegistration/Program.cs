using ClubRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClubRegistration
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();          // Enable visual styles for the form
            Application.SetCompatibleTextRenderingDefault(false);  // Use default text rendering
            Application.Run(new FrmClubRegistration());  // Run the main form FrmClubRegistration
        }
    }
}
