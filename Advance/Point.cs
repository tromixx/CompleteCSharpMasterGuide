using System:

namespace Methods
{
    public class Point(Parameters)
    {

        public int X;
        public int Y;
        public Point(int x, int y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Move(int x, int y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Move(Point newLocation)
        {
            if (newLocation == null)
                throw new ArgumentNullExeption("newLocation");

            Move(newLocation.X, newLocation.Y);
        }
        
    }
    
}
