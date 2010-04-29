using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel
{
    public class Message
    {
        private int id;
        private string message;
        private DateTime time;
        private GroupMember member;

        #region Properties
        public int Id {
            get { return id; }
            set { id = value; }
        }

        public string MessageByMember {
            get { return message; }
            set { message = value; }
        }

        public DateTime Time {
            get { return time; }
            set { time = value; }
        }

        public GroupMember Member {
            get { return member; }
            set { member = value; }
        } 
        #endregion

        public Message(GroupMember member, string message) {
            this.member = member;
            this.message = message;
            time = DateTime.Now;
        }
        public Message(GroupMember member, string message, DateTime time)
            : this(member, message) {
            this.time = time;
        }
    }
}
