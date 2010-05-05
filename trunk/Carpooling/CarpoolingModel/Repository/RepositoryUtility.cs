using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            //TODO
            //foreach (CarpoolingDAL.Route item in collection) {

            //}
            return c;
        }

        public static Resource createResourceFromDALResource(CarpoolingDAL.Resource item) {
            throw new NotImplementedException();
        }

        internal static CarpoolingDAL.Client createDALClientFromClient(Client client) {
            throw new NotImplementedException();
        }

        internal static CarpoolingDAL.GroupMember createDALGroupMemberFromGroupMember(GroupMember groupMember)
        {
            throw new NotImplementedException();
        }

        internal static GroupMember createGroupMemberFromDALGroupMember(CarpoolingDAL.GroupMember groupMember) {
            throw new NotImplementedException();
        }

        internal static CarpoolingDAL.Resource createDALResourceFromResource(Resource resource) {
            throw new NotImplementedException();
        }

        internal static CarpoolingDAL.ResourceType createDALResourceTyFromResourceTy(CarpoolingDAL.ResourceType resourceType) {
            throw new NotImplementedException();
        }

        internal static CarpoolingDAL.ResourceType createResTyFromDALResTy(CarpoolingDAL.ResourceType o) {
            throw new NotImplementedException();
        }

        internal static CarpoolingDAL.Group createDALGroupFromGroup(Group group) {
            throw new NotImplementedException();
        }

        internal static Group createGroupFromDALGroup(CarpoolingDAL.Group g) {
            throw new NotImplementedException();
        }

        internal static CarpoolingDAL.Route createDALRouteFromRoute(Route route) {
            throw new NotImplementedException();
        }

        internal static CarpoolingDAL.StartFinish createDALStartFinishFromPlace(Place place) {
            throw new NotImplementedException();
        }
    }
}
