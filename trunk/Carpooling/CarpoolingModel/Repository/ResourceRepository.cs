using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CarpoolingDAL;

namespace CarpoolingModel.Repository {
    public class ResourceRepository : CarpoolingModel.Repository.IResourceRepository {
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
            try {
                db.Resources.InsertOnSubmit(RepositoryUtility.createDALResourceFromResource(resource));
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

        public void removeResource(Resource resource) {
            try {
                CarpoolingDAL.Resource rs = db.Resources.Single(o => o.idResource == resource.Id);
                rs.active = false;
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }

            //return true;
        }

        public void updateResource(Resource resource) {
            try {
                CarpoolingDAL.Resource oldOne = db.Resources.Single(o => o.idResource == resource.Id);
                oldOne.age = resource.Age;
                oldOne.consumption = resource.Consumption;
                oldOne.name = resource.Name;
                oldOne.resourceType = resource.Type.Id;
                oldOne.seatNumber = resource.SeatNumber;
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }

            //return true;
        }

        public List<Resource> getResourceOfClient(Client client) {
            List<Resource> listMemRes = new List<Resource>();
            var resources = db.Resources.Where(s => s.owner == client.Id);

            foreach (CarpoolingDAL.Resource res in resources) {
                listMemRes.Add(RepositoryUtility.createResourceFromDALResource(res as CarpoolingDAL.Resource));
            }
            return listMemRes;
        }

        public void addResourceType(ResourceType resourceType) {
            try {
                db.ResourceTypes.InsertOnSubmit(RepositoryUtility.createDALResourceTyFromResourceTy(resourceType));
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

        public List<ResourceType> getAllResourceTypes() {
            List<ResourceType> allTypes = new List<ResourceType>();
            foreach (CarpoolingDAL.ResourceType o in db.ResourceTypes) {
                allTypes.Add(RepositoryUtility.createResTyFromDALResTy(o));
            }
            return allTypes;
        }

        public List<Resource> getAllResources() {
            List<Resource> allResource = new List<Resource>();
            foreach (CarpoolingDAL.Resource o in db.Resources) {
                if (o.active)
                    allResource.Add(RepositoryUtility.createResourceFromDALResource(o));
            }
            return allResource;
        }

        public bool existResource(int idResource) {
            CarpoolingDAL.Resource oldOne = db.Resources.Single(o => o.idResource == idResource);
            if (oldOne != null) return true;
            else return false;
        }

    }
}
