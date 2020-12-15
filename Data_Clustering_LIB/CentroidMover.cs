using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Clustering_LIB
{
    public class CentroidMover
    {

        public static Centroid CountDistAndAssignCentroid(Iris iris, Centroid irisSetosa, Centroid irisVersicolor, Centroid irisVirginica)
        {
            bool status = true;
            double dist1 = 0, dist2 = 0, dist3 = 0;

            dist1 = CountDist(iris, irisSetosa);
            dist2 = CountDist(iris, irisVersicolor);
            dist3 = CountDist(iris, irisVirginica);

            if(dist1 < dist2 && dist1 < dist3) 
            {
                return irisSetosa;
            }
            else if (dist2 < dist1 && dist2 < dist3)
            {
                return irisVersicolor;
            }
            else
            {
                return irisVirginica;
            }
            
        }

        private static double CountDist(Iris iris, Centroid centroid)
        {
            double distance = Math.Sqrt(Math.Pow((iris.SepalL - (double)centroid.F1), 2) + Math.Pow((iris.SepalW - (double)centroid.F2), 2) + Math.Pow((iris.PetalL - (double)centroid.F3), 2) + Math.Pow((iris.PetalW - (double)centroid.F4), 2));
            return distance;
        }
        public static double CalcSSE(List<Iris> listI, Centroid irisSetosa, Centroid irisVersicolor, Centroid irisVirginica)
        {
            double minimumSetosa = CentroidMover.CountDist(listI[0], irisSetosa);
            double minimumVersicolor = CentroidMover.CountDist(listI[0], irisVersicolor);
            double minimumVirginica = CentroidMover.CountDist(listI[0], irisVirginica);
            foreach (Iris i in listI)
            {
                switch (i.Centroid.Name)
                {
                    case ("Setosa"):
                        double t = CentroidMover.CountDist(i, irisSetosa);
                        if (minimumSetosa > t)
                        {
                            minimumSetosa = t;
                        }
                        continue;
                    case ("Versicolor"):
                        double tV = CentroidMover.CountDist(i, irisVersicolor);
                        if (minimumVersicolor > tV)
                        {
                            minimumVersicolor = tV;
                        }
                        continue;
                    case ("Virginica"):
                        double tVi = CentroidMover.CountDist(i, irisVirginica);
                        if (minimumVirginica > tVi)
                        {
                            minimumVirginica = tVi;
                        }
                        continue;
                }
            }
            double total = Math.Pow(minimumSetosa, 2) + Math.Pow(minimumVersicolor, 2) + Math.Pow(minimumVirginica, 2);
            return total;
        }
    }
}
