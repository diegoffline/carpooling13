﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel
{
    public class City
    {
        int id;
        string name;
        string postalNumer;

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PostalNumer
        {
            get { return postalNumer; }
            set { postalNumer = value; }
        } 
        #endregion
    }
}
