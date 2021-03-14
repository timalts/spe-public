﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        public static List<Games> getGames()
        {
            List<Games> games = new List<Games>();
            games.Add(new Games() { Id = 1, Name = "Game 1", Price = 10 });
            games.Add(new Games() { Id = 2, Name = "Game 2", Price = 15 });
            games.Add(new Games() { Id = 3, Name = "Game 3", Price = 20 });
            games.Add(new Games() { Id = 4, Name = "Game 4", Price = 25 });
            games.Add(new Games() { Id = 5, Name = "Game 5", Price = 30 });
            return games;
        }

        [HttpGet]
        public IEnumerable<Games> GetGames_List()
        {
            return getGames();
        }

        [HttpGet("{id}")]
        public ActionResult<Games> GetGames_byId(int id)
        {
            var games = getGames().Find(x => x.Id == id);
            if (games != null)
                return games;
            return NotFound();
        }
    }
}
