using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;

        public int TailleCarte { get; set; } = 300;
        public String TextNbCase {
            get
            {
                return "Nombre de cases pour 10km ("+ NbCases + "x"+ NbCases + " cases).";
            }

        }
        public int NbCases {
            get
            {
                return TailleCarte / 10 * Precision ;
            }
        }
        public int Precision { get; set; } = 10;
        public char CasVent { get; set; } = 'c';

        public double tailleCase
        {
            get { return 10D / Precision; }
        }

        private int x0 = 10;
        private int y0 = 10;
        private int xF = 15;
        private int yF = 15;

        private Thread thread_RechercheSolution;
        public delegate void del_editUI();
        public delegate void del_editUIXY(int x, int y);
        public delegate void del_editUIdouble(double d);

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            this.DataContext = this;
        }

        private int getCoordonneDansDomaine(int coord)
        {
            return Math.Max(0, Math.Min(coord, NbCases - 1));
        }

        private void updateCoordonnes()
        {
            X0 = x0;
            Y0 = y0;
            XF = xF;
            YF = yF;
            if (textbox_x0 != null)
                textbox_x0.Text = X0.ToString();
            if (textbox_y0 != null)
                textbox_y0.Text = Y0.ToString();
            if (textbox_xf != null)
                textbox_xf.Text = XF.ToString();
            if (textbox_yf != null)
                textbox_yf.Text = YF.ToString();
        }

        #region PropFull
        //
        // PROPRIETES FULL
        //

        public int X0
        {
            get { return x0; }
            set { x0 = getCoordonneDansDomaine(value); }
        }

        public int Y0
        {
            get { return y0; }
            set { y0 = getCoordonneDansDomaine(value); }
        }

        public int XF
        {
            get { return xF; }
            set { xF = getCoordonneDansDomaine(value); }
        }

        public int YF
        {
            get { return yF; }
            set { yF = getCoordonneDansDomaine(value); }
        }
        #endregion

        //
        // EVENTS
        //

        private void Slider_TailleCarte_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            updateCoordonnes();
            if (label_textNbCases == null)
                return;
            label_textNbCases.Text = TextNbCase;
        }

        private void Slider_Precision_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            updateCoordonnes();
            if (label_textNbCases == null)
                return;
            label_textNbCases.Text = TextNbCase;
        }

        private void Preview_textbox_coord(object sender, TextCompositionEventArgs e)
        {
            int value;
            if (int.TryParse(e.Text, out value))
            {

                return;
            }
            e.Handled = true;
        }

        private void After_textbox_coord(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)e.Source;
            int value;
            if (int.TryParse(textBox.Text, out value))
            {
                if (value < 0)
                    textBox.Text = "0";
                if (value >= NbCases)
                    textBox.Text = (NbCases - 1).ToString();
                return;
            }
        }

        private void Cancel_WhiteSpace(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
                e.Handled = true;
        }

        public void VerrouillerAffichageParametres()
        {

            label_enCours.Visibility = Visibility.Visible;
            Button_LancementSimulation.IsEnabled = false;
            groupBox_Parametres.IsEnabled = false;
        }

        public void DeverrouillerAffichageParametres()
        {
            Console.WriteLine("fin");
            label_enCours.Visibility = Visibility.Collapsed;
            Button_LancementSimulation.IsEnabled = true;
            groupBox_Parametres.IsEnabled = true;
        }

        public void LancementSimulation()
        {
            SearchTree searchTree = new SearchTree();
            NodeVoilier N0 = new NodeVoilier(X0, Y0);
            List<GenericNode> Lres = searchTree.RechercheSolutionAEtoile(N0);

            if (Lres.Count == 0)
            {
                Console.WriteLine("Pas de solution");
                Application.Current.Dispatcher.Invoke((del_editUIdouble)setTimeCost, -1);
            }
            else
            {
                double cost = 0;
                Console.WriteLine("Une solution a été trouvée !");
                NodeVoilier prevNode = null;
                foreach(GenericNode node in Lres)
                {
                    NodeVoilier nodeV = (NodeVoilier) node;
                    if (prevNode != null)
                        cost += prevNode.GetArcCost(nodeV);

                    prevNode = nodeV;
                    Application.Current.Dispatcher.Invoke((del_editUIXY) addPointPath, nodeV.x, nodeV.y );
                    Application.Current.Dispatcher.Invoke((del_editUIdouble)setTimeCost, cost);
                }
            }
            Application.Current.Dispatcher.Invoke((del_editUI)DeverrouillerAffichageParametres);
        }
        

        private void cleanPath()
        {
            pathGeometrySimulation.Figures.Clear();
        }

        //

        private void addPointPath(int x, int y)
        {
            double X = x * 499D / (NbCases - 1),
                   Y = y * 499D / (NbCases - 1);
            PathFigure pf = pathGeometrySimulation.Figures.FirstOrDefault();
            if (pf == null)
            {
                pathGeometrySimulation.Figures.Add(
                    new PathFigure(new Point(X, Y), new List<PathSegment>() , false));
                return;
            }
            pf.Segments.Add(new LineSegment(new Point(X, Y), true));
        }

        private void setTimeCost(double cost)
        {
            if (cost == -1)
                label_Temps.Content = "Pas de solution.";
            label_Temps.Content = cost;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VerrouillerAffichageParametres();
            cleanPath();
            thread_RechercheSolution = new Thread(LancementSimulation);
            thread_RechercheSolution.IsBackground = true;
            thread_RechercheSolution.Start();
        }

        private void GroupBox_Vent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbox = (ComboBox) e.OriginalSource;
            Label labelSelect = (Label)cbox.SelectedItem;
            CasVent = labelSelect.Content.ToString()[0];
            Console.WriteLine(CasVent);
        }
    }
}
