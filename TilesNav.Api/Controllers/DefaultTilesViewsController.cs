using System;
using Microsoft.AspNetCore.Mvc;
using TilesNav.Model;
using TilesNav.Core.Interfaces;

namespace TilesNav.Api.Controllers
{
    [Route("api/[controller]")]
    public class DefaultTilesViewsController : AbstractTilesViewsController
    {
        public DefaultTilesViewsController(ITilesViewManager tilesViewManager) : base(tilesViewManager) { }

        [HttpGet("{viewerName}", Name = "DefaultTilesView")]
        public override IActionResult Get(string viewerName)
        {
            TilesView tilesView = _tilesViewManager.LoadDefaultView(viewerName);
            if (tilesView == null)
            {
                return NotFound();
            }
            return Ok(tilesView);
        }
        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tilesViewManager.DeleteDefaultView(id);
            }
            catch (Exception ex)
            {
                return BadRequest("Couldn't delete: " + ex.Message);
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] DefaultTilesView tilesView)
        {
            return CreateOrUpdate(tilesView);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DefaultTilesView tilesView)
        {
            tilesView.Id = id;
            return CreateOrUpdate(tilesView);
        }

        [HttpPut]
        public IActionResult Update([FromBody] DefaultTilesView tilesView)
        {
            return Update(tilesView.Id, tilesView);
        }
    }
}