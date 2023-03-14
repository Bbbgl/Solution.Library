using BusinessLogic.Library.ViewModels;
using Model.Library;
using Proxy.Library.SOAPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = Proxy.Library.SOAPLibrary.User;

namespace Proxy.Library
{
    public class WCFUserProxy : IUserProxy
    {
        public static ServiceLibraryClient slc = new ServiceLibraryClient();
        public User Login(LoginViewModel lvm)
        {

            return slc.Login(lvm);
        }

       
    }
}
