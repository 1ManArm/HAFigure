namespace HAFigure
{
    interface INgon
    {
        double Height { get; set; }
        double BaseLength { get; set; }
        double AngleBaseAdjacent { get; set; }
        int Sides { get; set; }
        double[] SideLengths { get; set; }
        double Area { get; }
        double Perimeter { get; }
    }
    class SimpleNgon : INgon
    {
        public double Height { get; set; }
        public double BaseLength { get; set; }
        public double AngleBaseAdjacent { get; set; }
        public int Sides { get; set; }
        public double[] SideLengths { get; set; }
        public double Area
        {
            get
            {
                return 0.5 * BaseLength * Height;
            }
        }
        public double Perimeter
        {
            get
            {
                double perim = 0;
                foreach (double sideLength in SideLengths)
                {
                    perim += sideLength;
                }
                return perim;
            }
        }
    }
    class CompositeFigure
    {
        public INgon[] Ngons { get; set; }
        public double GetTotalArea()
        {
            double totalArea = 0;
            foreach (INgon ngon in Ngons)
            {
                totalArea += ngon.Area;
            }
            return totalArea;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleNgon ngon1 = new SimpleNgon()
            {
                Height = 4,
                BaseLength = 6,
                AngleBaseAdjacent = 60,
                Sides = 3,
                SideLengths = new double[] { 6, 6, 6 }
            };

            SimpleNgon ngon2 = new SimpleNgon()
            {
                Height = 5,
                BaseLength = 8,
                AngleBaseAdjacent = 90,
                Sides = 4,
                SideLengths = new double[] { 5, 5, 5, 5 }
            };

            CompositeFigure figure = new CompositeFigure()
            {
                Ngons = new INgon[] { ngon1, ngon2 }
            };

            double totalArea = figure.GetTotalArea();
            Console.WriteLine("Суммарная площадь составной фигуры: " + totalArea);

            SimpleNgon invalidNgon = new SimpleNgon()
            {
                Height = -2,
                BaseLength = 4,
                AngleBaseAdjacent = 45,
                Sides = 5,
                SideLengths = new double[] { 3, 4, 5, 6, 7 }
            };
            Console.WriteLine("Здесь могла бы быть ваша реклама");
        }
    }
}