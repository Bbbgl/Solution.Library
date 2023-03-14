using BusinessLogic.Library;
using BusinessLogic.Library.ViewModels;

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
        public static ServiceLibraryClient slc = new ServiceLibraryClient();
        public void AddBook(AddingBookViewModel BVM)
        {
            //var slc = new ServiceLibraryClient();
            //slc.AddBook(BVM);
            slc.AddBook(BVM);
        }

        public bool DeleteBook(BookViewModel bvm)
        {
            return slc.DeleteBook(bvm);
        }

       

        public List<SearchingBookViewModel> SearchBookWithAvailabilityInfos(BookViewModel bvm)
        {
            return slc.SearchBookWithAvailabilityInfos(bvm);
        }

        public void UpdateBook(int bookId, Book bookWithNewValues)
        {
            slc.UpdateBook(bookId,bookWithNewValues);
        }
    }


}
