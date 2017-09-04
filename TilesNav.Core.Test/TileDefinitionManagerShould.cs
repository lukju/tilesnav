using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Model;
using Xunit;

namespace TilesNav.Core.Test
{
    public class TileDefinitionManagerShould
    {
        [Fact]
        public void AddDefinitionWithEmptyGuid()
        {
            var mgr = TileDefinitionManager;
            var td = new TileDefinition();
            var added = mgr.SaveDefinition(td);
            Assert.NotEqual(added.ID, Guid.Empty);
            Assert.NotNull(mgr.GetDefinition(added.ID));
        }

        [Fact]
        public void UpdatingOfInexistentDefinitionThrows()
        {
            var mgr = TileDefinitionManager;
            var td = new TileDefinition() { ID = Guid.NewGuid() };
            Assert.Throws<InvalidOperationException>(() => mgr.SaveDefinition(td));
        }

        private TileDefinitionManager TileDefinitionManager
        {
            get
            {
                var definitionRepo = new FakeTilesNavRepositoryWithGuidId<TileDefinition>();
                return new TileDefinitionManager(definitionRepo);
            }
        }
    }
}
