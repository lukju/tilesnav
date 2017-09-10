using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TilesNav.Model;
using TilesNav.Core.Interfaces;

namespace TilesNav.Api.Controllers
{
    [Route("api/[controller]")]
    public class TileDefinitionsController : Controller
    {
        private readonly ITileDefinitionManager _tilesMgr;
        public TileDefinitionsController(ITileDefinitionManager tilesMgr)
        {
            _tilesMgr = tilesMgr;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tiles = _tilesMgr.GetAll();
            return Ok(tiles);
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public IActionResult GetById(Guid id)
        {
            var tile = _tilesMgr.GetDefinition(id);
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
            var newTile = _tilesMgr.SaveDefinition(tile);
            return CreatedAtRoute(nameof(GetById), new { id = newTile.Id }, newTile);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var deletedTile = _tilesMgr.DeleteDefinition(id);
            if (deletedTile == null)
            {
                return BadRequest("No such TileDefinition found");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] TileDefinition tile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payload");
            }
            try
            {
                tile.Id = id;
                var result = _tilesMgr.SaveDefinition(tile);
                if (result == null)
                {
                    return BadRequest("No such TileDefinition found");
                }
                return Ok(tile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] TileDefinition tile)
        {
            return Update(tile.Id, tile);
        }
    }
}