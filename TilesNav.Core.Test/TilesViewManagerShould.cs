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
            var result = tilesViewManager.LoadPersonalView("non-existent-viewer", true);
            Assert.Null(result);
        }

        [Fact]
        public void ReturnNullIfLoadingInexistentDefaultView()
        {
            var tilesViewManager = TilesViewManager;
            var result = tilesViewManager.LoadDefaultView("non-existent-viewer");
            Assert.Null(result);
        }

        [Fact]
        public void ReturnDefaultViewIfPersonalViewDoesNotExist()
        {
            var tilesViewManager = TilesViewManager;
            var defaultView = new DefaultTilesView()
            {
                Viewer = "viewername"
            };
            tilesViewManager.SaveView(defaultView);
            var result = tilesViewManager.LoadPersonalView("viewername", true);
            Assert.Equal(result, defaultView);
        }

        [Fact]
        public void StorePersonalViewIfNewPersonalViewIsAdded()
        {
            var tilesViewManager = TilesViewManager;
            var view = new PersonalTilesView()
            {
                Viewer = "viewername"
            };
            Assert.Null(tilesViewManager.LoadPersonalView("viewername", false));
            var newView = tilesViewManager.SaveView(view);
            Assert.NotNull(tilesViewManager.LoadPersonalView("viewername", false));
        }

        [Fact]
        public void StorePersonalViewIfPersonalViewIsUpdated()
        {
            var tilesViewManager = TilesViewManager;
            var view = new PersonalTilesView()
            {
                ID = 0,
                Viewer = "viewername"
            };
            var newView = tilesViewManager.SaveView(view);
            Assert.True(newView.ID > 0);
            Assert.NotNull(tilesViewManager.LoadPersonalView("viewername", false));
            var updatedView = tilesViewManager.SaveView(view);
            Assert.Equal(newView.ID, updatedView.ID);
        }

        [Fact]
        public void ThrowIfInexistentPersonalViewGetUpdated()
        {
            var tilesViewManager = TilesViewManager;
            var view = new PersonalTilesView()
            {
                ID = 1,
                Viewer = "viewername",
                Owner = new User("bla")
            };
            Assert.Throws<InvalidOperationException>(() => tilesViewManager.SaveView(view));
        }

        [Fact]
        public void ThrowIfPersonalViewGetsUpdatedWithDifferentViewerName()
        {
            var tilesViewManager = TilesViewManager;
            var view = new PersonalTilesView()
            {
                ID = 0,
                Viewer = "viewername"
            };
            tilesViewManager.SaveView(view);
            var view_withChangedViewer = new PersonalTilesView()
            {
                ID = view.ID,
                Viewer = "viewername_changed"
            };
            Assert.Throws<InvalidOperationException>(() => tilesViewManager.SaveView(view_withChangedViewer));
        }

        [Fact]
        public void ThrowIfPersonalViewGetsUpdatedWithDifferentID()
        {
            var tilesViewManager = TilesViewManager;
            var view = new PersonalTilesView()
            {
                Viewer = "viewername"
            };
            tilesViewManager.SaveView(view);
            var view_withChangedId = new PersonalTilesView()
            {
                ID = view.ID + 1,
                Viewer = "viewername"
            };
            Assert.Throws<InvalidOperationException>(() => tilesViewManager.SaveView(view_withChangedId));
        }

        [Fact]
        public void ThrowIfPersonalViewWithSameViewerIsAdded()
        {
            var tilesViewManager = TilesViewManager;
            var view1 = new PersonalTilesView()
            {
                Viewer = "viewername"
            };
            var newView = tilesViewManager.SaveView(view1);
            var view2 = new PersonalTilesView()
            {
                Viewer = "viewername"
            };
            Assert.Throws<InvalidOperationException>(() => tilesViewManager.SaveView(view2));
        }

        [Fact]
        public void ThrowIfForeignPersonalViewGetsUpdated()
        {
            var tilesViewManager = TilesViewManager;
            var view1 = new PersonalTilesView()
            {
                Viewer = "viewername"
            };
            var newView = tilesViewManager.SaveView(view1);
            ((PersonalTilesView)newView).Owner = new User(view1.Owner.AccountName + "_changed");
            Assert.Throws<InvalidOperationException>(() => tilesViewManager.SaveView(newView));
        }

        private TilesViewManager TilesViewManager
        {
            get
            {
                var personalViewsRepo = new FakeTilesNavRepositoryWithIntId<PersonalTilesView>();
                var defaultViewsRepo = new FakeTilesNavRepositoryWithIntId<DefaultTilesView>();
                var userMgr = new FakeUserManager();
                return new TilesViewManager(userMgr, personalViewsRepo, defaultViewsRepo);
            }
        }
    }
}
