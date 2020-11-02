using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Voilier_IA
{
    /// <summary>
    /// Logique d'interaction pour LabeledPoint.xaml
    /// </summary>
    public partial class LabeledPoint : UserControl
    {
        public String LabelText { get; set; } = "Name";

        public LabeledPoint()
        {
            InitializeComponent();
        }

        public LabeledPoint(String label)
        {
            InitializeComponent();
            this.LabelText = label;
        }
    }
}
