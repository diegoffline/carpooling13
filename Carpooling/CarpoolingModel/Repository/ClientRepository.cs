using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CarpoolingDAL;

namespace CarpoolingModel.Repository {
    public class ClientRepository : CarpoolingModel.Repository.IClientRepository{
        private static ClientRepository instanca = null;
        private static CarpoolingDBADataContext db = new CarpoolingDBADataContext();
        private ClientRepository() {

        }

        public static ClientRepository getInstanca() {
            if (instanca == null) {
                instanca = new ClientRepository();
            }
            return instanca;
        }

        public void addClient(Client client) {
            try {
                db.Clients.InsertOnSubmit(RepositoryUtility.createDALClientFromClient(client));
                db.SubmitChanges();
            } catch (Exception) {
                //TODO saznaj koje su iznimke
                //iznimka se generira ako se narusi bilo koje pravilo vezano uz primary key ili foreign key. Znači, iznimka se 
                //generira ako se pokuša dodati osoba koja ima JMBAG koji koristi neka druga osoba, zatim ako se pod osoba.sifUloga 
                //stavi neki broj kojeg nema u tablici Uloga, itd..
                //return false;
            }
            //return true;
        }

        public void removeClient(Client client) {
            try {
                CarpoolingDAL.Client cl = db.Clients.Single(o => o.idClient == client.Id);
                db.Clients.DeleteOnSubmit(cl);
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }
            CarpoolingDAL.Route r = new CarpoolingDAL.Route();
            //return true;
        }

        public void updateClient(Client client) {
            try {
                RouteRepository rr = RouteRepository.getInstanca();
                ResourceRepository rer = ResourceRepository.getInstanca();
                CarpoolingDAL.Client oldOne = db.Clients.Single(o => o.idClient == client.Id);
                oldOne.contactNumber = client.ContactNumber;
                oldOne.email = client.Email;
                oldOne.name = client.Name;
                oldOne.notes = client.Notes;
                oldOne.password = client.Password;
                oldOne.surname = client.Surname;
                oldOne.username = client.Username;
                foreach (Route item in client.getAllFirmRoutes()) {
                    if (rr.existFirmRoute(item.Id, client.Id)) {
                        rr.updateRoute(item);
                    } else {
                        rr.addFirmRoute(item, client);
                    }
                }
                foreach (Resource item in client.getAllResources()) {
                    if (rer.existResource(item.Id)) {
                        rer.updateResource(item);
                    } else {
                        rer.addResource(item, client);
                    }
                }
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }

            //return true;
        }

        public Client getClientByUsername(string username) {
            CarpoolingDAL.Client cl = new CarpoolingDAL.Client();
            try {
                var query = db.Clients.Where(o => o.username == username).First();
                cl = query as CarpoolingDAL.Client;
            } catch (Exception) {
                cl = null;
            }

            return RepositoryUtility.createClientFromDALClient(cl);
        }

        public Client getClientByEmail(string email) {
            CarpoolingDAL.Client cl = new CarpoolingDAL.Client();
            try {
                var query = db.Clients.Where(o => o.email == email).First();
                cl = query as CarpoolingDAL.Client;
            } catch (Exception) {
                cl = null;
            }

            return RepositoryUtility.createClientFromDALClient(cl);
        }

        public List<Client> getAllClients() {
            List<Client> allClients = new List<Client>();
            foreach (CarpoolingDAL.Client o in db.Clients) {
                allClients.Add(RepositoryUtility.createClientFromDALClient(o));
            }
            return allClients;
        }

        public bool existClient(string clientUsername) {
            CarpoolingDAL.Client oldOne = db.Clients.Single(o => o.username == clientUsername);
            if (oldOne != null) return true;
            else return false;
        }

        public List<GroupMember> getGroupMembers(Group group) {

            List<GroupMember> listMem = new List<GroupMember>();
            var members = db.GroupMembers.Where(s => s.idGroup == group.Id);

            foreach (CarpoolingDAL.GroupMember mem in members) {
                listMem.Add(RepositoryUtility.createGroupMemberFromDALGroupMember(mem as CarpoolingDAL.GroupMember));
            }
            return listMem;
        }

    }
}
