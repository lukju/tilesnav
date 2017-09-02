using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Model;

namespace TilesNav.Core.Test
{
    class FakeUser : IUser
    {
        private string _accountName;

        public FakeUser(string accountName)
        {
            _accountName = accountName;
        }
        public string AccountName => _accountName;
    }
}
