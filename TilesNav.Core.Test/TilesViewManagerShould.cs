using System;
using Xunit;
using TilesNav.Model;

namespace TilesNav.Core.Test
{
    public class TilesViewManagerShould
    {
        [Fact]
        public void ReturnNullIfLoadingInexistentPersonalView()
        {
            var tilesViewManager = TilesViewManager;
            var viewer = new TilesNavViewer() { Id = "non-existent-viewer" };
            var result = tilesViewManager.LoadPersonalView(viewer, true);
            Assert.Null(result);
        }

        [Fact]
        public void ReturnNullIfLoadingInexistentDefaultView()
        {
            var tilesViewManager = TilesViewManager;
            var viewer = new TilesNavViewer() { Id = "non-existent-viewer" };
            var result = tilesViewManager.LoadDefaultView(viewer);
            Assert.Null(result);
        }

        [Fact]
        public void ReturnDefaultViewIfPersonalViewDoesNotExist()
        {
            var tilesViewManager = TilesViewManager;
            var viewer = new TilesNavViewer() { Id = "viewername" };
            var defaultView = new DefaultTilesView()
            {
                Viewer = viewer
            };
            tilesViewManager.SaveView(defaultView);
            var result = tilesViewManager.LoadPersonalView(viewer, true);
            Assert.Equal(result, defaultView);
        }

        [Fact]
        public void StorePersonalViewIfNewPersonalViewIsAdded()
        {
            var tilesViewManager = TilesViewManager;
            var viewer = new TilesNavViewer() { Id = "viewername" }; 
            var view = new PersonalTilesView()
            {
                Viewer = viewer
            };
            Assert.Null(tilesViewManager.LoadPersonalView(viewer, false));
            var newView = tilesViewManager.SaveView(view);
            Assert.NotNull(tilesViewManager.LoadPersonalView(viewer, false));
        }

        [Fact]
        public void StorePersonalViewIfPersonalViewIsUpdated()
        {
            var tilesViewManager = TilesViewManager;
            var viewer = new TilesNavViewer() { Id = "viewername" };
            var view = new PersonalTilesView()
            {
                Id = 0,
                Viewer = viewer
            };
            var newView = tilesViewManager.SaveView(view);
            Assert.True(newView.Id > 0);
            Assert.NotNull(tilesViewManager.LoadPersonalView(viewer, false));
            var updatedView = tilesViewManager.SaveView(view);
            Assert.Equal(newView.Id, updatedView.Id);
        }

        [Fact]
        public void ThrowIfInexistentPersonalViewGetUpdated()
        {
            var tilesViewManager = TilesViewManager;
            var viewer = new TilesNavViewer() { Id = "viewername" };
            var view = new PersonalTilesView()
            {
                Id = 1,
                Viewer = viewer,
                Owner = new User() { AccountName = "bla" }
            };
            Assert.Throws<InvalidOperationException>(() => tilesViewManager.SaveView(view));
        }
        
        [Fact]
        public void ThrowIfPersonalViewWithSameViewerIsAdded()
        {
            var tilesViewManager = TilesViewManager;
            var viewer = new TilesNavViewer() { Id = "viewername" };
            var view1 = new PersonalTilesView()
            {
                Viewer = viewer
            };
            var newView = tilesViewManager.SaveView(view1);
            var view2 = new PersonalTilesView()
            {
                Viewer = viewer
            };
            Assert.Throws<InvalidOperationException>(() => tilesViewManager.SaveView(view2));
        }

        [Fact]
        public void ThrowIfForeignPersonalViewGetsUpdated()
        {
            var tilesViewManager = TilesViewManager;
            var viewer = new TilesNavViewer() { Id = "viewername" };
            var view1 = new PersonalTilesView()
            {
                Viewer = viewer
            };
            var newView = tilesViewManager.SaveView(view1);
            ((PersonalTilesView)newView).Owner = new User() { AccountName = view1.Owner.AccountName + "_changed" };
            Assert.Throws<InvalidOperationException>(() => tilesViewManager.SaveView(newView));
        }

        private TilesViewManager TilesViewManager
        {
            get
            {
                var personalViewsRepo = new FakeTilesNavRepositoryWithIntId<PersonalTilesView>();
                var defaultViewsRepo = new FakeTilesNavRepositoryWithIntId<DefaultTilesView>();
                var viewerRepo = new FakeTilesNavRepositoryWithStringId<TilesNavViewer>();
                var userMgr = new FakeUserManager();
                return new TilesViewManager(userMgr, personalViewsRepo, defaultViewsRepo, viewerRepo);
            }
        }

        private User CurrentUser
        {
            get
            {
                var userMgr = new FakeUserManager();
                return userMgr.CurrentUser;
            }
        }
    }
}
