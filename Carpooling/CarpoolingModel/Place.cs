using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel
{
    public class Place
    {
        public static bool DESTINATION = true;
        public static bool STARTING_POINT = false;

        Nation state;
        Country country;
        City city;
        string address;
        bool inOrOut;

        #region Properties
        public Nation State
        {
            get { return state; }
            set { state = value; }
        }

        public Country Country
        {
            get { return country; }
            set { country = value; }
        }

        public City City
        {
            get { return city; }
            set { city = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public bool InOrOut
        {
            get { return inOrOut; }
            set { inOrOut = value; }
        } 
        #endregion
    }
}
