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
                PlaceRepository pr = PlaceRepository.getInstanca();
                db.Routes.InsertOnSubmit(RepositoryUtility.createDALRouteFromRoute(route));
                pr.addPlace(route.StartingPoint, route);
                pr.addPlace(route.Destination,route);
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
                PlaceRepository pr = PlaceRepository.getInstanca();
                ResourceRepository rer = ResourceRepository.getInstanca();
                CarpoolingDAL.Route oldOne = db.Routes.Single(o => o.idRoute == route.Id);
                oldOne.name = route.Name;
                oldOne.path = route.Path.convertToBinary();
                oldOne.routeType = route.Type.Id;
                pr.updatePlace(route.StartingPoint, route);
                pr.updatePlace(route.Destination, route);
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }

            //return true;
        }

        public Route getRouteById(int idRoute) {
            PlaceRepository pr = PlaceRepository.getInstanca();
            CarpoolingDAL.Route rt = new CarpoolingDAL.Route();
            Route rrt = new Route();
            try {
                var query = db.Routes.Where(o => o.idRoute == idRoute).First();
                rt = query as CarpoolingDAL.Route;
                rrt.Id = rt.idRoute;
                rrt.Name = rt.name;
                rrt.Path.PathDim = rt.path.ToString();
                rrt.Type.Id = rt.routeType;
                rrt.Type.Name = ((db.RouteTypes.Where(o => o.idRouteType == rt.routeType).First()) as CarpoolingDAL.RouteType).name;
                rrt.Destination = pr.getPlace(idRoute, Place.DESTINATION);
                rrt.StartingPoint = pr.getPlace(idRoute, Place.STARTING_POINT);
            } catch (Exception) {
                rrt = null;
            }

            return rrt;
        }

        public List<Route> getRoutesByType(CarpoolingModel.Types.RouteType type) {
            List<Route> listRt = new List<Route>();
            var routes = db.Routes.Where(s => s.routeType == type.Id);

            foreach (CarpoolingDAL.Route res in routes) {
                listRt.Add(getRouteById(res.idRoute));
            }
            return listRt;
        }

        public List<Route> getRoutesByStart(Place start) {
            return getRoutesByPlace(start);
        }

        public List<Route> getRouteByDestination(Place destination) {
            return getRoutesByPlace(destination);
        }

        private List<Route> getRoutesByPlace(Place place) {
            List<Route> listRt = new List<Route>();
            var places = db.StartFinishes.Where(s => s.direction == place.InOrOut && s.idCity == place.City.Id);

            foreach (CarpoolingDAL.StartFinish res in places) {
                listRt.Add(getRouteById(res.idRoute));
            }
            return listRt;
        }

        public void addFirmRoute(Route route, Client client) {
            try {
                CarpoolingDAL.FirmRoute fr = new FirmRoute();
                fr.idClient = client.Id;
                fr.idRoute = route.Id;
                db.FirmRoutes.InsertOnSubmit(fr);
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
