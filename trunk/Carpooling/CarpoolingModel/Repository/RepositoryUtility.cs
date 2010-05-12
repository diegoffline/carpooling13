using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarpoolingModel.Types;

namespace CarpoolingModel.Repository {
    class RepositoryUtility {

        public static Client createClientFromDALClient(CarpoolingDAL.Client o) {
            Client c = new Client(o.username, o.password);
            c.ContactNumber = o.contactNumber;
            c.Email = o.email;
            c.Id = o.idClient;
            c.Name = o.name;
            c.Notes = o.notes;
            c.Surname = o.surname;
            foreach (CarpoolingDAL.Resource item in o.Resources) {
                c.addResource(RepositoryUtility.createResourceFromDALResource(item));
            }
            RouteRepository rr = RouteRepository.getInstanca();
            foreach (CarpoolingDAL.FirmRoute item in o.FirmRoutes) {
                c.addFirmRoute(rr.getRouteById(item.idRoute));
            }
            return c;
        }

        public static Resource createResourceFromDALResource(CarpoolingDAL.Resource item) {
            Resource nr = new Resource();
            nr.Age = item.age;
            nr.Consumption = item.consumption;
            nr.Id = item.idResource;
            nr.Name = item.name;
            nr.SeatNumber = item.seatNumber;
            nr.Type = RepositoryUtility.createResTyFromDALResTy(item.ResourceType1);
            return nr;
        }

        internal static CarpoolingDAL.Client createDALClientFromClient(Client client) {
            CarpoolingDAL.Client nc = new CarpoolingDAL.Client();
            nc.contactNumber = client.ContactNumber;
            nc.email = client.Email;
            nc.name = client.Name;
            nc.notes = client.Notes;
            nc.password = client.Password;
            nc.surname = client.Surname;
            nc.username = client.Username;
            return nc;
        }

        internal static CarpoolingDAL.GroupMember createDALGroupMemberFromGroupMember(GroupMember groupMember, Group group)
        {
            CarpoolingDAL.GroupMember ngm = new CarpoolingDAL.GroupMember();
            ngm.idClient = groupMember.Id;
            ngm.idGroup = group.Id;
            ngm.notesInGroup = groupMember.NotesInGroup;
            ngm.resource = groupMember.ResourceInGroup.Id;
            return ngm;
        }

        internal static GroupMember createGroupMemberFromDALGroupMember(CarpoolingDAL.GroupMember groupMember) {
            Client cl = createClientFromDALClient(groupMember.Client);
            Resource r = createResourceFromDALResource(groupMember.Resource1);
            GroupMember ngm = new GroupMember(cl, r);
            ngm.NotesInGroup = groupMember.notesInGroup;
            return ngm;
        }

        internal static CarpoolingDAL.Resource createDALResourceFromResource(Resource resource, Client client) {
            CarpoolingDAL.Resource nr = new CarpoolingDAL.Resource();
            nr.active = true;
            nr.age = resource.Age;
            nr.consumption = resource.Consumption;
            nr.name = resource.Name;
            nr.resourceType = resource.Type.Id;
            nr.seatNumber = resource.SeatNumber;
            nr.owner = client.Id;
            return nr;
        }

        internal static CarpoolingDAL.ResourceType createDALResourceTyFromResourceTy(ResourceType resourceType) {
            CarpoolingDAL.ResourceType nrt = new CarpoolingDAL.ResourceType();
            nrt.name = resourceType.Name;
            return nrt;
        }

        internal static ResourceType createResTyFromDALResTy(CarpoolingDAL.ResourceType o) {
            return new ResourceType(o.idResourceType, o.name);  
        }

        internal static CarpoolingDAL.Group createDALGroupFromGroup(Group group) {
            CarpoolingDAL.Group ng = new CarpoolingDAL.Group();
            ng.destinationRange = group.DestinationRange.RangeDim;
            ng.groupType = group.Type.Id;
            ng.name = group.Name;
            ng.route = group.Route.Id;
            ng.startRange = group.StartRange.RangeDim;
            ng.startTime = group.StartTime;
            ng.totalCost = group.TotalCost;
            return ng;
        }

        internal static Group createGroupFromDALGroup(CarpoolingDAL.Group g) {
            Group ng = new Group();
            ng.Id = g.idGroup;
            ng.Name = g.name;
            ng.StartTime = g.startTime;
            ng.TotalCost = g.totalCost;
            ng.Type = createGroupTypeFromDALGType(g.GroupType1);

            Repository.RouteRepository rr = Repository.RouteRepository.getInstanca();
            ng.Route = rr.getRouteById(g.route);

            ng.DestinationRange = new Range(g.destinationRange);
            ng.StartRange = new Range(g.startRange);

            foreach (CarpoolingDAL.GroupMember item in g.GroupMembers) {
                ng.addGroupMember(createGroupMemberFromDALGroupMember(item));
            }
            Repository.MessageRepository mr = MessageRepository.getInstanca();
            foreach (CarpoolingDAL.LeaveAMessage item in g.LeaveAMessages) {
                ng.addMessage(createMessageFromDALMessage(mr.getMessageById(item.idMessage),ng.getGroupMemberById(item.client)));
            }
            return ng;
        }

        private static Message createMessageFromDALMessage(CarpoolingDAL.Message message, GroupMember groupMember) {
            Message nm = new Message(groupMember, message.message1, message.time);
            nm.Id = message.idMessage;
            return nm;
        }

        internal static CarpoolingDAL.Route createDALRouteFromRoute(Route route) {
            CarpoolingDAL.Route nr = new CarpoolingDAL.Route();
            nr.routeType = route.Type.Id;
            nr.path = route.Path.convertToBinary();
            nr.name = route.Name;
            return nr;
        }

        internal static CarpoolingDAL.StartFinish createDALStartFinishFromPlace(Place place, Route route) {
            CarpoolingDAL.StartFinish nsf = new CarpoolingDAL.StartFinish();
            nsf.address = place.Address;
            nsf.direction = place.InOrOut;
            nsf.idCity = place.City.Id;
            nsf.idRoute = route.Id;
            return nsf;
        }

        internal static Nation createNationFromDALState(CarpoolingDAL.State st) {
            Nation nn = new Nation();
            nn.Id = st.idState;
            nn.Name = st.name;
            return nn;
        }

        internal static Country createCoutryFromDALCoutry(CarpoolingDAL.Coutry co) {
            Country nc = new Country();
            nc.Id = co.idCoutry;
            nc.Name = co.name;
            return nc;
        }

        internal static City createCityFromDALCity(CarpoolingDAL.City city) {
            City nc = new City();
            nc.Id = city.idCity;
            nc.Name = city.name;
            nc.PostalNumer = city.postalNumber;
            return nc;
        }

        internal static GroupType createGroupTypeFromDALGType(CarpoolingDAL.GroupType g) {
            GroupType ngt = new GroupType(g.idGroupType, g.name);
            return ngt;
        }
    }
}
