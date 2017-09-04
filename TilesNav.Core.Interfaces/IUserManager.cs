using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Model;

namespace TilesNav.Core.Interfaces
{
    public interface IUserManager
    {
        User CurrentUser { get; }
    }
}
