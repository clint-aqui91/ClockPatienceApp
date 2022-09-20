using ClockPatienceApp.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatienceApp.GameItems
{
    internal class Clock
    {
          private List<List<string>>? _hourHands;
        //private List<string>? _pileList;

        class ClockList : Clock
        {
            private List<List<string>>? _hourHands;

            public List<List<string>>? HourHands
            {
                get { return _hourHands; }
                set { _hourHands = value; }
            }
        }

     //   class PileList : Clock
      //  {
      //      private List<string>? _pileList;
       //     public List<string>? PileOfCards
       //     {
       //         get { return _pileList; }
       //         set { _pileList = value; }
       //     }
     //   }
        public List<List<string>>? HourHands
         {
             get { return _hourHands; }
              set { _hourHands = value; }
          }

        public Clock()
        {
            //Clock clock = new Clock();
            HourHands = new List<List<string>>();
            List<string>? pileList = new List<string>();
            HourHands.Capacity = 12;
            for (int i = 0; i < 13; i++)
            {
                //HourHands.Add(new List<string>());
                HourHands.Add(new List<string>());
                
            }

        }

        //  public List<string>? PileList
        //  {
        //      get { return _pileList; }
        //      set { _pileList = value; }
        //   }

        //   public Clock()
        //  {
        //     ClockList clockList = new ClockList();
        //     clockList.HourHands.Capacity = 12;
        //     PileList pileList = new PileList();
        //     pileList.PileOfCards.Capacity = 3;
        //for (int i = 0; i < 13; i++)
        //{
        //    ClockList.HourHands.Add(PileOfCards);
        //}
        //PileList = new List<string>();
        //    }
    /*
        public ClockList()
        {
            ClockList clockList = new ClockList();
            clockList.HourHands = new List<List<string>>();
            clockList.HourHands.Capacity = 12;
            for (int i = 0; i < 12; i++)
            {
                clockList.HourHands.Add(new List<string>());
            }
            
       //     return clockList;
        */
        

    }
}
