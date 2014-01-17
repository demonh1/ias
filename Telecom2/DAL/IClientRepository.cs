using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telecom2.Models;

namespace Telecom2.DAL
{
   public interface IClientRepository : IDisposable
    {
        IEnumerable<Client> getClients();
        Client getClientById(int clientId);
        void insertClient(Client client);
        void deleteClient(int clientId);
        void updateClient(Client client);
        void save();

    }
}
