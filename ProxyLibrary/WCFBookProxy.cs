using ConsoleApp.Library.Options;
using Proxy.Library.SOAPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{
    public class WCFBookProxy : IBookProxy
    {
        public void AddBook(AddingBookViewModel BVM)
        {
            var slc = new ServiceLibraryClient();
            slc.AddBook(BVM);
        }
    }
}
