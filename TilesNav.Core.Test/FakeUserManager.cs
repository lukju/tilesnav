using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Core.Interfaces;
using TilesNav.Model;

namespace TilesNav.Core.Test
{
    class FakeUserManager : IUserManager
    {
        public User CurrentUser => new User() { AccountName = "fake_user" };
    }
}
