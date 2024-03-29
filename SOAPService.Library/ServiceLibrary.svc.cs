﻿using BusinessLogic.Library;
using BusinessLogic.Library.ViewModels;


using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAPService.Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceLibrary : IServiceLibrary
    {
        
       public class LibraryBusinessLogicForService
        {


            public LibraryBusinessLogic lbl = new LibraryBusinessLogic();


        }

        public LibraryBusinessLogic lbl()
        {
            var lblfs = new LibraryBusinessLogicForService();
            return lblfs.lbl;
        }

       


        // public ServiceLibrary() { }




        public string GetData(int value)
        {
            
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public User Login(LoginViewModel lvm)
        {
            return lbl().Login(lvm);
            
        }


        public void AddBook(AddingBookViewModel BVM)
        {
            lbl().AddBook(BVM);
        }

        public List<Book> SearchBook(Book book)
        {
            return lbl().SearchBook(book);
        }

        

        public List<SearchingBookViewModel> SearchBookWithAvailabilityInfos(BookViewModel bvm)
        {
            return lbl().SearchBookWithAvailabilityInfos(bvm);
        }
        
        public void UpdateBook(int bookId, Book bookWithNewValues)
        {
            lbl().UpdateBook(bookId, bookWithNewValues);
        }

        public bool DeleteBook(BookViewModel bvm)
        {
            return lbl().DeleteBook(bvm);
        }

        public ReservationResult ReserveBookPROVA(int bookId, int userId)
        {
            return lbl().ReserveBookPROVA(bookId, userId);
        }

        public void ReserveBook(int bookId, int userId)
        {
            lbl().ReserveBook(bookId, userId);
        }

        public ReservationResult BookReturn(int bookId, int userId)
        {
            return lbl().BookReturn(bookId, userId);
        }

        public List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationStatus? reservationStatus)
        {
            return lbl().GetReservationHistory(bookId, userId, reservationStatus);
        }

        public Book MapperBVMtoBOOK(BookViewModel bvm)
        {

            var mapper = new MapperBook();
            return mapper.MapperBVMtoBOOK(bvm);
        }

        public Book MapperModifyingBVMtoBOOK(ModifyingBookViewModel modifyingBVM)
        {
            var mapper = new MapperBook();
            return mapper.MapperModifyingBVMtoBOOK(modifyingBVM);
        }

        public Book MapperABVMtoBOOK (AddingBookViewModel abvm)
        {
            var mapper = new MapperBook();
            return mapper.MapperAddingBVMtoBOOK(abvm);
        }

        public Book MapperReservingBVMtoBOOK(ReservingBookViewModel rbvm)
        {
            var mapper = new MapperBook();
            return mapper.MapperReservingBVMtoBOOK(rbvm);
        }

        public Book MapperReturningBVMtoBOOK(ReturningBookViewModel returningBVM)
        {
            var mapper = new MapperBook();
            return mapper.MapperReturningBVMtoBOOK(returningBVM);
        }

        public List<User> MapperUsernameVMtoUserList(UsernameViewModel uvm)
        {
            var mapper = new MapperBook();
            return mapper.MapperUsernameVMtoUserList(uvm);
        }

        public List<Book> MapperBVMtoBOOKforGetReservationsHistory(BookViewModel bvm)
        {
            var mapper = new MapperBook();
            return mapper.MapperBVMtoBOOKforGetReservationsHistory(bvm);
        }

        public List<Book> ReadBooks()
        {
            return lbl().SearchBooks();
        }
    }
}
