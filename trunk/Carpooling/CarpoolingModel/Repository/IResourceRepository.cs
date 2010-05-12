using System;
namespace CarpoolingModel.Repository {
    interface IResourceRepository {
        void addResource(CarpoolingModel.Resource resource, CarpoolingModel.Client client);
        void addResourceType(CarpoolingModel.Types.ResourceType resourceType);
        bool existResource(int idResource);
        System.Collections.Generic.List<CarpoolingModel.Resource> getAllResources();
        System.Collections.Generic.List<CarpoolingModel.Types.ResourceType> getAllResourceTypes();
        System.Collections.Generic.List<CarpoolingModel.Resource> getResourceOfClient(CarpoolingModel.Client client);
        void removeResource(CarpoolingModel.Resource resource);
        void updateResource(CarpoolingModel.Resource resource);
    }
}
