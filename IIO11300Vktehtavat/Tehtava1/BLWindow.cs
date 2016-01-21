using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300{

    public class Ikkuna {
        #region Variables
        private double height;
        private double area;
        #endregion
        #region Constructors
        #endregion
        #region Methods
        public double calculateArea()
        {
            return height * width;
        }
        public float Price {
            get{
                return calculatePrice();
            }
        }

        private float calculatePrice() {
            //hinta lasketaan työn ja materiaali menekin ja katteen avulla 
            float kate = 100;
            float work = 200;
            float material;
            material = 100 * ((float)width * (float)height / 1000000);
            return (kate + work + material);
        }
        #endregion
        #region Properties
        //olio suunnittleun aikana on päätetty että pinta-ala ja hinta ovat read-only ominaisuukksia
        public double Area
        {
            get
            {
                return height * width;
            }

        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                //tässä voi tarviattesaa tarkistaa
                height = value;
            }
        }
        private double width;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        #endregion
    }

    public class IkkunaVE0
    {
       public double korkeus;
       public double leveys;
        public double LaskePintaAla()
        {
            return korkeus * leveys;
        }
    }


    public class BusinessLogicWindow { 
        public static double CalculatePerimeter(double width, double height, double frame)
        {
            double perimeter = (2 * (height+ width)) / 1000;
            return perimeter;
        }
        public static double CalculateWindowArea(double width, double height)
        {
            double area = (width * height) / 1000000;
            return area;
        }
        public static double CalculateFrameArea(double width, double height, double frame)
        {
            double area = (((2*frame + height)* width) - (width * height)) / 1000000;
            return area;

        }
    }
}

