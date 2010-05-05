using System;
using CarpoolingModel.Types;
namespace CarpoolingModel
{
    interface IGroupRepository
    {
        void addGroup(Group group);
        System.Collections.Generic.List<Group> getAllGroups();
        Group getGroupById(int idGroup);
        System.Collections.Generic.List<Group> getGroupsByRoute(Route route);
        System.Collections.Generic.List<Group> getGroupsByType(GroupType groupType);
        void removeGroup(Group group);
        void updateGroup(Group group);
    }
}
