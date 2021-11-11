using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Hotel.Dtos;
using Hotel.Models;
using Hotel.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.Controllers
{
    [ApiController]
    [Route("/api/services")]
    public class HotelServicesController : ControllerBase
    {
        private readonly IServiceRepository _service;

        public HotelServicesController(IServiceRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ServiceDto> Get()
        {
            return _service.Get().Select(service => service.AsDto());
        }

        [HttpGet("{id:length(24)}", Name = "GetService")]
        public ActionResult<Service> Get(string id)
        {
            var service = _service.Get(id);

            if (service == null)
            {
                return NotFound();
            }
            return service;
        }

        [HttpPost]
        public ActionResult<Service> Create(Service service)
        {
            _service.Create(service);
            return CreatedAtRoute(
                "GetService",
                new { id = service.Id.ToString() }, service
            );
        }

        [HttpPost("/api/services/book/{id}")]
        public ActionResult<Service> Update(string id)
        {
            var service = _service.Get(id);
            if (service == null)
            {
                return NotFound();
            }
            if (service.Availability == true)
            {
                service.Availability = false;
            }
            _service.Edit(id, service);

            return Ok();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var service = _service.Get(id);

            if (service == null)
            {
                return NotFound();
            }

            _service.Remove(service.Id);

            return Ok();
        }
    }
}
