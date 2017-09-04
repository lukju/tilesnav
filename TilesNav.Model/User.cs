using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Model
{
    public class User: AbstractTilesNavBaseType<int>
    {
        private User() { }
        public User(string accountName)
        {
            AccountName = accountName;
        }
        public string AccountName { get; private set; }
    }
}
