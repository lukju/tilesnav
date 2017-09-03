using System;
using Microsoft.AspNetCore.Mvc;
using TilesNav.Model;
using TilesNav.Core.Interfaces;

namespace TilesNav.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonalTilesViewsController : AbstractTilesViewsController
    {
        public PersonalTilesViewsController(ITilesViewManager tilesViewManager): base(tilesViewManager) { }

        [HttpGet("{viewerName}", Name = "PersonalTilesView")]
        public override IActionResult Get(string viewerName)
        {
            TilesView tilesView = _tilesViewManager.LoadPersonalView(viewerName);
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
                _tilesViewManager.DeletePersonalView(id);
            }
            catch (Exception ex)
            {
                return BadRequest("Couldn't delete: " + ex.Message);
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonalTilesView tilesView)
        {
            return CreateOrUpdate(tilesView);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PersonalTilesView tilesView)
        {
            tilesView.ID = id;
            return CreateOrUpdate(tilesView);
        }

        [HttpPut]
        public IActionResult Update([FromBody] PersonalTilesView tilesView)
        {
            return Update(tilesView.ID, tilesView);
        }
    }
}