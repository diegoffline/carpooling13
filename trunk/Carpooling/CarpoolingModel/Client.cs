using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel {
    public class Client{
        private int id;
        private string name;
        private string surname;
        private string contactNumber;
        private string email;
        private string notes;
        private LinkedList<Resource> resource;

        public int Id {
            get { return id; }
            set { id = value; }
        }
        public string Name {
            get { return name; }
            set { name = value; }
        }
        public string Surname {
            get { return surname; }
            set { surname = value; }
        }
        public string ContactNumber {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public string Email {
            get { return email; }
            set { email = value; }
        }
        public string Notes {
            get { return notes; }
            set { notes = value; }
        }
    }
}
