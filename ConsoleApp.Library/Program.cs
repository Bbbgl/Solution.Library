using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BusinessLogic.Library;
using BusinessLogic.Library.ViewModels;
using ConsoleApp.Library.Options;
using DataAccessLayer.Library;
using Model.Library;

namespace ConsoleApp.Library
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserDAO userDAO = new UserDAO();
            IBookDAO bookDAO = new BookDAO();
            IReservationDAO reservationDAO = new ReservationDAO();

            IRepository repository = new Repository(userDAO,bookDAO,reservationDAO);

            LibraryBusinessLogic lbl = new LibraryBusinessLogic(repository);
            
            

            Console.WriteLine("nome utente : ");
            var username = Console.ReadLine();
            Console.WriteLine("password : ");
            var password = Console.ReadLine(); // pensa a come mettere le *

            var userViewModel = new LoginViewModel(username, password);

           
            var currentUser = lbl.Login(userViewModel);

            if (currentUser.Username == null) {
                Console.WriteLine("Nome utente o password errati");
                Console.WriteLine("Press any key to quit");
                Console.ReadLine();
                System.Environment.Exit(1);
            }
           
           

            else Console.WriteLine("Login avvenuto con successo");

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
                    IOptionSelected optionSelected = new CreazioneDiUnLibro(currentUser, lbl);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;

                }
                if (decision == "2")
                {


                    Console.WriteLine("Modifica di un libro");

                    IOptionSelected optionSelected = new ModificaDiUnLibro(currentUser, lbl);
                    OptionSelected optionToDo = new OptionSelected(optionSelected );
                    optionToDo.Doing();

                    continue;
                }
                if (decision == "3")
                {
                    Console.WriteLine("Cancellazione di un libro");

                    IOptionSelected optionSelected = new CancellazioneDiUnLibro(currentUser, lbl);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;
                }
                if (decision == "4")
                {
                    Console.WriteLine("Ricerca di un libro");

                    IOptionSelected optionSelected = new RicercaDiUnLibro(currentUser,lbl);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();
                }
                if(decision == "5")
                {
                    Console.WriteLine("Prenotazione di un libro");

                    IOptionSelected optionSelected = new PrenotazioneDiUnLibro(currentUser, lbl);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;

                }if (decision == "6")
                {
                    Console.WriteLine("Restituzione di un libro");

                    IOptionSelected optionSelected = new RestituzioneDiUnLibro(currentUser, lbl);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;
                }
                if (decision == "7")
                {
                    Console.WriteLine("Visualizzazione Storico Prenotazioni");

                    IOptionSelected optionSelected = new VisualizzazioneStoricoPrenotazioniAdmin(currentUser, lbl);
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

            while(currentUser.Role == "User")
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

                    IOptionSelected optionSelected = new RicercaDiUnLibro(currentUser, lbl);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;

                }
                if (decision == "2")
                {
                    Console.WriteLine("Prenotazione di un libro");


                    //IOptionSelected optionSelected = new PrenotazioneDiUnLibro();
                    IOptionSelected optionSelected = new PrenotazioneDiUnLibro(currentUser, lbl);
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
                    IOptionSelected optionSelected = new RestituzioneDiUnLibro(currentUser, lbl);
                    OptionSelected optionToDo = new OptionSelected(optionSelected);
                    optionToDo.Doing();

                    continue;
                }

                if (decision == "5")
                {
                    System.Environment.Exit(1);// chiude l'applicazione
                }

            }

            //var admin = libraryBusinessLogic.AdminCheck(username, listaUtentiDalDb);// Uvm anche qui
            //var role = "amministratore";
            //if (admin)
            //{
            //    Console.WriteLine("amministratore");

            //}

            //else
            //{
            //    Console.WriteLine("Utilizzatore");
            //    role = "utilizzatore";

            //}
            //var queryUserId = listaUtentiDalDb.Where(u => u.Username == username).Select(e => e.UserId).Take(1).ToList();
            //var currentUser = new User(queryUserId[0], username, password, role);

            //BookDAO book_db = new BookDAO();
            //var book_list = book_db.Read();

            //while (!admin)
            //{
            //    // creare IMenu: poi istanzia per admin e per user
            //    IMenu menu = new UserMenu();
            //    Menu menuToShow = new Menu(menu);
            //    menuToShow.Show();

            //    var decision = Console.ReadLine();
            //    if (decision == "1")
            //    {
            //        Console.WriteLine("Ricerca di un libro");

            //        IOptionSelected optionSelected = new RicercaDiUnLibro();
            //        OptionSelected optionToDo = new OptionSelected(optionSelected);
            //        optionToDo.Doing();

            //        continue;

            //    }
            //    if (decision == "2")
            //    {
            //        Console.WriteLine("Prenotazione di un libro");
            //        var bookTitleToSearch = Console.ReadLine();
            //        var bookAuthorNameToSearch = Console.ReadLine();
            //        var bookAuthorSurnameToSearch = Console.ReadLine();
            //        var bookPublishingHouseToSearch = Console.ReadLine();

            //        var queryId = book_list.Where(b => b.Title == bookTitleToSearch).Select(e => e.BookId).Take(1).ToList();
            //        var queryQuantity = book_list.Where(b => b.Title == bookTitleToSearch).Select(e => e.Quantity).Take(1).ToList();


            //        var book = new Book(queryId[0], bookTitleToSearch, bookAuthorNameToSearch,
            //            bookAuthorSurnameToSearch
            //            , bookPublishingHouseToSearch, queryQuantity[0]);
            //        //var foundAvaiableBooks = libraryBusinessLogic.SearchBookWithAvailabilityInfos(book);
            //        libraryBusinessLogic.ReserveBook(book.BookId, currentUser.UserId);

            //    }

            //    if (decision == "5")
            //    {
            //        System.Environment.Exit(1);// chiude l'applicazione
            //    }
            //}

            //while (admin)// TODO: se l'utente non esiste, viene individuato cmq come amministratore, risolvere sta cosa

            //{
            //    IMenu menu = new AdminMenu();
            //    Menu menuToShow = new Menu(menu);
            //    menuToShow.Show();

            //    var decision = Console.ReadLine();
            //    if (decision == "1")
            //    {
            //        Console.WriteLine("Creazione di un libro");

            //        IOptionSelected optionSelected = new CreazioneDiUnLibro();
            //        OptionSelected optionToDo = new OptionSelected(optionSelected);
            //        optionToDo.Doing();
            //        continue;
            //    }
            //    if (decision == "2")
            //    {
            //        Console.WriteLine("Modifica di un libro");

            //        IOptionSelected optionSelected = new ModificaDiUnLibro();
            //        OptionSelected optionToDo = new OptionSelected(optionSelected);
            //        optionToDo.Doing();

            //        continue;
            //    }
            //    if (decision == "3")
            //    {
            //        Console.WriteLine("Cancellazione di un libro");

            //        IOptionSelected optionSelected = new CancellazioneDiUnLibro();
            //        OptionSelected optionToDo = new OptionSelected(optionSelected);
            //        optionToDo.Doing();

            //        continue;
            //    }
            //    if (decision == "4")
            //    {
            //        Console.WriteLine("Ricerca di un libro");

            //        IOptionSelected optionSelected = new RicercaDiUnLibro();
            //        OptionSelected optionToDo = new OptionSelected(optionSelected);
            //        optionToDo.Doing();
            //    }
            //    if (decision == "8")
            //    {
            //        System.Environment.Exit(1);
            //    }

            }
            
        }
    }


