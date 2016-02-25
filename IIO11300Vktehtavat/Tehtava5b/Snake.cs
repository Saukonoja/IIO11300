using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tehtava5b {
    class Snake {
        #region ATTRIBUTES
        private float speed = 1f;
        private float maxSpeed = 6f;
        private int length = 32;
        private float headSize = 8f;
        private int score = 0;
        private Point startingPoint = new Point(300, 200);
        #endregion
        #region PROPERTIES
        public float Speed { 
            get { return speed; }
            set { speed = value; }
        }
        public float MaxSpeed { get { return maxSpeed; } }

        public int Length {
            get { return length; }
            set { length = value; }
        }
        public float HeadSize{ get { return headSize; } }

        public int Score {
            get { return score; }
            set { score = value; }
        }
        public Point StartingPoint { get { return startingPoint; } }
        #endregion
        #region METHODS
        public Ellipse addPoint() {
            Ellipse point = new Ellipse();
            point.Fill = Brushes.Green;
            point.Width = 10;
            point.Height = 10;
            return point;
        }
        #endregion
    }
}
