using System;
namespace CarpoolingModel.Repository
{
    interface IClientRepository
    {
        void addClient(CarpoolingModel.Client client);
        bool existClient(string username);
        System.Collections.Generic.List<CarpoolingModel.Client> getAllClients();
        CarpoolingModel.Client getClientByEmail(string email);
        CarpoolingModel.Client getClientByUsername(string username);
        void removeClient(CarpoolingModel.Client client);
        void updateClient(CarpoolingModel.Client client);
    }
}
