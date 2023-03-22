using Model.Library;
using Proxy.Library.ServiceViewModels;
using Proxy.Library.SOAPLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Library
{
    public class Mapper


        
    {
        public static ServiceLibraryClient slc = new ServiceLibraryClient();


        public static AddingBookViewModel MapperAddingBSVMtoAddingBVM(AddingBookServiceViewModel absvm)
        {
            var abvm = new AddingBookViewModel();

            abvm.Title = absvm.Title;
            abvm.AuthorName = absvm.AuthorName;
            abvm.AuthorSurname = absvm.AuthorSurname;
            abvm.PublishingHouse = absvm.PublishingHouse;
            abvm.Quantity = absvm.Quantity;

            return abvm;
        }

        public static LoginViewModel MapperLSVMtoLVM(LoginServiceViewModel lsvm)
        {
            var lvm = new SOAPLibrary.LoginViewModel();

            lvm.Username = lsvm.Username;
            lvm.Password = lsvm.Password;

            return lvm;


        }


        public static ModifyingBookViewModel MapperMBSVMtoMBVM (ModifyingBookServiceViewModel mbsvm)
        {

            var mbvm = new ModifyingBookViewModel();

            mbvm.Title = mbsvm.Title;
            mbvm.AuthorName = mbsvm.AuthorName;
            mbvm.AuthorSurname = mbsvm.AuthorSurname;
            mbvm.PublishingHouse = mbsvm.PublishingHouse;
            

            return mbvm;
        }


        public static Book MapperMBSVMtoBOOK(ModifyingBookServiceViewModel mbsvm)// fallo qui con il serviceviewmodel e restituisci il book
        {
            var mbvm =  MapperMBSVMtoMBVM(mbsvm);
           
            return slc.MapperModifyingBVMtoBOOK(mbvm);
        }

        public static Book MapperABVMtoBOOK(AddingBookViewModel abvm)
        {
            return slc.MapperABVMtoBOOK(abvm);
        }

        public static BookViewModel MapperBSVMtoBVM(BookServiceViewModel bsvm)
        {
            var bvm = new BookViewModel();

            bvm.Title = bsvm.Title;
            bvm.AuthorName = bsvm.AuthorName;
            bvm.AuthorSurname = bsvm.AuthorSurname;
            bvm.PublishingHouse = bsvm.PublishingHouse;


            return bvm;
        }

        public static Book MapperBVMtoBOOK(BookViewModel bvm)
        {
            return slc.MapperBVMtoBOOK(bvm);
        }

        public static ReservationStatus MapperSRStoRS(ServiceReservationStatus serviceReservationStatus)
        {
            var reservationStatus = new ReservationStatus();

            reservationStatus.Status = serviceReservationStatus.Status;

            return reservationStatus;
        }

        public static ReservingBookViewModel MapperRBSVMtoRBVM(ReservingBookServiceViewModel bookToReserveServiceViewModel)
        {
            var rbvm = new ReservingBookViewModel();

            rbvm.Title = bookToReserveServiceViewModel.Title;
            rbvm.AuthorName = bookToReserveServiceViewModel.AuthorName;
            rbvm.AuthorSurname = bookToReserveServiceViewModel.AuthorSurname;
            rbvm.PublishingHouse = bookToReserveServiceViewModel.PublishingHouse;
            
            return rbvm;
        }

        public static Book MapperReservingBVMtoBOOK(ReservingBookViewModel rbvm)
        {
            return slc.MapperReservingBVMtoBOOK(rbvm);
        }

        public static ReturningBookViewModel MapperReturningBSVMtoRBVM(ReturningBookServiceViewModel bookToReturnServiceViewModel)
        {
            var rbvm = new ReturningBookViewModel();

            rbvm.Title=bookToReturnServiceViewModel.Title;
            rbvm.AuthorName=bookToReturnServiceViewModel.AuthorName;
            rbvm.AuthorSurname=bookToReturnServiceViewModel.AuthorSurname;
            rbvm.PublishingHouse=bookToReturnServiceViewModel.PublishingHouse;

            return rbvm;


        }


        public static Book MapperReturningBVMtoBOOK(ReturningBookViewModel rbvm)
        {
            return slc.MapperReturningBVMtoBOOK(rbvm);
        }

        public static UsernameViewModel MapperUSVMtoUVM(UsernameServiceViewModel usvm)
        {
            var uvm = new UsernameViewModel();
            uvm.Userame = usvm.Userame;
            return uvm;
        }

        public static List<User> MapperUsernameVMtoUserList(UsernameViewModel uvm)
        {
            return slc.MapperUsernameVMtoUserList(uvm);

        }

        public static List<Book> MapperBVMtoBOOKforGetReservationsHistory(BookViewModel bvm)
        {
            return slc.MapperBVMtoBOOKforGetReservationsHistory(bvm);
        }

        public static ReservationViewModel MapperRSVMtoRVM ( ReservationServiceViewModel rsvm)
        {
            var rvm = new ReservationViewModel();

            rvm.Username = rsvm.Username;
            rvm.StartDate = rsvm.StartDate; 
            rvm.EndDate=rsvm.EndDate;
            rvm.BookTitle = rsvm.BookTitle;
            rvm.ReservationFlag= rsvm.ReservationFlag;

            return rvm;
        }

        public static List<ReservationViewModel> MapperListRSVMtoListRVM(List<ReservationServiceViewModel> serviceResult)
        {
            var list = new List<ReservationViewModel>();

            foreach (var rsvm in serviceResult)
            {
                list.Add(MapperRSVMtoRVM(rsvm));
            }
            return list;
        }

       
    }
}
