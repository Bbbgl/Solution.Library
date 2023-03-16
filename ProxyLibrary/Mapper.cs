using Model.Library;
using Proxy.Library.ServiceViewModels;
using Proxy.Library.SOAPLibrary;
using SOAPService.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{
    public class Mapper


        
    {


        public SOAPService.Library.ServiceLibrary SL { get; set; }
        public static SOAPLibrary.AddingBookViewModel MapperAddingBSVMtoAddingBVM(AddingBookServiceViewModel bsvm)
        {
            var bvm = new SOAPLibrary.AddingBookViewModel();

            bvm.Title = bsvm.Title;
            bvm.AuthorName = bsvm.AuthorName;
            bvm.AuthorSurname = bsvm.AuthorSurname;
            bvm.PublishingHouse = bsvm.PublishingHouse;
            bvm.Quantity = bsvm.Quantity;

            return bvm;
        }

        public static LoginViewModel MapperLSVMtoLVM(LoginServiceViewModel lsvm)
        {
            var lvm = new SOAPLibrary.LoginViewModel();

            lvm.Username = lsvm.Username;
            lvm.Password = lsvm.Password;

            return lvm;


        }


        public static ModifyingBookViewModel MapperMBSVMtoMBVM(ModifyingBookServiceViewModel mbsvm)
        {

            var mbvm = new SOAPLibrary.ModifyingBookViewModel(); // il search bvm è praticamente come il modify, con titolo autore e casa


            mbvm.Title = mbsvm.Title;
            mbvm.AuthorName = mbsvm.AuthorName;
            mbvm.AuthorSurname = mbsvm.AuthorSurname;
            mbvm.PublishingHouse = mbsvm.PublishingHouse;


            return mbvm;

        }

        public  Book MapperSBVMtoBOOK(SOAPLibrary.SearchingBookViewModel sbvm)
        {

            
            
        }
    }
}
