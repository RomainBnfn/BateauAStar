using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA_Voilier
{
    static class Program
    {
        public static bool continuer = true;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while(continuer)
            { 
                Application.Run(new FenetreParametres());
                if (!continuer)
                    break;
                Application.Run(new FenetreGraphique());
            }
        }
    }
}
