using ClockPatienceApp.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatienceApp.GameItems
{
    /// <summary>
    /// Class <c>Clock</c> represents the 13 hour hand clock. It consists of a double nested string list, with each list representing an hour hand.
    /// </summary>
    internal class Clock
    {
        // Double nested string list representing an hour hand which will hold another list string representing a pile of game cards.
        private List<List<string>>? _hourHands;

        // Accessors for the HourHands string list
        public List<List<string>>? HourHands
        {
            get { return _hourHands; }
            set { _hourHands = value; }
        }

        // Constructor for the clock class
        public Clock()
        {
            HourHands = new List<List<string>>();
        }


    }
}
