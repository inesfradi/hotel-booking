using System;
using Microsoft.AspNetCore.Http;

namespace Hotel.Dtos
{
    public record ServiceDto
    {
        public string Id { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }

        public decimal Price { get; init; }

        public string Image { get; set; }

        public bool Availability { get; init; }
    }
}
