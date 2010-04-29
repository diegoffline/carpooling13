using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Text;
using CarpoolingDAL;

namespace CarpoolingModel.Repository {
    class ClientRepository : CarpoolingModel.Repository.IClientRepository {
        private static ClientRepository instanca = null;
        List<Client> listClient;
        private static CarpoolingDBADataContext db = new CarpoolingDBADataContext();
        private ClientRepository() {
            listClient = new List<Client>();
        }

        public static ClientRepository getInstanca() {
            if (instanca == null) {
                instanca = new ClientRepository();
            }
            return instanca;
        }

        public void addClient(Client client) {
            throw new System.NotImplementedException();
        }

        public void removeClient(Client client) {
            throw new System.NotImplementedException();
        }

        public void updateClient(Client client) {
            throw new System.NotImplementedException();
        }

        public Client getClientByUsername(string username) {
            throw new System.NotImplementedException();
        }

        public Client getClientByEmail(string email) {
            throw new System.NotImplementedException();
        }

        public List<Client> getAllClients() {
            List<Client> allClients = new List<Client>();
            foreach (CarpoolingDAL.Client o in db.Clients) {
                allClients.Add(createClientFromDALClient(o));
            }
            return allClients;
        }

        public Client createClientFromDALClient(CarpoolingDAL.Client o) {
            Client c = new Client(o.username, o.password);
            c.ContactNumber = o.contactNumber;
            c.Email = o.email;
            c.Id = o.idClient;
            c.Name = o.name;
            c.Notes = o.notes;
            c.Surname = o.surname;
            foreach (CarpoolingDAL.Resource item in o.Resources) {
                c.addResource(createResourceFromDALResource(item));
            }
            //TODO
            //foreach (CarpoolingDAL.Route item in collection) {
                
            //}
            return c;
        }

        public Resource createResourceFromDALResource(CarpoolingDAL.Resource item) {
            throw new NotImplementedException();
        }

        public bool existClient(string clientUsername) {
            throw new System.NotImplementedException();
        }

        public List<GroupMember> getGroupMembers(Group group) {
            throw new System.NotImplementedException();
        }

        public void addGroupMember(GroupMember groupMember) {
            throw new System.NotImplementedException();
        }

    }
}
