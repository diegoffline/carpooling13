using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel
{
    public class TravelCost : CarpoolingModel.ITravelCost
    {
        private static TravelCost instanca = null;

        private TravelCost() {
        }
        public static TravelCost getInstanca() {
            if (instanca == null) {
                instanca = new TravelCost();
            }
            return instanca;
        }

        public float calculateCosts(Group group) {
            throw new System.NotImplementedException();
        }
    }
}
