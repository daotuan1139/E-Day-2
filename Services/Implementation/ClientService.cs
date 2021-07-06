using System;
using System.Collections.Generic;
using System.Linq;
using E_Day_2.Models;
using Microsoft.EntityFrameworkCore;
using static E_Day_2.Services.IService;

namespace E_Day_2.Services
{

    public class ClientService : IClientService
    {
        private DataContext _dataContext;
        public ClientService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Client> GetList()
        {
            return _dataContext.Clients.ToList();
        }

        public Client CreateClient(ClientDTO Client)
        {
            var newClient = new Client
                {
                    ClientName = Client.ClientName,

                };
            _dataContext.Clients.Add(newClient);
            _dataContext.SaveChanges();

            return newClient;
        }

        public List<Client> EditClient(ClientDTO client)
        {
            Client existingClient = _dataContext.Clients.Find(client.ID);

            if (existingClient == null)
            {
                return new List<Client>();
            }
            else
            {
                existingClient.ClientName = client.ClientName;


                _dataContext.Entry(existingClient).State = EntityState.Modified;
                _dataContext.SaveChanges();
            }
            return _dataContext.Clients.ToList();
        }

        public List<Client> IsDelete(ClientDTO client)
        {
            Client existingClient = _dataContext.Clients.Find(client.ID);
            _dataContext.Remove(existingClient);
            _dataContext.SaveChanges();
            return _dataContext.Clients.ToList();
        }

        public Client FindByID(int id)
        {
            Client existingClient = _dataContext.Clients.Find(id);

            return existingClient;
        }

    }

}