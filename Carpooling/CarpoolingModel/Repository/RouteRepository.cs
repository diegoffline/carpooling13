using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel.Repository
{
    public class RouteRepository : CarpoolingModel.Repository.IRouteRepository
    {
        private List<Route> listRoute;
        private static RouteRepository instanca = null;
 
        private RouteRepository() {
            listRoute = new List<Route>();
        }
        public static RouteRepository getInstanca() {
            if (instanca == null) {
                instanca = new RouteRepository();
            }
            return instanca;
        }

        public void addRoute(Route route)
        {
            throw new System.NotImplementedException();
        }

        public void removeRoute(Route route)
        {
            throw new System.NotImplementedException();
        }

        public void updateRoute(Route route)
        {
            throw new System.NotImplementedException();
        }

        public Route getRouteById(int idRoute)
        {
            throw new System.NotImplementedException();
        }

        public List<Route> getRoutesByType(RouteType type)
        {
            throw new System.NotImplementedException();
        }

        public List<Route> getRoutesByStart(Place start)
        {
            throw new System.NotImplementedException();
        }

        public List<Route> getRouteByDestination(Place destination)
        {
            throw new System.NotImplementedException();
        }

        public void addFirmRoute(Route route, Client client) {
            throw new System.NotImplementedException();
        }
    }
}
