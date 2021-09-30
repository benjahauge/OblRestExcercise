using Microsoft.AspNetCore.Mvc;
using OblRestExcercise.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OblRestExcercise.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OblRestExcercise.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoesController : ControllerBase
	{
		private readonly ShoesManager _manager = new ShoesManager();

		// GET: api/<ShoesController>
		[HttpGet]
		public IEnumerable<Shoe> Get()
		{
			return _manager.GetAll();
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		// GET api/<ShoesController>/5
		[HttpGet("{id}")]
		public ActionResult<Shoe> Get(int id)
		{
			Shoe shoe = _manager.GetById(id);
			if (shoe == null)
			{
				return NotFound("No such item, id: " + id);
			}
			else
			{
				return Ok(shoe);
			}
			
		}

		// POST api/<ShoesController>
		[HttpPost]
		public Shoe Post([FromBody] Shoe value)
		{
			return _manager.Add(value);
		}

		// PUT api/<ShoesController>/5
		[HttpPut("{id}")]
		public Shoe Put(int id, [FromBody] Shoe value)
		{
			return _manager.Update(id, value);
		}

		// DELETE api/<ShoesController>/5
		[HttpDelete("{id}")]
		public Shoe Delete(int id)
		{
			return _manager.Delete(id);
		}
	}
}
