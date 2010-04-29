using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel
{
    public class Client
    {
        private int id;
        private string name;
        private string surname;
        private string contactNumber;
        private string email;
        private string notes;
        private string username;
        private string password;
        private List<Resource> listResource;
        private List<Route> listFirmRoute;

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

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
        
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        } 
        #endregion

        public List<Resource> getClientResources() {
            throw new System.NotImplementedException();
        }

        public void addResource(Resource resource) {
            throw new System.NotImplementedException();
        }

        public List<Resource> getAllResource() {
            throw new System.NotImplementedException();
        }

        public void removeResource(Resource resource) {
            throw new System.NotImplementedException();
        }

        public void updateResource(Resource resource) {
            throw new System.NotImplementedException();
        }

        public void addFirmRoute(Route firmRoute) {
            throw new System.NotImplementedException();
        }

        public void removeFirmRoute(Route route) {
            throw new System.NotImplementedException();
        }

        public List<Route> getAllFirmRoutes() {
            throw new System.NotImplementedException();
        }

        public Client() { 
        
        }
        public Client(Client client) {
            this.id = client.id;
            this.name = client.name;
            this.surname = client.surname;
            this.contactNumber = client.contactNumber;
            this.email = client.email;
            this.notes = client.notes;
            this.username = client.username;
            this.password = client.password;
            listResource = client.getClientResources();
        }
        public Client(string username, string password) {
            this.username = username;
            this.password = password;
            listResource = new List<Resource>();
        }

    }
}
