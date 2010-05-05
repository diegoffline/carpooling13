using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarpoolingModel.Types;

namespace CarpoolingModel
{
    public class Group
    {
        private List<GroupMember> listClient;
        private List<Message> listMessage;
        private List<Resource> listResource;
        int id;
        DateTime startTime;
        private Route route;
        private Range startRange;
        private Range destinationRange;
        private float totalCost;
        private string name;
        private GroupType type;

        #region Properties
        public int Id {
            get { return id; }
            set { id = value; }
        }

        public DateTime StartTime {
            get { return startTime; }
            set { startTime = value; }
        }

        public Route Route {
            get { return route; }
            set { route = value; }
        }

        public Range StartRange {
            get { return startRange; }
            set { startRange = value; }
        }

        public Range DestinationRange {
            get { return destinationRange; }
            set { destinationRange = value; }
        }

        public float TotalCost {
            get { return totalCost; }
            set { totalCost = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public GroupType Type {
            get { return type; }
            set { type = value; }
        } 
        #endregion

        public Group() {
            listClient = new List<GroupMember>();
            listMessage = new List<Message>();
            listResource = new List<Resource>();
        }
        public Group(Route route, DateTime startTime) : this(){
            this.route = route;
            this.startTime = startTime;
        }
        public Group(Route route, DateTime startTime, Range startRange, GroupType type): this(route,startTime) {
            this.startRange = startRange;
            this.type = type;
        }
        public Group(Route route, DateTime startTime, Range startRange, GroupType type, string name, Range destinationRange)
            : this(route, startTime, startRange, type) {
            this.name = name;
            this.destinationRange = destinationRange;
        }

        public void addGroupMember(GroupMember groupMember) {
            throw new System.NotImplementedException();
        }

        public void removeGroupMember(GroupMember groupMember) {
            throw new System.NotImplementedException();
        }

        public void addMessage(Message message) {
            throw new System.NotImplementedException();
        }

        public List<Message> getMessages() {
            throw new System.NotImplementedException();
        }

        public List<GroupMember> getGroupMembers() {
            throw new System.NotImplementedException();
        }

        public List<Resource> getResources() {
            throw new System.NotImplementedException();
        }

        public List<Message> getMessagesByMember(Client member) {
            throw new System.NotImplementedException();
        }
    }
}
