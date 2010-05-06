using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel
{
    public class Nation
    {
        int id;
        string name;

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
    }
}
