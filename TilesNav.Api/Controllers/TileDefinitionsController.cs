using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TilesNav.Model.Repos;
using TilesNav.Model;

namespace TilesNav.Api.Controllers
{
    [Route("api/[controller]")]
    public class TileDefinitionsController : Controller
    {
        readonly ITilesNavRepository<TileDefinition> _repo;
        public TileDefinitionsController(ITilesNavRepository<TileDefinition> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tiles = _repo.GetAll();
            return Ok(tiles);
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public IActionResult GetById(int id)
        {
            var tile = _repo.Get(id);
            if (tile == null)
            {
                return NotFound();
            }
            return Ok(tile);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TileDefinition tile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newTile = _repo.Create(tile);
            return CreatedAtRoute(nameof(GetById), new { id = newTile.ID }, newTile);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedTile = _repo.Delete(id);
            if (deletedTile == null)
            {
                return BadRequest("No such TileDefinition found");
            }
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update([FromBody] TileDefinition tile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payload");
            }
            try
            {
                var result = _repo.Update(tile);
                if (result == null)
                {
                    return BadRequest("No such TileDefinition found");
                }
                return Ok(tile);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}