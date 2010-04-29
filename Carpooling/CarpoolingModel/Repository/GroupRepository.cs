using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel {
    public class GroupRepository : CarpoolingModel.IGroupRepository {
        private static GroupRepository instanca = null;
        List<Group> listGroup;

        private GroupRepository() {
            listGroup = new List<Group>();
        }

        public static GroupRepository getInstanca() {
            if (instanca == null) {
                instanca = new GroupRepository();
            }
            return instanca;
        }

        public void addGroup(Group group) {
            throw new System.NotImplementedException();
        }

        public void removeGroup(Group group) {
            throw new System.NotImplementedException();
        }

        public void updateGroup(Group group) {
            throw new System.NotImplementedException();
        }

        public List<Group> getAllGroups() {
            throw new System.NotImplementedException();
        }

        public Group getGroupById(int idGroup) {
            throw new System.NotImplementedException();
        }

        public List<Group> getGroupsByRoute(Route route) {
            throw new System.NotImplementedException();
        }

        public List<Group> getGroupsByType(GroupType groupType) {
            throw new System.NotImplementedException();
        }

        public List<Group> getGroupByStartDate(DateTime startDate) {
            throw new System.NotImplementedException();
        }
    }
}
