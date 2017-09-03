using System;
using System.Linq;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;
using TilesNav.Core.Interfaces;

namespace TilesNav.Core
{
    public class TilesViewManager : ITilesViewManager
    {
        readonly ITilesNavRepository<PersonalTilesView> _personalViewsRepo;
        readonly ITilesNavRepository<DefaultTilesView> _defaultViewsRepo;
        readonly IUser _currentUser;

        public TilesViewManager(IUser currentUser, ITilesNavRepository<PersonalTilesView> personalViewsRepo, ITilesNavRepository<DefaultTilesView> defaultViewsRepo)
        {
            _personalViewsRepo = personalViewsRepo;
            _defaultViewsRepo = defaultViewsRepo;
            _currentUser = currentUser;
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
            TilesView tilesView = _personalViewsRepo.GetAll(
                q => q.Owner == _currentUser.AccountName && q.Viewer == viewerName).FirstOrDefault();
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
                    savedView = UpdatePersonalView(view as PersonalTilesView);
                } else
                {
                    savedView = AddPersonalView(view as PersonalTilesView);
                }
            } else
            {
                if (view.ID > 0)
                {
                    savedView = UpdateDefaultView(view as DefaultTilesView);
                }
                else
                {
                    savedView = AddDefaultView(view as DefaultTilesView);
                }
            }
            return savedView;
        }

        private PersonalTilesView AddPersonalView(PersonalTilesView view)
        {
            TilesView existing = LoadPersonalView(view.Viewer, fallbackToDefaultView: false);
            if (existing != null)
            {
                throw new InvalidOperationException("view for this viewer already exists.");
            }
            view.Owner = _currentUser.AccountName;
            return _personalViewsRepo.Create(view);
        }

        private PersonalTilesView UpdatePersonalView(PersonalTilesView view)
        {
            if (view.Owner != _currentUser.AccountName)
            {
                throw new InvalidOperationException("view does not belong to currentuser.");
            }
            TilesView existing = LoadPersonalView(view.Viewer, fallbackToDefaultView: false);
            if (existing == null)
            {
                throw new InvalidOperationException("view does not exist.");
            }
            if (view.ID != existing.ID)
            {
                throw new InvalidOperationException("incorrect ID provided.");
            }
            if (view.Viewer != existing.Viewer)
            {
                throw new InvalidOperationException("incorrect viewer provided.");
            }
            return _personalViewsRepo.Update(view);
        }

        private DefaultTilesView AddDefaultView(DefaultTilesView view)
        {
            return _defaultViewsRepo.Create(view);
        }

        private DefaultTilesView UpdateDefaultView(DefaultTilesView view)
        {
            TilesView existing = LoadDefaultView(view.Viewer);
            if (existing == null || view.ID != existing.ID)
            {
                throw new Exception("Could'nt update Personal View because it does not exist.");
            }
            return _defaultViewsRepo.Update(view);
        }
    }
}
