using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Db;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly AppDbContext _appdbContext;

        public UserRegistrationController()
        {
            _appdbContext = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _appdbContext.userRegistrations.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _appdbContext.userRegistrations.FirstOrDefault(x=> x.UserID == id);
            if(item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(UserRegistrationModel userRegistrationModel)
        {
            _appdbContext.userRegistrations.Add(userRegistrationModel);
            var result = _appdbContext.SaveChanges();

            var message = result > 0 ? "Creating successful." : "Creating Fail."; 

            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,UserRegistrationModel userRegistrationModel)
        {
            var item = _appdbContext.userRegistrations.FirstOrDefault(x=> x.UserID ==id);
            if(item is null)
            {
                return NotFound("No data found.");
            }

            item.FirstName = userRegistrationModel.FirstName;
            item.LastName = userRegistrationModel.LastName;
            item.Contact = userRegistrationModel.Contact;
            item.Gender = userRegistrationModel.Gender;
            item.Address = userRegistrationModel.Address;
            item.UserName = userRegistrationModel.UserName;
            item.Password = userRegistrationModel.Password;

            var result = _appdbContext.SaveChanges();
            var message = result > 0 ? "Saving successful." : "Saving Fail";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, UserRegistrationModel userRegistrationModel)
        {
            var item = _appdbContext.userRegistrations.FirstOrDefault(x => x.UserID == id);
            if(item is null)
            {
                return NotFound("No data found.");
            }

            if(!string.IsNullOrEmpty(userRegistrationModel.FirstName))
            {
                item.FirstName = userRegistrationModel.FirstName;
            }
            if(!string.IsNullOrEmpty(userRegistrationModel.LastName))
            {
                item.LastName = userRegistrationModel.LastName;
            }
            if(!string.IsNullOrEmpty(userRegistrationModel.Contact))
            {
                item.Contact = userRegistrationModel.Contact;
            }
            if (!string.IsNullOrEmpty(userRegistrationModel.Gender))
            {
                item.Gender = userRegistrationModel.Gender;
            }
            if (!string.IsNullOrEmpty(userRegistrationModel.Address))
            {
                item.Address = userRegistrationModel.Address;
            }
            if (!string.IsNullOrEmpty(userRegistrationModel.UserName))
            {
                item.UserName = userRegistrationModel.UserName;
            }
            if (!string.IsNullOrEmpty(userRegistrationModel.Password))
            {
                item.Password = userRegistrationModel.Password;
            }
            var result = _appdbContext.SaveChanges();
            var message = result > 0 ? "Updating Successful." : "Updating Fail.";
            return Ok(message);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = _appdbContext.userRegistrations.FirstOrDefault(x => x.UserID == id);
            if(item is null)
            {
                return NotFound("No data found.");
            }
            _appdbContext.userRegistrations.Remove(item);
            var result = _appdbContext.SaveChanges();
            var message = result > 0 ? "Deleting successful." : "Deleting Fail.";
            return Ok(message);
        }
    }
}
