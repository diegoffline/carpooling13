using System;
namespace CarpoolingModel {
    interface IResourceRepository {
        void addResource(Resource resource);
        void addResourceType(ResourceType resourceType);
        System.Collections.Generic.List<Resource> getAllResource();
        System.Collections.Generic.List<Resource> getResourceOfClient(Client client);
        void removeResource(Resource resource);
        void updateResource(Resource resource);
    }
}
