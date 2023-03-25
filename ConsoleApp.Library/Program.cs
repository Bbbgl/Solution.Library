using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using ConsoleApp.Library.Options;

using Model.Library;
using Proxy.Library;
using Proxy.Library.ServiceViewModels;

namespace ConsoleApp.Library
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //IUserDAO userDAO = new UserDAO();
            //IBookDAO bookDAO = new BookDAO();
            //IReservationDAO reservationDAO = new ReservationDAO();

            //IRepository repository = new Repository(userDAO,bookDAO,reservationDAO);

            //LibraryBusinessLogic lbl = new LibraryBusinessLogic(repository);


            // LOGIN
           User currentUser;
            string username, password;

            IBookProxy bookProxy = new API_BookProxy();
             IUserProxy userProxy= new API_UserProxy();
           IReservationProxy reservationProxy = new WCFReservationProxy();

            IBookProxy wcfBook = new WCFBookProxy();

            
            

            do {
                do
                {
                    Console.WriteLine("nome utente : ");
                    username = Console.ReadLine();
                } while (username == "");

                do
                {
                    Console.WriteLine("password : ");
                    password = Console.ReadLine();
                } while (password == "");

                var userViewModel = new LoginServiceViewModel(username, password);

                
             //  var currentUserRequest =  await userProxy.LoginAsync(userViewModel);
                currentUser =userProxy.Login(userViewModel);
               
                

                if (currentUser.Username == null) {
                    Console.WriteLine("Nome utente o password errati");
                    // Console.WriteLine("Press any key to quit");
                    //Console.ReadLine();
                    //System.Environment.Exit(1);
                }
            } while (currentUser.Username == null);




            Console.WriteLine("Login avvenuto con successo");

            while (currentUser.Role == "Admin")
            {
                Console.WriteLine("amministratore");


                // creare IMenu: poi istanzia per admin e per user
                IMenu menu = new AdminMenu();
                Menu menuToShow = new Menu(menu);
                menuToShow.Show();

                var decision = Console.ReadLine();
                if (decision == "1")
                {
                    Console.WriteLine("Creazione di un libro");
                    // SE UN LIBRO é GIA ESISTENTE AGGIORNO LA QUANTITAVVV
                    IOptionSelected optionSelected = new CreazioneDiUnLibro(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;

                }
                if (decision == "2")
                {


                    Console.WriteLine("Modifica di un libro");

                    IOptionSelected optionSelected = new ModificaDiUnLibro(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;
                }
                if (decision == "3")
                {
                    Console.WriteLine("Cancellazione di un libro");

                    IOptionSelected optionSelected = new CancellazioneDiUnLibro(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;
                }
                if (decision == "4")
                {
                    Console.WriteLine("Ricerca di un libro");

                    IOptionSelected optionSelected = new RicercaDiUnLibro(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();
                }
                if (decision == "5")
                {
                    Console.WriteLine("Prenotazione di un libro");

                    IOptionSelected optionSelected = new PrenotazioneDiUnLibro(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;

                }
                if (decision == "6")
                {
                    Console.WriteLine("Restituzione di un libro");

                    IOptionSelected optionSelected = new RestituzioneDiUnLibro(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;
                }
                if (decision == "7")
                {
                    Console.WriteLine("Visualizzazione Storico Prenotazioni");

                    IOptionSelected optionSelected = new VisualizzazioneStoricoPrenotazioniAdmin(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                }

                if (decision == "8")
                {
                    System.Environment.Exit(1);
                }

                //var bookTitleToSearch = Console.ReadLine();
                //var bookAuthorNameToSearch = Console.ReadLine();
                //var bookAuthorSurnameToSearch = Console.ReadLine();
                //var bookPublishingHouseToSearch = Console.ReadLine();

                //var queryId = book_list.Where(b => b.Title == bookTitleToSearch).Select(e => e.BookId).Take(1).ToList();
                //var queryQuantity = book_list.Where(b => b.Title == bookTitleToSearch).Select(e => e.Quantity).Take(1).ToList();


                //var book = new Book(queryId[0], bookTitleToSearch, bookAuthorNameToSearch,
                //    bookAuthorSurnameToSearch
                //    , bookPublishingHouseToSearch, queryQuantity[0]);
                ////var foundAvaiableBooks = libraryBusinessLogic.SearchBookWithAvailabilityInfos(book);
                //libraryBusinessLogic.ReserveBook(book.BookId, currentUser.UserId);



            }

            while (currentUser.Role == "User")
            {
                Console.WriteLine("Utilizzatore");

                // creare IMenu: poi istanzia per admin e per user
                IMenu menu = new UserMenu();
                Menu menuToShow = new Menu(menu);
                menuToShow.Show();

                var decision = Console.ReadLine();
                if (decision == "1")
                {
                    Console.WriteLine("Ricerca di un libro");

                    IOptionSelected optionSelected = new RicercaDiUnLibro(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;

                }
                if (decision == "2")
                {
                    Console.WriteLine("Prenotazione di un libro");


                    //IOptionSelected optionSelected = new PrenotazioneDiUnLibro();
                    IOptionSelected optionSelected = new PrenotazioneDiUnLibro(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;

                    //var queryId = book_list.Where(b => b.Title == bookTitleToSearch).Select(e => e.BookId).Take(1).ToList();
                    //var queryQuantity = book_list.Where(b => b.Title == bookTitleToSearch).Select(e => e.Quantity).Take(1).ToList();


                    //var book = new Book(queryId[0], bookTitleToSearch, bookAuthorNameToSearch,
                    //    bookAuthorSurnameToSearch
                    //    , bookPublishingHouseToSearch, queryQuantity[0]);
                    ////var foundAvaiableBooks = libraryBusinessLogic.SearchBookWithAvailabilityInfos(book);
                    //libraryBusinessLogic.ReserveBook(book.BookId, currentUser.UserId);

                }
                if (decision == "3")
                {
                    Console.WriteLine("Restituzione di un libro");


                    //IOptionSelected optionSelected = new PrenotazioneDiUnLibro();
                    IOptionSelected optionSelected = new RestituzioneDiUnLibro(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;
                }
                if (decision == "4")
                {
                    Console.WriteLine("Visualizzazione Storico Prenotazioni");

                    IOptionSelected optionSelected = new VisualizzazioneStoricoPrenotazioniUser(currentUser, bookProxy);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                }


                if (decision == "5")
                {
                    System.Environment.Exit(1);// chiude l'applicazione
                }

            }



        }


    }
}


