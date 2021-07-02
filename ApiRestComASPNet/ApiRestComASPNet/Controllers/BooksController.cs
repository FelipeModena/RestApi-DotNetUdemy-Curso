using ApiRestComASPNet.Business;
using ApiRestComASPNet.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestComASPNet.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        private  IBooksBusiness _booksBusiness;

        public BooksController(IBooksBusiness booksBusiness)
        {
            _booksBusiness = booksBusiness;
        }


        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var books = _booksBusiness.FindById(id);
            return Ok(books);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = Ok(_booksBusiness.FindAll());
            if (books == null)
            {
                return NotFound();
            }
            return (books);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book books)
        {
            if (books == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_booksBusiness.Create(books));
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book books)
        {
            if (books == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_booksBusiness.Update(books));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }
    }
}
