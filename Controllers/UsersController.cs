namespace BillingTracker.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using BillingTracker.Models;
    using BillingTracker.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        public ActionResult<List<UsersModel>> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<UsersModel> GetOneUser(string id)
        {
            var user = _service.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<UsersModel> Create(UsersModel userModel)
        {
            _service.Create(userModel);
            return CreatedAtRoute("GetUser", new { id = userModel.Id.ToString() }, userModel);

        }

        [HttpPost]
        [Route("Createmany")]
        public ActionResult<List<UsersModel>> CreateMany(List<UsersModel> userModels)
        {
            _service.Create(userModels);
            return CreatedAtAction("GetUser", userModels);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UsersModel model)
        {
            var user = _service.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            _service.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _service.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return NoContent();
        }
    }
}