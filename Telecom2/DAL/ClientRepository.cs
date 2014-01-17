using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telecom2.Models;

namespace Telecom2.DAL
{
    public class ClientRepository : IClientRepository, IDisposable
    {
        private TContext context;
        private bool disposed = false;

        public ClientRepository(TContext context) { this.context = context; }

        public IEnumerable<Client> getClients() { return context.Clients.ToList(); }

        public Client getClientById(int clientId) { return context.Clients.Find(clientId); }

        public void insertClient(Client client) { context.Clients.Add(client); }

        public void deleteClient(int clientId) 
        {
            Client client = context.Clients.Find(clientId);
            context.Clients.Remove(client);
        }

        public void updateClient(Client client) { context.Entry(client).State = System.Data.EntityState.Modified; }

        public void save() 
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}