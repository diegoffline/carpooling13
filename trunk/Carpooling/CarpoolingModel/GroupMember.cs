using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel {
    public class GroupMember: Client {

        private string notesInGroup;
        private Resource resource;

        #region Properties
        public string NotesInGroup {
            get { return notesInGroup; }
            set { notesInGroup = value; }
        }

        public Resource ResourceInGroup {
            get { return resource; }
            set { resource = value; }
        } 
        #endregion

        public GroupMember(Client client, Resource resource): base(client) {
            this.resource = resource;
        }
        public GroupMember(Client client, Resource resource, string notes) : this(client, resource) {
            this.notesInGroup = notes;
        }
    }
}
