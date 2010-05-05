using System;
namespace CarpoolingModel.Repository {
    interface IResourceRepository {
        void addResource(CarpoolingModel.Resource resource);
        void addResourceType(CarpoolingDAL.ResourceType resourceType);
        bool existResource(int idResource);
        System.Collections.Generic.List<CarpoolingModel.Resource> getAllResources();
        System.Collections.Generic.List<CarpoolingDAL.ResourceType> getAllResourceTypes();
        System.Collections.Generic.List<CarpoolingModel.Resource> getResourceOfClient(CarpoolingModel.Client client);
        void removeResource(CarpoolingModel.Resource resource);
        void updateResource(CarpoolingModel.Resource resource);
    }
}
