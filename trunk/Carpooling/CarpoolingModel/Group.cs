using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel
{
    public class Group
    {
        int id;
        DateTime start;
        private LinkedList<GroupMember> listClient;
        private LinkedList<Message> listMessage;
        private Resource resource;
        private Route route;
        private Range startRange;
        private Range destinationRange;
        private float totalCost;
    }
}
