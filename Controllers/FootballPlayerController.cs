﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpExcercise;
using Microsoft.AspNetCore.Http;
using OblRestExcercise.Managers;
using OblRestExcercise.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OblRestExcercise.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FootballPlayerController : ControllerBase
	{
		private readonly FootballPlayersManager _manager = new FootballPlayersManager();

		// GET: api/<FootballPlayerController>
		[HttpGet]
		public IEnumerable<FootballPlayer> GetAll()
		{
			return _manager.GetAll();
		}

		// GET api/<FootballPlayerController>/5
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		// GET api/<ShoesController>/5
		[HttpGet("{id}")]
		public ActionResult<FootballPlayer> Get(int id)
		{
			FootballPlayer player = _manager.GetById(id);
			if (player == null)
			{
				return NotFound("No such item, id: " + id);
			}
			else
			{
				return Ok(player);
			}

		}

		// POST api/<FootballPlayerController>
		[HttpPost]
		public FootballPlayer Post([FromBody] FootballPlayer value)
		{
			return _manager.Add(value);
		}

		// PUT api/<FootballPlayerController>/5
		[HttpPut("{id}")]
		public FootballPlayer Put(int id, [FromBody] FootballPlayer value)
		{
			return _manager.Update(id, value);
		}

		// DELETE api/<FootballPlayerController>/5
		[HttpDelete("{id}")]
		public FootballPlayer Delete(int id)
		{
			return _manager.Delete(id);
		}
	}
}
