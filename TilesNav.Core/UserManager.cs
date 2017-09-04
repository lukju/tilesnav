using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Core.Interfaces;
using TilesNav.Model;

namespace TilesNav.Core
{
    public class UserManager : IUserManager
    {
        public User CurrentUser => new User("fake_user");
    }
}
