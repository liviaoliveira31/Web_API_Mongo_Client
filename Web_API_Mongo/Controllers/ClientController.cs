using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_API_Mongo.Models;
using Web_API_Mongo.Services;

namespace Web_API_Mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly ClientServices _clientService;

        public ClientController(ClientServices clientService)
        {
            _clientService = clientService;
        }

        [HttpGet] //get all
        public ActionResult<List<Client>> Get() => _clientService.Get();

        [HttpGet("{id:lenght(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.Get(id);
            if(client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public ActionResult<Client> Create (Client client)
        {
            _clientService.Create(client);
            return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
        }
    }
}
