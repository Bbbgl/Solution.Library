using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Library;

namespace DataAccessLayer.Library
{
    public interface IBookDAO
    {
        List<Book> Read();

       
        void Create(Book book);

        void Update(Book book,int id_book);

        void UpdateIds(int id_book);

        void Delete (int id_book);

     }
}
