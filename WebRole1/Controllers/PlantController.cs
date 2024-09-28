using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebRole1.Data;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public class PlantController : ApiController
    {
        // GET: api/Plant
        private PlantService _service;
     
        public PlantController()
        {
            _service = new PlantService();
           

        }
        public IEnumerable<Plant> Get()
        {
            
           return _service.GetAllPlants();
           
        }

        // GET: api/Plant/5
        public Plant Get(int id)
        {
            return _service.GetPlantById(id);
        }

        // POST: api/Plant
        public void Post([FromBody]Plant plant)
        {
            _service.insertPlants(plant);
        }

        //// PUT: api/Plant
        public void Put(int id,[FromBody]Plant plant)
        {
            var existingItem = _service.GetPlantById(id);
            if (existingItem == null)
            {
                throw new Exception("no plant item");
            }
            else
            {
                _service.UpdatePlant(plant);
            }
            
        }

        //// DELETE: api/Plant/5
        public void Delete(int id)
        {
            _service.Delete(id);

        }
    }
}
