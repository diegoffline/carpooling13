using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarpoolingModel.Types;
using CarpoolingDAL;

namespace CarpoolingModel.Repository {
    public class RouteRepository : CarpoolingModel.Repository.IRouteRepository {
        private static RouteRepository instanca = null;
        private static CarpoolingDBADataContext db = new CarpoolingDBADataContext();

        private RouteRepository() {
        }
        public static RouteRepository getInstanca() {
            if (instanca == null) {
                instanca = new RouteRepository();
            }
            return instanca;
        }

        public void addRoute(Route route) {
            try {
                db.Routes.InsertOnSubmit(RepositoryUtility.createDALRouteFromRoute(route));
                db.StartFinishes.InsertOnSubmit(RepositoryUtility.createDALStartFinishFromPlace(route.StartingPoint));
                db.StartFinishes.InsertOnSubmit(RepositoryUtility.createDALStartFinishFromPlace(route.Destination));
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

        public void removeRoute(Route route) {
            try {
                CarpoolingDAL.Route rt = db.Routes.Single(o => o.idRoute == route.Id);
                db.Routes.DeleteOnSubmit(rt);
                var places = db.StartFinishes.Where(s => s.idRoute == route.Id);

                foreach (CarpoolingDAL.StartFinish res in places) {
                    db.StartFinishes.DeleteOnSubmit(res);
                }
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }

            //return true;
        }

        public void removeFirmRoute(Route route, Client client) {
            try {
                CarpoolingDAL.FirmRoute frt = db.FirmRoutes.Single(o => o.idClient == client.Id && o.idRoute == route.Id);
                db.FirmRoutes.DeleteOnSubmit(frt);
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }

            //return true;
        }

        public void updateRoute(Route route) {
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
                foreach (Resource item in client.getAllResource()) {
                    if (rer.existResource(item.Id)) {
                        rer.updateResource(item);
                    } else {
                        rer.addResource(item);
                    }
                }
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }

            //return true;
        }

        public Route getRouteById(int idRoute) {
            throw new System.NotImplementedException();
        }

        public List<Route> getRoutesByType(RouteType type) {
            throw new System.NotImplementedException();
        }

        public List<Route> getRoutesByStart(Place start) {
            throw new System.NotImplementedException();
        }

        public List<Route> getRouteByDestination(Place destination) {
            throw new System.NotImplementedException();
        }

        public void addFirmRoute(Route route, Client client) {
            throw new System.NotImplementedException();
        }

        public bool existFirmRoute(int routeId, int clientId) {
            CarpoolingDAL.FirmRoute oldOne = db.FirmRoutes.Single(o => o.idRoute == routeId && o.idClient == clientId);
            if (oldOne != null) return true;
            else return false;
        }

        public bool existsRoute(int routeId) {
            CarpoolingDAL.Route oldOne = db.Routes.Single(o => o.idRoute == routeId);
            if (oldOne != null) return true;
            else return false;
        }
    }
}
