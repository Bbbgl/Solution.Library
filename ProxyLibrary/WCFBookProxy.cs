
using Model.Library;
using Proxy.Library.ServiceViewModels;
using Proxy.Library.SOAPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{
    public class WCFBookProxy : IBookProxy
    {
        public static ServiceLibraryClient slc = new ServiceLibraryClient();
        public void AddBook(AddingBookServiceViewModel bsvm)
        {           
            
            slc.AddBook(Mapper.MapperAddingBSVMtoAddingBVM(bsvm));
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

        public List<Book> ReadBooks()
        {
            return slc.ReadBooks();    
        }
    }


}
