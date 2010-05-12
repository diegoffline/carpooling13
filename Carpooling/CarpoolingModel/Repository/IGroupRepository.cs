using System;
namespace CarpoolingModel.Repository {
    interface IGroupRepository {
        void addGroup(CarpoolingModel.Group group);
        System.Collections.Generic.List<CarpoolingModel.Group> getAllGroups();
        void addGroupMember(CarpoolingModel.GroupMember groupMember, CarpoolingModel.Group group);
        CarpoolingModel.Group getGroupById(int idGroup);
        System.Collections.Generic.List<CarpoolingModel.Group> getGroupByStartDate(DateTime startDate);
        System.Collections.Generic.List<CarpoolingModel.Group> getGroupsByRoute(CarpoolingModel.Route route);
        System.Collections.Generic.List<CarpoolingModel.Group> getGroupsByType(CarpoolingModel.Types.GroupType groupType);
        CarpoolingModel.Types.GroupType getGroupType(int id);
        void removeGroup(CarpoolingModel.Group group);
        void updateGroup(CarpoolingModel.Group group);
    }
}
