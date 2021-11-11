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
        Service Create(Service service);
    }
}
