using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava1{
    public class BusinessLogicWindow
    {
        /// <summary>
        /// CalculatePerimeter calculates the perimeter of a window
        /// </summary>



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
            double area = ((frame + height * frame + width) - (width * height)) / 1000000;
            return area;

        }
    }
}

