using System;
using Hotel.Dtos;
using Hotel.Models;

namespace Hotel
{
    public static class Extensions
    {
        public static ServiceDto AsDto(this Service service)
        {
            return new ServiceDto
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price,
                Description = service.Description,
                Image = service.Image,
                Availability = service.Availability
            };
        }
    }
}
