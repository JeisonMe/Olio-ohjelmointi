using System;

namespace Nuoli_kauppa
{
    class Nuoli
    {
        private int woodPrice = 3;
        private int ironPrice = 5;
        private int diamondPrice = 50;
        private int leafPrice = 0;
        private int chickenFeatherPrice = 1;
        private int roosterFeatherPrice = 5;
        private float shaftPrice = 0.05f;

        private string tip;
        private string fletching;
        private int shaft;

        public void PLAYPLAYPLAY()
        {
            TipMaterial();
            FletchingMaterial();
            ShaftLength();
            BigMafsArrow();
            PalautaHinta();
        }

        private void TipMaterial()
        {
            tip = "";
            while (tip != "puu" && tip != "teräs" && tip != "timantti")
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Minkänlainen kärki? (puu, teräs vai timantti?");
                tip = Console.ReadLine();
            }
        }

        private void FletchingMaterial()
        {
            fletching = "";
            while (fletching != "lehti" && fletching != "kanansulka" && fletching != "kotkansulka")
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Minkänlaiset sulat? (lehti, kanansulka, vai kotkansulka");
                fletching = Console.ReadLine();
            }
        }

        private void ShaftLength()
        {
            shaft = 0;
            while (shaft < 60 || shaft > 100)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Nuolen pituus (60-100cm)");
                shaft = int.Parse(Console.ReadLine());
            }
        }

        private void BigMafsArrow()
        {
            float tipPrice = 0;
            float fletchingPrice = 0;
            float shaftBrice = shaft * shaftPrice;

            if (tip == "puu")
                tipPrice = woodPrice;
            else if (tip == "teräs")
                tipPrice = ironPrice;
            else if (tip == "timantti")
                tipPrice = diamondPrice;

            if (fletching == "lehti")
                fletchingPrice = leafPrice;
            else if (fletching == "kanansulka")
                fletchingPrice = chickenFeatherPrice;
            else if (fletching == "kotkansulka")
                fletchingPrice = roosterFeatherPrice;

            arrowPrice = tipPrice + fletchingPrice + shaftBrice;

        }

        private void PalautaHinta()
        {
            Console.WriteLine($"Nuolen hinta on {arrowPrice} kultaa.");
        }

        public float GetterShitterArrowPrice()
        {
            return arrowPrice;
        }

        public string GetterShitterTip()
        {
            return tip;
        }

        public string GetterShitterFletching()
        {
            return fletching;
        }

        public int GetterShitterShaft()
        {
            return shaft;
        }

        private float arrowPrice { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Nuoli arrow = new Nuoli();
            arrow.PLAYPLAYPLAY();
        }
    }
}