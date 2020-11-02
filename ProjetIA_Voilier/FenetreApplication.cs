using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA_Voilier
{
    public partial class FenetreApplication : Form
    {

        private double tailleMap;
        public double TailleMap
        {
            get { return tailleMap; }
            set {
                tailleMap = Math.Min(Math.Max(200, value), 900); //Taille de map entre 200 et 900
            }
        }

        public double x0 { get; private set; }
        public double y0 { get; private set; }
        public double xF { get; private set; }
        public double yF { get; private set; }
        public char casVent { get; private set; }
        public double precision { get; private set; }

        public FenetreApplication()
        {
            InitializeComponent();
        }
    }
}
