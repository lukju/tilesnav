using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Model;

namespace TilesNav.Core
{
    public interface ITilesViewManager
    {
        TilesView LoadPersonalView(string viewerName, bool fallbackToDefaultView = true);
        TilesView LoadDefaultView(string viewerName);

        TilesView SaveView(TilesView view);

        /// <exception cref="KeyNotFoundException">If a Default View with given ID does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">If not allowed to delete.</exception>
        void DeletePersonalView(int id);
        /// <exception cref="KeyNotFoundException">If a Personal View with given ID does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">If not allowed to delete.</exception>
        void DeleteDefaultView(int id);
    }
}
