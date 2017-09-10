using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TilesNav.Model;
using TilesNav.Core;
using TilesNav.Core.Interfaces;

namespace TilesNav.Api.Controllers
{
    public abstract class AbstractTilesViewsController : Controller
    {
        protected readonly ITilesViewManager _tilesViewManager;
        public AbstractTilesViewsController(ITilesViewManager tilesViewManager)
        {
            _tilesViewManager = tilesViewManager;
        }

        public abstract IActionResult Get(string viewerName);

        protected IActionResult CreateOrUpdate(TilesView tilesView)
        {
            bool isNew = (tilesView.Id <= 0);
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payload");
            }
            try
            {
                var result = _tilesViewManager.SaveView(tilesView);
                if (isNew)
                {
                    return CreatedAtRoute(nameof(Get), new { id = result.Id }, result);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}