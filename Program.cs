using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Document;
using log4net;

namespace AllMenorahs
{
    internal class MenorahRootClass
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log.Info("The is the first logging logging example using Log4Net!");
            //Instantiate a virtual menorah
            Console.WriteLine("The start of Menorah System\nMy Virtual Menorah has been instantiated.\n");
            VirtualMenorah myMenorah = new VirtualMenorah();
            return;
            //VirtualMenorah.dayOfChanukah currentChanukahDay = VirtualMenorah.dayOfChanukah.nonChanukahDay;
            myMenorah.DayOfChanukah(VirtualMenorah.dayOfChanukah.nonChanukahDay);
            System.Threading.Thread.Sleep(10000);
            //currentChanukahDay = VirtualMenorah.dayOfChanukah.dayOne;
            myMenorah.DayOfChanukah(VirtualMenorah.dayOfChanukah.dayOne);
            System.Threading.Thread.Sleep(20000);
            //currentChanukahDay = VirtualMenorah.dayOfChanukah.dayTwo;
            myMenorah.DayOfChanukah(VirtualMenorah.dayOfChanukah.dayTwo);
            System.Threading.Thread.Sleep(20000);
            //currentChanukahDay = VirtualMenorah.dayOfChanukah.dayThree;
            myMenorah.DayOfChanukah(VirtualMenorah.dayOfChanukah.dayThree);
            System.Threading.Thread.Sleep(20000);
            //currentChanukahDay = VirtualMenorah.dayOfChanukah.dayFour;
            myMenorah.DayOfChanukah(VirtualMenorah.dayOfChanukah.dayFour);
            System.Threading.Thread.Sleep(20000);
            //currentChanukahDay = VirtualMenorah.dayOfChanukah.dayFive;
            myMenorah.DayOfChanukah(VirtualMenorah.dayOfChanukah.dayFive);
            System.Threading.Thread.Sleep(20000);
            //currentChanukahDay = VirtualMenorah.dayOfChanukah.daySix;
            myMenorah.DayOfChanukah(VirtualMenorah.dayOfChanukah.daySix);
            System.Threading.Thread.Sleep(20000);
            //currentChanukahDay = VirtualMenorah.dayOfChanukah.daySeven;
            myMenorah.DayOfChanukah(VirtualMenorah.dayOfChanukah.daySeven);
            System.Threading.Thread.Sleep(20000);
            //currentChanukahDay = VirtualMenorah.dayOfChanukah.dayEight;
            myMenorah.DayOfChanukah(VirtualMenorah.dayOfChanukah.dayEight);
            System.Threading.Thread.Sleep(20000);
            //currentChanukahDay = VirtualMenorah.dayOfChanukah.nonChanukahDay;
            myMenorah.DayOfChanukah(VirtualMenorah.dayOfChanukah.nonChanukahDay);
            Console.WriteLine("\nThe end of the Menorah System\nHit any key to end this system.");
            Console.ReadLine();
        }
    }
    public class VirtualMenorah
    {
        public enum whichCandle
        {
            first = 0, second, third, fourth, fifth, sixth, seventh, eigth
        }
        public enum dayOfChanukah
        {
            nonChanukahDay = 8,
            dayOne = 0,
            dayTwo = 1,
            dayThree = 2,
            dayFour = 3,
            dayFive = 4,
            daySix = 5,
            daySeven = 6,
            dayEight = 7
        }
        enum MenorahState
        {
            active, inactive
        }
        internal int[] candlesPerChanukahDay = { 1, 2, 3, 4, 5, 6, 7, 8 };
        //        readonly public List<int> candlesPerChanukahDay = (int[] ={ 1, 2, 3, 4, 5, 6, 7, 8 });
        private MenorahState CurrentMenorahState { get; set; }
        public static List<Candle> myCandles = new List<Candle>() { new Candle(Candle.candleType.standard), new Candle(Candle.candleType.standard),
            new Candle(Candle.candleType.standard), new Candle(Candle.candleType.standard), new Candle(Candle.candleType.standard),
            new Candle(Candle.candleType.standard), new Candle(Candle.candleType.standard), new Candle(Candle.candleType.standard) };
        public void LightCandle(int candleToLight)
        {
            myCandles[candleToLight].LightCandle();
            foreach(Candle aCandle in myCandles)
            {
                aCandle.showState();
            }
        }
        public VirtualMenorah()
        {
            var listEnumerator = myCandles.GetEnumerator();
            var documentStore = new DocumentStore
            {
                ConnectionStringName = "RavenDB"
                //Url = "http://192.168.20.56:82",
                //DefaultDatabase = "Northwind"
            };
            documentStore.Initialize();
            using (var session = documentStore.OpenSession())
            {
                var p = session.Load<dynamic>("products/1");
                Console.WriteLine(p.Name);

            }
            //candlesPerChanukahDay.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            for (int i = 0; listEnumerator.MoveNext() == true; i++)
            {
                switch (i)
                {
                    case 0:
                        listEnumerator.Current.whichOne = "first";
                        break;
                    case 1:
                        listEnumerator.Current.whichOne = "second";
                        break;
                    case 2:
                        listEnumerator.Current.whichOne = "third";
                        break;
                    case 3:
                        listEnumerator.Current.whichOne = "fourth";
                        break;
                    case 4:
                        listEnumerator.Current.whichOne = "fifth";
                        break;
                    case 5:
                        listEnumerator.Current.whichOne = "sixth";
                        break;
                    case 6:
                        listEnumerator.Current.whichOne = "seventh";
                        break;
                    case 7:
                        listEnumerator.Current.whichOne = "eighth";
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            CurrentMenorahState = MenorahState.active;
            foreach (Candle individualCandle in myCandles)
            {
                individualCandle.showState();
            }
        }
        public void DayOfChanukah(dayOfChanukah theDay)
        {
            switch (theDay)
            {
                case dayOfChanukah.dayOne:
                    ChanukahDay(theDay);
                    break;
                case dayOfChanukah.dayTwo:
                    ChanukahDay(theDay);
                    break;
                case dayOfChanukah.dayThree:
                    ChanukahDay(theDay);
                    break;
                case dayOfChanukah.dayFour:
                    ChanukahDay(theDay);
                    break;
                case dayOfChanukah.dayFive:
                    ChanukahDay(theDay);
                    break;
                case dayOfChanukah.daySix:
                    ChanukahDay(theDay);
                    break;
                case dayOfChanukah.daySeven:
                    ChanukahDay(theDay);
                    break;
                case dayOfChanukah.dayEight:
                    ChanukahDay(theDay);
                    break;
                case dayOfChanukah.nonChanukahDay:
                    ChanukahDay(theDay);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        public void ChanukahDay(dayOfChanukah dayOfChanukah)
        {
            if (dayOfChanukah != VirtualMenorah.dayOfChanukah.nonChanukahDay)
            {
                string nameOfDay;
                switch(dayOfChanukah)
                {
                    case dayOfChanukah.dayOne:
                        nameOfDay = "first";
                        break;
                    case dayOfChanukah.dayTwo:
                        nameOfDay = "second";
                        break;
                    case dayOfChanukah.dayThree:
                        nameOfDay = "third";
                        break;
                    case dayOfChanukah.dayFour:
                        nameOfDay = "fourth";
                        break;
                    case dayOfChanukah.dayFive:
                        nameOfDay = "fifth";
                        break;
                    case dayOfChanukah.daySix:
                        nameOfDay = "sixth";
                        break;
                    case dayOfChanukah.daySeven:
                        nameOfDay = "seventh";
                        break;
                    case dayOfChanukah.dayEight:
                        nameOfDay = "eighth";
                        break;
                    default:
                        throw new NotImplementedException();
                }
                nameOfDay = nameOfDay + " day of Chanukah has arrived";
                Console.WriteLine($"\nThe {nameOfDay}.\n");
                for (dayOfChanukah theDay = dayOfChanukah; theDay >= VirtualMenorah.dayOfChanukah.dayOne; theDay--)
                {
                    myCandles[(int)theDay].LightCandle();
                    System.Threading.Thread.Sleep(5000);
                }
            }

        }
    }

    public class Candles : IEnumerator<Candle>, IEnumerable<Candle>
    {
        private List<Candle> candles = new List<Candle>();
        public Candle Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Candle> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Candle
    {
            public string whichOne;

            public enum brightness
        {
            off, high, medium, low, sputtering, dying
        };
        public enum candleType
        {
            standard, tall, custom, extended
        };

        public bool Lit { get; set; }
        public bool IsNew { get; set; }
        public int CurrentHeight { get; set; }
        public int InitialHeight { get; set; }
        public int BurnRate { get; set; }
        public int Temperature { get; set; }
        public candleType InternalCandleType { get; set; }
        public brightness CurrentBrightness { get; set; }
        public string Name { get; set; }
        

        public Candle()
        {
            Lit = false;
            CurrentBrightness = brightness.off;
                whichOne = "unknown";
        }
        public Candle(int initialHeight, bool used) : base()
        {
            InitialHeight = initialHeight;
            IsNew = !used;
        }
        public Candle(candleType theCandleType) : base()
        {
            InternalCandleType = theCandleType;
        }
        public void ExtinguishCandle()
        {
            Lit = false;
        }
        public void LightCandle()
        {
            Lit = true;
            CurrentBrightness = brightness.sputtering;
            System.Threading.Thread candleBurningThread = new System.Threading.Thread(candleBurning);
            candleBurningThread.IsBackground = true;
            candleBurningThread.Start();
        }
        public void candleBurning()
        {
            //int randomTime = System.Math.
            Random randomBurnTime = new Random();
            Lit = true;
            CurrentBrightness = brightness.sputtering;
            Console.WriteLine($"The {this.whichOne} candle is sputtering as it begins to light");
            System.Threading.Thread.Sleep(randomBurnTime.Next(750,1500));
            CurrentBrightness = brightness.low;
            Console.WriteLine($"The {this.whichOne} candle is just beginning to become bright as it begins to light");
            System.Threading.Thread.Sleep(randomBurnTime.Next(750, 1500));
            CurrentBrightness = brightness.high;
            Console.WriteLine($"The {this.whichOne} candle is bright as it is lit");
            System.Threading.Thread.Sleep(randomBurnTime.Next(2500, 7000));
            CurrentBrightness = brightness.dying;
            Console.WriteLine($"The {this.whichOne} candle is just beginning to extinguish as it begins to expire");
            System.Threading.Thread.Sleep(randomBurnTime.Next(1000, 1500));
            CurrentBrightness = brightness.sputtering;
            Console.WriteLine($"The {this.whichOne} candle is dying as it is expiring");
            System.Threading.Thread.Sleep(randomBurnTime.Next(750, 1500));
            CurrentBrightness = brightness.off;
            Console.WriteLine($"The {this.whichOne} candle has used up its burning fuel and is now extingushed");
        }
        public void CandleLit()
        {
            Lit = true;
            CurrentBrightness = brightness.high;
        }

        public void SputterCandle()
        {
            CurrentBrightness = brightness.sputtering;
            sputterCandle();
        }
        public void showState()
        {
            Console.WriteLine($"The {this.whichOne} candle is lit {this.CurrentBrightness.ToString()}" );
        }
        private void lightCandle()
        {
            //Implement routine to light a candle
        }
        private void sputterCandle()
        {
            //Implement sputtering of a candle
        }
        private void extinguishCandle()
        {
            //Implement extinguishing of a candle
        }
    }
}



