using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarpoolingModel.Types;

namespace CarpoolingModel
{
    public class Resource
    {
        private int id;
        private string name;
        private DateTime age;
        private int seatNumber;
        private float consumption;
        private ResourceType type;

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

        public DateTime Age
        {
            get { return age; }
            set { age = value; }
        }

        public int SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; }
        }

        public float Consumption
        {
            get { return consumption; }
            set { consumption = value; }
        }

        public ResourceType Type
        {
            get { return type; }
            set { type = value; }
        } 
        #endregion

        public Resource(int seatNum, ResourceType type) {
            this.seatNumber = seatNum;
            this.type = type;
        }
        public Resource(int seatNum, ResourceType type, string name, DateTime age, float consumption):this(seatNum,type) {
            this.name = name;
            this.age = age;
            this.consumption = consumption;
        }
    }
}
