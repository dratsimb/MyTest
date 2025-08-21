using Safran.Client.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safran.Client
{
    public class SafranClient:BaseWrapper(rootUri)
    {
        public SafranClient(Uri rootUri): base(rootUri) 
        {
            _userList = new Lazy<UserListWrapper>(rootUri + "/users");
        }

        Lazy<UserListWrapper> _userList;
        public UserListWrapper Users => _userList.Value;

    }
}
