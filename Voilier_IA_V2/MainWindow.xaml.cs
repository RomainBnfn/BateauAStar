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

namespace Voilier_IA_V2
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
                return "Nombre de cases pour 10km ( 1 case/"+ Math.Round(tailleCase* 1000, 2) +"m).";
            }

        }

        public DateTime dateExecution { get; set; }

        public double x0 { get; set; } = 100;
        public double y0 { get; set; } = 200;
        public double xf { get; set; } = 200;
        public double yf { get; set; } = 100;

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
        
        private Thread thread_RechercheSolution;
        public delegate void del_editUI();
        public delegate void del_editUIXY(double x, double y);
        public delegate void del_editUIdouble(double d);
        internal delegate void del_editUIList(List<GenericNode> list);
        internal delegate void del_editSearchTree(SearchTree sT); 
        internal delegate void del_editLabelNbPoint(List<GenericNode> chemin, List<GenericNode> ouvert, List<GenericNode> fermes);

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            this.DataContext = this;
        }

        private double getCoordonneDansDomaine(double coord)
        {
            return Math.Max(0, Math.Min(coord, TailleCarte));
        }


        #region PropFull
        //
        // PROPRIETES FULL
        //

        public int X0
        {
            get { return (int) (x0/tailleCase); }
        }

        public int Y0
        {
            get { return (int)(y0 / tailleCase); }
        }

        public int XF
        {
            get { return (int)(xf / tailleCase); }
        }

        public int YF
        {
            get { return (int)(yf / tailleCase); ; }
        }
        #endregion

        //
        // EVENTS
        //

        private void Slider_Precision_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (label_textNbCases == null)
                return;
            label_textNbCases.Text = TextNbCase;
        }

        private void Preview_textbox_coord(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "." && !((TextBox) e.Source).Text.Contains("."))
                return;
            double value;
            if (double.TryParse(e.Text, out value))
            {
                return;
            }
            e.Handled = true;

        }

        private void actualiserEllipse()
        {
            ellipse_start.Margin = new Thickness(convertAfficheX(x0 / tailleCase) - 10, 
                convertAfficheY(y0 / tailleCase) - 10, 0, 0);
            ellipse_end.Margin = new Thickness(convertAfficheX(xf / tailleCase) - 10,
                convertAfficheY(yf / tailleCase) - 10, 0, 0);
        }

        private void After_textbox_coord(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)e.Source;
            double value;
            if (double.TryParse(textBox.Text, out value))
            {
                textBox.Text = getCoordonneDansDomaine(value).ToString();
                actualiserEllipse();
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
            double timeExecution = (DateTime.Now - dateExecution).TotalSeconds;
            Application.Current.Dispatcher.Invoke((del_editUIdouble)setTimeExecution, timeExecution);
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

                Application.Current.Dispatcher.Invoke((del_editLabelNbPoint)afficherSommePoints, Lres, searchTree.L_Ouverts, searchTree.L_Fermes);
                Application.Current.Dispatcher.Invoke((del_editUIList)afficherChemin, Lres);
                Application.Current.Dispatcher.Invoke((del_editSearchTree)createSearchingTree, searchTree);
                bool start = true;
                foreach (GenericNode node in Lres)
                {
                    NodeVoilier nodeV = (NodeVoilier) node;
                    if (prevNode != null)
                        cost += prevNode.GetArcCost(nodeV);

                    prevNode = nodeV;
                    double X = convertAfficheX(nodeV.x),
                           Y = convertAfficheY(nodeV.y);
                    if(start)
                    {
                        Application.Current.Dispatcher.Invoke((del_editUIXY)createStartingPoint, X, Y);
                        start = false;
                    }
                    else
                        Application.Current.Dispatcher.Invoke((del_editUIXY) addPointPath, X, Y);
                }
                Application.Current.Dispatcher.Invoke((del_editUIdouble)setTimeCost, cost);
            }
            Application.Current.Dispatcher.Invoke((del_editUI)DeverrouillerAffichageParametres);
        }
        

        private void cleanPath()
        {
            pathGeometrySimulation.Figures.Clear();
        }

        //
        private double convertAfficheX(double x)
        {
            return x * 500D / (NbCases - 1);
        }

        private double convertAfficheY(double y)
        {
            return 500- y * 500D / (NbCases - 1);
        }

        private void createStartingPoint(double x, double y)
        { 
            pathGeometrySimulation.Figures.Insert(0, new PathFigure(new Point(x, y), new List<PathSegment>(), false));
        }

        private void addPointPath(double x, double y)
        {

            PathFigure pf = pathGeometrySimulation.Figures.FirstOrDefault();
            if (pf == null)
            {
                createStartingPoint(x, y);
                return;
            }
            pf.Segments.Add(new LineSegment(new Point(x, y), true));
        }

        private void clearSearchingTree()
        {
            searchingTree.Items.Clear();
        }

        ////// Si on veut afficher l'arbre de recherche, il suffit de passer un treeview en paramètres
        ////// Celui-ci est mis à jour avec les noeuds de la liste des fermés, on ne tient pas compte des ouverts
        ////public void GetSearchTree(TreeView TV)
        ////{
        ////    if (L_Fermes == null) return;
        ////    if (L_Fermes.Count == 0) return;

        ////    // On suppose le TreeView préexistant
        ////    TV.Nodes.Clear();

        ////    TreeNode TN = new TreeNode(L_Fermes[0].ToString());
        ////    TV.Nodes.Add(TN);

        ////    AjouteBranche(L_Fermes[0], TN);
        ////}

        ////// AjouteBranche est exclusivement appelée par GetSearchTree; les noeuds sont ajoutés de manière récursive
        ////private void AjouteBranche(GenericNode GN, TreeNode TN)
        ////{
        ////    foreach (GenericNode GNfils in GN.GetEnfants())
        ////    {
        ////        TreeNode TNfils = new TreeNode(GNfils.ToString());
        ////        TN.Nodes.Add(TNfils);
        ////        if (GNfils.GetEnfants().Count > 0) AjouteBranche(GNfils, TNfils);
        ////    }

        private void createSearchingTree(SearchTree searchTree)
        {
            if (searchTree.L_Fermes == null 
                || searchTree.L_Fermes.Count == 0) 
                return;
            clearSearchingTree();

            TreeViewItem item = new TreeViewItem();
            item.Header = searchTree.L_Fermes[0].ToString();
            item.Tag = searchTree.L_Fermes[0].ToString();
            addSearchingTreeBranch((NodeVoilier) searchTree.L_Fermes[0], item);
            searchingTree.Items.Add(item);
        }

        private void clearChemin()
        {
            cheminExplore.Items.Clear();
        }

        private void afficherChemin(List<GenericNode> chemin)
        {
            clearChemin();
            foreach (NodeVoilier voilier in chemin)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = voilier.ToString();
                item.Tag = voilier.ToString();
                cheminExplore.Items.Add(item);
            }
        }

        private void addSearchingTreeBranch(NodeVoilier node, TreeViewItem item)
        {
            foreach (NodeVoilier nodeChild in node.GetEnfants())
            {
                TreeViewItem itemChild = new TreeViewItem();
                itemChild.Header = nodeChild.ToString();
                itemChild.Tag = nodeChild.ToString();
                if (nodeChild.GetEnfants().Count > 0)
                    addSearchingTreeBranch(nodeChild, itemChild);
                item.Items.Add(itemChild);
            }
        }

        private void afficherSommePoints(List<GenericNode> chemin, List<GenericNode> ouvert, List<GenericNode> fermes)
        {
            label_nbPointsChemin.Content = chemin.Count.ToString();
            label_nbPointsFerme.Content = fermes.Count.ToString();
            label_nbPointsOuvert.Content = ouvert.Count.ToString();
            label_nbPointsTotal.Content = (ouvert.Count + fermes.Count).ToString();
        }

        private void clearSommePoints()
        {
            label_nbPointsChemin.Content = "";
            label_nbPointsFerme.Content = "";
            label_nbPointsOuvert.Content = "";
            label_nbPointsTotal.Content = "";
        }
        private void setTimeCost(double cost)
        {
            if (cost == -1)
                label_Temps.Content = "Pas de solution.";
            else if (cost == -2)
                label_Temps.Content = "Recherche en cours...";
            else
                label_Temps.Content = Math.Round(cost, 4);
        }

        private void setTimeExecution(double cost)
        {
            if (cost == -1)
                label_TempsExe.Content = "Pas de solution.";
            else if (cost == -2)
                label_TempsExe.Content = "Recherche en cours...";
            else
                label_TempsExe.Content = Math.Round(cost, 4);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VerrouillerAffichageParametres();
            if(checkBox_effacer.IsChecked == true)
                cleanPath();
            
            dateExecution = DateTime.Now;
            setTimeCost(-2);
            setTimeExecution(-2);
            clearSearchingTree();
            clearChemin();
            clearSommePoints();
            thread_RechercheSolution = new Thread(LancementSimulation);
            thread_RechercheSolution.IsBackground = true;
            thread_RechercheSolution.Start();
        }

        private void GroupBox_Vent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbox = (ComboBox) e.OriginalSource;
            Label labelSelect = (Label)cbox.SelectedItem;
            CasVent = labelSelect.Content.ToString()[0];
        }
    }
}
