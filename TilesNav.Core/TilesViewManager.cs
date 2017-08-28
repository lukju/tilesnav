using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TilesNav.Model;

namespace TilesNav.Core
{
    public class TilesViewManager : ITilesViewManager
    {
        readonly ITilesNavRepository<PersonalTilesView> _personalViewsRepo;
        readonly ITilesNavRepository<DefaultTilesView> _defaultViewsRepo;
        public TilesViewManager(ITilesNavRepository<PersonalTilesView> personalViewsRepo, ITilesNavRepository<DefaultTilesView> defaultViewsRepo)
        {
            _personalViewsRepo = personalViewsRepo;
            _defaultViewsRepo = defaultViewsRepo;
        }
        public void DeletePersonalView(int id)
        {
            TilesView deleted = _personalViewsRepo.Delete(id);
            if (deleted == null)
            {
                throw new Exception("No such TilesView found!");
            }
        }

        public void DeleteDefaultView(int id)
        {
            TilesView deleted = _defaultViewsRepo.Delete(id);
            if (deleted == null)
            {
                throw new Exception("No such TilesView found!");
            }
        }
        

        public TilesView LoadDefaultView(string viewerName)
        {
            TilesView tilesView = _defaultViewsRepo.GetAll(q => q.Viewer == viewerName).FirstOrDefault();
            return tilesView;
        }

        public TilesView LoadPersonalView(string viewerName, bool fallbackToDefaultView = true)
        {
            TilesView tilesView = _personalViewsRepo.GetAll(q => q.Owner == "bla" && q.Viewer == viewerName).FirstOrDefault();
            if (tilesView == null)
            {
                tilesView = LoadDefaultView(viewerName);
            }
            return tilesView;
        }

        public TilesView SaveView(TilesView view)
        {
            TilesView savedView = null;
            if (view is PersonalTilesView)
            {
                if (view.ID > 0)
                {
                    TilesView existing = LoadPersonalView(view.Viewer, fallbackToDefaultView: false);
                    if (existing == null || view.ID != existing.ID)
                    {
                        throw new Exception("Could'nt update Personal View because it does not exist.");
                    }
                    savedView = _personalViewsRepo.Update(view as PersonalTilesView);
                } else
                {
                    savedView = _personalViewsRepo.Create(view as PersonalTilesView);
                }
            } else
            {
                if (view.ID > 0)
                {
                    TilesView existing = LoadDefaultView(view.Viewer);
                    if (existing == null || view.ID != existing.ID)
                    {
                        throw new Exception("Could'nt update Personal View because it does not exist.");
                    }
                    savedView = _defaultViewsRepo.Update(view as DefaultTilesView);
                }
                else
                {
                    savedView = _defaultViewsRepo.Create(view as DefaultTilesView);
                }
            }
            return savedView;
        }
    }
}
