using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarpoolingDAL;
using CarpoolingModel.Types;
using CarpoolingModel.Repository;

namespace CarpoolingModel.Repository {

    public class GroupRepository : CarpoolingModel.Repository.IGroupRepository {
        private static GroupRepository instanca = null;
        private static CarpoolingDBADataContext db = new CarpoolingDBADataContext();
        private GroupRepository() {
        }

        public static GroupRepository getInstanca() {
            if (instanca == null) {
                instanca = new GroupRepository();
            }
            return instanca;
        }

        public void addGroup(Group group) {
            try {
                foreach (GroupMember item in group.getGroupMembers()) {
                    addGroupMember(item, group);
                }
                db.Groups.InsertOnSubmit(RepositoryUtility.createDALGroupFromGroup(group));
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

        public void addGroupMember(GroupMember groupMember, Group group) {
            try {
                db.GroupMembers.InsertOnSubmit(RepositoryUtility.createDALGroupMemberFromGroupMember(groupMember, group));
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
        public void removeGroup(Group group) {
            try {
                CarpoolingDAL.Group g = db.Groups.Single(o => o.idGroup == group.Id);
                db.Groups.DeleteOnSubmit(g);
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }

            //return true;
        }

        public void updateGroup(Group group) {
            try {
                CarpoolingDAL.Group oldOne = db.Groups.Single(o => o.idGroup == group.Id);
                oldOne.destinationRange = group.DestinationRange.RangeDim;
                oldOne.groupType = group.Type.Id;
                oldOne.route = group.Route.Id;
                oldOne.startRange = group.StartRange.RangeDim;
                oldOne.startTime = group.StartTime;
                oldOne.totalCost = group.TotalCost;
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }

            //return true;
        }

        public List<Group> getAllGroups() {
            List<Group> allGroups = new List<Group>();
            foreach (CarpoolingDAL.Group o in db.Groups) {
                allGroups.Add(RepositoryUtility.createGroupFromDALGroup(o));
            }
            return allGroups;
        }

        public Group getGroupById(int idGroup) {
            CarpoolingDAL.Group g = new CarpoolingDAL.Group();
            try {
                var query = db.Groups.Where(o => o.idGroup == idGroup).First();
                g = query as CarpoolingDAL.Group;
            } catch (Exception) {
                g = null;
            }

            return RepositoryUtility.createGroupFromDALGroup(g);
        }

        public List<Group> getGroupsByRoute(Route route) {
            List<Group> listRouGroup = new List<Group>();
            var groups = db.Groups.Where(s => s.route == route.Id);

            foreach (CarpoolingDAL.Group res in groups) {
                listRouGroup.Add(RepositoryUtility.createGroupFromDALGroup(res as CarpoolingDAL.Group));
            }
            return listRouGroup;
        }

        public List<Group> getGroupsByType(CarpoolingModel.Types.GroupType groupType) {
            List<Group> listTyGr = new List<Group>();
            var groups = db.Groups.Where(s => s.groupType == groupType.Id);

            foreach (CarpoolingDAL.Group res in groups) {
                listTyGr.Add(RepositoryUtility.createGroupFromDALGroup(res as CarpoolingDAL.Group));
            }
            return listTyGr;
        }

        public List<Group> getGroupByStartDate(DateTime startDate) {
            List<Group> listSDGr = new List<Group>();
            var groups = db.Groups.Where(s => s.startTime.Day == startDate.Day && 
                s.startTime.Month == startDate.Month && 
                s.startTime.Year == startDate.Year);

            foreach (CarpoolingDAL.Group res in groups) {
                listSDGr.Add(RepositoryUtility.createGroupFromDALGroup(res as CarpoolingDAL.Group));
            }
            return listSDGr;
        }

        public CarpoolingModel.Types.GroupType getGroupType(int id) {
            CarpoolingDAL.GroupType g = new CarpoolingDAL.GroupType();
            try {
                var query = db.GroupTypes.Where(o => o.idGroupType == id).First();
                g = query as CarpoolingDAL.GroupType;
            } catch (Exception) {
                g = null;
            }

            return RepositoryUtility.createGroupTypeFromDALGType(g);
        }
    }
}
