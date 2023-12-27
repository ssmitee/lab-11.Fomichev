using System;

namespace InheritanceExample
{
    
    
    public class Level1Class
    {
        protected string title;
        protected int pageCount;
        protected double price;

        public Level1Class(string title, int pageCount, double price)
        {
            this.title = title;
            this.pageCount = pageCount;
            this.price = price;
        }

        public double CalculateQuality()
        {
            return price / pageCount;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Page Count: " + pageCount);
            Console.WriteLine("Price: " + price);
        }
    }

    public class Level2Class : Level1Class
    {
        private int year; 

        public Level2Class(string title, int pageCount, double price, int year) : base(title, pageCount, price)
        {
            this.year = year;
        }

        public new double CalculateQuality()
        {
            int currentYear = DateTime.Now.Year;
            double quality = base.CalculateQuality();
            return quality - 0.2 * (currentYear - year);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите название книги:");
            string title = Console.ReadLine();

            Console.WriteLine("Введите количество страниц:");
            int pageCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите цену:");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите год издания:");
            int year = int.Parse(Console.ReadLine());

            Level1Class level1Object = new Level1Class(title, pageCount, price);
            Level2Class level2Object = new Level2Class(title, pageCount, price, year);

            Console.WriteLine("Информация о классе 1-го уровня:");
            level1Object.DisplayInfo();
            Console.WriteLine("Качество: " + level1Object.CalculateQuality());

            Console.WriteLine("Информация о классе 2-го уровня:");
            level2Object.DisplayInfo();
            Console.WriteLine("Качество: " + level2Object.CalculateQuality());
        }
    }
}