using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava1
{
    public class BusinessLogicWindow{
        /// <summary>
        /// CalculatePerimeter calculates the perimeter of a window
        /// </summary>
      
        

        public static double CalculatePerimeter(double width, double height, double frame){
            throw new System.NotImplementedException();

          

            double width;
            width = double.Parse(txtWidth.Text);

            double height;
            height = double.Parse(txtHeight.Text);

            double frame;
            frame = double.Parse(txtFrame.Text);

            double result;
            result = (width + frame) * 2 + (height + frame) * 2;

            return result;
        }

        public static double CalculateArea(double width, double height, double frame)
        {
            throw new System.NotImplementedException();



            double width;
            width = double.Parse(txtWidth.Text);

            double height;
            height = double.Parse(txtHeight.Text);

            double frame;
            frame = double.Parse(txtFrame.Text);

            double result;
            result = width * height;


            return result;
        }

        public static double CalculateFrameArea(double width, double height, double frame)
        {
            throw new System.NotImplementedException();



            double width;
            width = double.Parse(txtWidth.Text);

            double height;
            height = double.Parse(txtHeight.Text);

            double frame;
            frame = double.Parse(txtFrame.Text);

            double result;
            result = ((width + frame) * (height + frame))-(width * height);


            return result;
        }
    }
}
