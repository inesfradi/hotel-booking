using System;
using System.Collections.Generic;
using Hotel.Models;
using Microsoft.AspNetCore.Http;

namespace Hotel.Services
{
    public interface IServiceRepository
    {
        IEnumerable<Service> Get();
        Service Get(string id);
        void Remove(string id);
        void Edit(string id, Service service);
        Service Create(Service service);
    }
}
