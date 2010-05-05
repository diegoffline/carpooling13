using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CarpoolingDAL;

namespace CarpoolingModel {
    public class ResourceRepository : CarpoolingModel.IResourceRepository {
        private static ResourceRepository instanca = null;
        private static CarpoolingDBADataContext db = new CarpoolingDBADataContext();
        private ResourceRepository() {

        }

        public static ResourceRepository getInstanca() {
            if (instanca == null) {
                instanca = new ResourceRepository();
            }
            return instanca;
        }

        public void addResource(Resource resource) {
            throw new System.NotImplementedException();
        }

        public void removeResource(Resource resource) {
            throw new System.NotImplementedException();
        }

        public void updateResource(Resource resource) {
            throw new System.NotImplementedException();
        }

        public List<Resource> getResourceOfClient(Client client) {
            throw new System.NotImplementedException();
        }

        public void addResourceType(ResourceType resourceType) {
            throw new System.NotImplementedException();
        }

        public List<Resource> getAllResource() {
            throw new System.NotImplementedException();
        }

    }
}
