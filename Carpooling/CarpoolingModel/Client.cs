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

        public void addResource(Resource resource) {
            listResource.Add(resource);
        }

        public List<Resource> getAllResources() {
            return listResource;
        }

        public void removeResource(Resource resource) {
            listResource.Remove(resource);
        }

        public void addFirmRoute(Route firmRoute) {
            listFirmRoute.Add(firmRoute);
        }

        public void removeFirmRoute(Route route) {
            listFirmRoute.Remove(route);
        }

        public List<Route> getAllFirmRoutes() {
            return listFirmRoute;
        }

        public Client() {
            listFirmRoute = new List<Route>();
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
            listResource = client.getAllResources();
        }
        public Client(string username, string password) {
            this.username = username;
            this.password = password;
            listResource = new List<Resource>();
        }

    }
}
