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
using System.Windows.Threading;

namespace Tehtava5b {

    public partial class GameWindow : Window {
        Snake snake = new Snake();
        private List<Point> bonusPoints = new List<Point>();
        private List<Point> snakePoints = new List<Point>();
        int maxBonus = 10;
        bool isPlaying = true;
        Random rand = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        Point currentPosition;
        int direction;
        int previousDirection;
        private enum MovingDirection {
            Up = 8,
            Down = 2,
            Left = 4,
            Right = 6
        };
        public GameWindow() {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(timerTick);
            timer.Start();

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            paintSnake(snake.StartingPoint);
            currentPosition = snake.StartingPoint;
            for (int i = 0; i < maxBonus; i++) {
                paintBonus(i);
            }
        }
        private void paintSnake(Point currentposition) {
            Ellipse newPoint = snake.addPoint();
            Canvas.SetTop(newPoint, currentposition.Y);
            Canvas.SetLeft(newPoint, currentposition.X);

            int count = Canvas.Children.Count;
            Canvas.Children.Add(newPoint);
            snakePoints.Add(currentposition);

            if (count > snake.Length) {
                Canvas.Children.RemoveAt(count - snake.Length + 9);
                snakePoints.RemoveAt(count - snake.Length);
            }
        }
        private void paintBonus(int index) {
            Point bonusPoint = new Point(rand.Next(5, 450), rand.Next(5, 450));
            Ellipse bonus = new Ellipse();
            bonus.Fill = Brushes.Red;
            bonus.Width = 10;
            bonus.Height = 10;

            Canvas.SetTop(bonus, bonusPoint.Y);
            Canvas.SetLeft(bonus, bonusPoint.X);
            Canvas.Children.Insert(index, bonus);
            bonusPoints.Insert(index, bonusPoint);
        }
        private void OnButtonKeyDown(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Down:
                    if (previousDirection != (int)MovingDirection.Up)
                        direction = (int)MovingDirection.Down;
                    break;
                case Key.Up:
                    if (previousDirection != (int)MovingDirection.Down)
                        direction = (int)MovingDirection.Up;
                    break;
                case Key.Left:
                    if (previousDirection != (int)MovingDirection.Right)
                        direction = (int)MovingDirection.Left;
                    break;
                case Key.Right:
                    if (previousDirection != (int)MovingDirection.Left)
                        direction = (int)MovingDirection.Right;
                    break;
                case Key.P:
                    if (isPlaying) {
                        timer.Stop();
                        isPlaying = false;
                    }
                    else {
                        timer.Start();
                        isPlaying = true;
                    }
                    break;
            }
            previousDirection = direction;
        }
        private void timerTick(object sender, EventArgs e) {
            switch (direction) {
                case (int)MovingDirection.Down:
                    currentPosition.Y += 1;
                    paintSnake(currentPosition);
                    break;
                case (int)MovingDirection.Up:
                    currentPosition.Y -= 1;
                    paintSnake(currentPosition);
                    break;
                case (int)MovingDirection.Left:
                    currentPosition.X -= 1;
                    paintSnake(currentPosition);
                    break;
                case (int)MovingDirection.Right:
                    currentPosition.X += 1;
                    paintSnake(currentPosition);
                    break;
            }
            if ((currentPosition.X < 5) || (currentPosition.X > 470) ||
                (currentPosition.Y < 5) || (currentPosition.Y > 450))
                GameOver();
            int j = 0;
            foreach (Point point in bonusPoints) {
                if ((Math.Abs(point.X - currentPosition.X) < snake.HeadSize) &&
                    (Math.Abs(point.Y - currentPosition.Y) < snake.HeadSize)) {
                    snake.Length += 10;
                    snake.Score += 10;
                    snake.Speed += 1.0f;
                    if (snake.Speed > snake.MaxSpeed) {
                        snake.Speed = snake.MaxSpeed;
                    }
                    bonusPoints.RemoveAt(j);
                    Canvas.Children.RemoveAt(j);
                    paintBonus(j);
                    break;
                }
                j++;
                tbScore.Text = "Score: " + snake.Score;
            }
            for (int q = 0; q < (snakePoints.Count - snake.HeadSize * 2); q++) {
                Point point = new Point(snakePoints[q].X, snakePoints[q].Y);
                if ((Math.Abs(point.X - currentPosition.X) < (snake.HeadSize)) &&
                     (Math.Abs(point.Y - currentPosition.Y) < (snake.HeadSize))) {
                    GameOver();
                    break;
                }
            }
        }
        private void GameOver() {
            timer.Stop();
            isPlaying = false;
        }
    }
}
