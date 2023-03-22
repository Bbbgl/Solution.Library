
using Model.Library;
using Proxy.Library.ServiceViewModels;
using Proxy.Library.SOAPLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = Model.Library.User;

namespace Proxy.Library
{
    public class WCFUserProxy : IUserProxy
    {
      
        

        public static ServiceLibraryClient slc = new ServiceLibraryClient();

        public User Login(LoginServiceViewModel lvm)
        {
            throw new NotImplementedException();
        }

       
        Task<User> IUserProxy.LoginAsync(LoginServiceViewModel lvm)
        {
            throw new NotImplementedException();
        }
    }
}
