
using BusinessLogic.Library;
using BusinessLogic.Library.ViewModels;
using ConsoleApp.Library.Options;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.ModelBinding;

namespace SOAPService.Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceLibrary
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        User Login(LoginViewModel lvm);

        [OperationContract]
        void AddBook(AddingBookViewModel BVM);

        [OperationContract]
        List<Book> SearchBook(Book book);
        [OperationContract]
        List<SearchingBookViewModel> SearchBookWithAvailabilityInfos(BookViewModel bvm);

        [OperationContract]
        void UpdateBook(int bookId, Book bookWithNewValues);

        [OperationContract]
        bool DeleteBook(BookViewModel bvm); 

        
        [OperationContract]
        ReservationResult ReserveBookPROVA(int bookId, int userId);

        [OperationContract]
        void ReserveBook(int bookId, int userId);

        [OperationContract]
        ReservationResult BookReturn(int bookId, int userId);

        [OperationContract]
        List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationStatus? reservationStatus);




        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // to delete
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    
    


     
        
    
}
