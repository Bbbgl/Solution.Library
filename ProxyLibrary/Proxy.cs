using ConsoleApp.Library.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{ // 3 interfacce una per entità user book reserv...
    public interface IBookProxy
    {
        void AddBook(AddingBookViewModel BVM);


    }
}
