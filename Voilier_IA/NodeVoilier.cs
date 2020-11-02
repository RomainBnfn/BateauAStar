using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voilier_IA
{
    class NodeVoilier : GenericNode
    {
        public int x { get; set; }
        public int y { get; set; }

        public NodeVoilier(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override double CalculeHCost()
        {
            return MainWindow.mainWindow.tailleCase *
                Math.Sqrt(Math.Pow(x - MainWindow.mainWindow.XF, 2)
                             + Math.Pow(y - MainWindow.mainWindow.YF, 2));
        }

        public override bool EndState()
        {
            return x == MainWindow.mainWindow.XF 
                && y == MainWindow.mainWindow.YF;
        }

        public override double GetArcCost(GenericNode N2)
        {
            NodeVoilier N2V = N2 as NodeVoilier;
            if (N2V == null)
                return 1000000;
            double taille = MainWindow.mainWindow.tailleCase;
            return time_estimation(taille * x, taille * y, taille * N2V.x, taille * N2V.y);
        }

        public override List<GenericNode> GetListSucc()
        {
            List<GenericNode> voisins = new List<GenericNode>();
            for (int i = -1; i < 2; i++)
            {
                for(int j = -1; j < 2; j++)
                {
                    if (estCoordonneCorrecte(x + i, y + j) && (i != j || (i==j && i != 0)))
                        voisins.Add(new NodeVoilier(x + i, y + j));
                }
            }
            return voisins;
        }

        private bool estCoordonneCorrecte(int x, int y)
        {
            return (x >= 0 && x < MainWindow.mainWindow.NbCases
                && y >= 0 && y < MainWindow.mainWindow.NbCases);
            
        }

        public override bool IsEqual(GenericNode N2)
        {
            NodeVoilier N2V = N2 as NodeVoilier;
            return (N2V == null) ? false : (x == N2V.x && y == N2V.y) ;
        }

        public double time_estimation(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            if (distance > 10) return 1000000;
            double windspeed = get_wind_speed((x1 + x2) / 2.0, (y1 + y2) / 2.0);
            double winddirection = get_wind_direction((x1 + x2) / 2.0, (y1 + y2) / 2.0);
            double boatspeed;
            double boatdirection = Math.Atan2(y2 - y1, x2 - x1) * 180 / Math.PI;
            // On ramène entre 0 et 360
            if (boatdirection < 0) boatdirection = boatdirection + 360;
            // calcul de la différence angulaire
            double alpha = Math.Abs(boatdirection - winddirection);
            // On se ramène à une différence entre 0 et 180 :
            if (alpha > 180) alpha = 360 - alpha;
            if (alpha <= 45)
            {
                /* (0.6 + 0.3α / 45) v_v */
                boatspeed = (0.6 + 0.3 * alpha / 45) * windspeed;
            }
            else if (alpha <= 90)
            {
                /*v_b=(0.9-0.2(α-45)/45) v_v */
                boatspeed = (0.9 - 0.2 * (alpha - 45) / 45) * windspeed;
            }
            else if (alpha < 150)
            {
                /* v_b=0.7(1-(α-90)/60) v_v */
                boatspeed = 0.7 * (1 - (alpha - 90) / 60) * windspeed;
            }
            else
                return 1000000;
            // estimation du temps de navigation entre p1 et p2
            return (distance / boatspeed);
        }

        public double get_wind_speed(double x, double y)
        {
            char cas = MainWindow.mainWindow.CasVent;
            if (cas == 'a')
                return 50;
            else if (cas == 'b')
                if (y > 150)
                    return 50;
                else return 20;
            else if (y > 150)
                return 50;
            else return 20;
        }
        public double get_wind_direction(double x, double y)
        {
            char cas = MainWindow.mainWindow.CasVent;
            if (cas == 'a')
                return 30;
            else if (cas == 'b')
                if (y > 150)
                    return 180;
                else return 90;
            else if (y > 150)
                return 170;
            else return 65;
        }
    }
}
