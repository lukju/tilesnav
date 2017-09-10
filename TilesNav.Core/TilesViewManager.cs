using System;
using System.Linq;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;
using TilesNav.Core.Interfaces;

namespace TilesNav.Core
{
    public class TilesViewManager : ITilesViewManager
    {
        readonly private ITilesNavRepository<PersonalTilesView, int> _personalViewsRepo;
        readonly private ITilesNavRepository<DefaultTilesView, int> _defaultViewsRepo;
        readonly private ITilesNavRepository<TilesNavViewer, string> _viewerRepo;
        readonly private User _currentUser;

        public TilesViewManager(IUserManager userManager, 
            ITilesNavRepository<PersonalTilesView, int> personalViewsRepo, 
            ITilesNavRepository<DefaultTilesView, int> defaultViewsRepo,
            ITilesNavRepository<TilesNavViewer, string> viewerRepo)
        {
            _personalViewsRepo = personalViewsRepo;
            _defaultViewsRepo = defaultViewsRepo;
            _viewerRepo = viewerRepo;
            _currentUser = userManager.CurrentUser;
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
            var viewer = _viewerRepo.Get(viewerName);
            return LoadDefaultView(viewer);
        }

        public TilesView LoadDefaultView(TilesNavViewer viewer)
        {
            TilesView tilesView = _defaultViewsRepo.GetAll(q => q.Viewer.Id == viewer.Id).FirstOrDefault();
            return tilesView;
        }

        public TilesView LoadPersonalView(string viewerName, bool fallbackToDefaultView = true)
        {
            var viewer = _viewerRepo.Get(viewerName);
            return LoadPersonalView(viewer, fallbackToDefaultView);
        }

        public TilesView LoadPersonalView(TilesNavViewer viewer, bool fallbackToDefaultView = true)
        {
            TilesView tilesView = _personalViewsRepo.GetAll(
                q => q.Owner.AccountName == _currentUser.AccountName && q.Viewer.Id == viewer.Id).FirstOrDefault();
            if (tilesView == null)
            {
                tilesView = LoadDefaultView(viewer);
            }
            return tilesView;
        }

        public TilesView SaveView(TilesView view)
        {
            TilesView savedView = null;
            if (view is PersonalTilesView)
            {
                if (view.Id > 0)
                {
                    savedView = UpdatePersonalView(view as PersonalTilesView);
                } else
                {
                    savedView = AddPersonalView(view as PersonalTilesView);
                }
            } else
            {
                if (view.Id > 0)
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
            view.Owner = _currentUser;
            return _personalViewsRepo.Create(view, _currentUser);
        }

        private PersonalTilesView UpdatePersonalView(PersonalTilesView view)
        {
            if (view.Owner == null || view.Owner.AccountName != _currentUser.AccountName)
            {
                throw new InvalidOperationException("view does not belong to currentuser.");
            }
            TilesView existing = LoadPersonalView(view.Viewer, fallbackToDefaultView: false);
            if (existing == null)
            {
                throw new InvalidOperationException("view does not exist.");
            }
            if (view.Id != existing.Id)
            {
                throw new InvalidOperationException("incorrect ID provided.");
            }
            if (view.Viewer != existing.Viewer)
            {
                throw new InvalidOperationException("incorrect viewer provided.");
            }
            return _personalViewsRepo.Update(view, _currentUser);
        }

        private DefaultTilesView AddDefaultView(DefaultTilesView view)
        {
            return _defaultViewsRepo.Create(view, _currentUser);
        }

        private DefaultTilesView UpdateDefaultView(DefaultTilesView view)
        {
            TilesView existing = LoadDefaultView(view.Viewer);
            if (existing == null || view.Id != existing.Id)
            {
                throw new Exception("Could'nt update Personal View because it does not exist.");
            }
            return _defaultViewsRepo.Update(view, _currentUser);
        }
    }
}
