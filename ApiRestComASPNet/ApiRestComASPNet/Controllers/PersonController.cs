using ApiRestComASPNet.Model;
using ApiRestComASPNet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestComASPNet.Controllers
{
    [ApiController]
    [Route("[controller]/api/")]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
                return Ok(person);
        }

        [HttpGet ]
        public IActionResult Get()
        {
            var person = Ok(_personService.FindAll());
            if (person==null)
            {
                return NotFound();
            }
            return (person);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            else
            {
              return  Ok(_personService.Create(person));
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_personService.Update(person));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
