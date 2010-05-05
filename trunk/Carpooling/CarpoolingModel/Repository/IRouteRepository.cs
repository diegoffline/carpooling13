using System;
namespace CarpoolingModel.Repository {
    interface IRouteRepository {
        void addFirmRoute(CarpoolingModel.Route route, CarpoolingModel.Client client);
        void addRoute(CarpoolingModel.Route route);
        System.Collections.Generic.List<CarpoolingModel.Route> getRouteByDestination(CarpoolingModel.Place destination);
        CarpoolingModel.Route getRouteById(int idRoute);
        System.Collections.Generic.List<CarpoolingModel.Route> getRoutesByStart(CarpoolingModel.Place start);
        System.Collections.Generic.List<CarpoolingModel.Route> getRoutesByType(CarpoolingModel.RouteType type);
        void removeRoute(CarpoolingModel.Route route);
        void updateRoute(CarpoolingModel.Route route);
    }
}
