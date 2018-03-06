using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{

    class Program
    {
        /// <summary>
        /// global variable used to change the menu to the setup menu when current LocationID is "1"
        /// </summary>
        public static bool Setup { get; set; }

        /// <summary>
        /// instantiate the game controller, passing all control to the new Controller object
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Controller gameController = new Controller();

            Console.ReadKey();
        }


    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dictionary
//{
//    public enum TreasureName
//    {
//        None,
//        Gold,
//        Silver,
//        Bronze,
//        Diamond
//    }

//    class TreasureItem
//    {
//        public TreasureName Name { get; set; }
//        public int Count { get; set; }
//    }


//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Dictionary<TreasureName, int> treasureInfo = new Dictionary<TreasureName, int>();
//            List<TreasureItem> myTreasure;
//            double totalWorth = 0;

//            treasureInfo.Add(TreasureName.Gold, 10);
//            treasureInfo.Add(TreasureName.Silver, 5);
//            treasureInfo.Add(TreasureName.Bronze, 1);
//            treasureInfo.Add(TreasureName.Diamond, 100);

//            foreach (var treasure in treasureInfo)
//            {
//                Console.WriteLine($"{treasure.Key}: {treasure.Value}");
//            }

//            Console.WriteLine();

//            myTreasure = InitializeTreasure();

//            foreach (TreasureItem item in myTreasure)
//            {
//                Console.WriteLine($"\t{item.Name}\t{item.Count}");
//                totalWorth += item.Count * treasureInfo[item.Name];

//            }

//            Console.WriteLine();
//            Console.WriteLine($"Total Worth: {totalWorth}");
//            Console.WriteLine();
//            Console.WriteLine("Press any key to continue.");
//            Console.ReadKey();
//        }

//        static List<TreasureItem> InitializeTreasure()
//        {
//            List<TreasureItem> theTreasure = new List<TreasureItem>()
//            {
//                new TreasureItem()
//                {
//                    Name = TreasureName.Gold,
//                    Count = 4
//                },

//                new TreasureItem()
//                {
//                    Name = TreasureName.Diamond,
//                    Count = 1
//                },

//                new TreasureItem()
//                {
//                    Name = TreasureName.Bronze,
//                    Count = 23
//                }
//            };

//            return theTreasure;
//        }
//    }
//}


