using System;
using System.Collections.Generic;
using System.Text;

namespace Daily_practice
{
    class Library
    {
        public List<Book> Booklist = new List<Book>(0);

        public void AddBook(string name, string authorname, int pagecount)
        {
            Booklist.Add(new Book(name, authorname, pagecount));
        }


       public List<Book>FindAllBooksByName(string name)
        {
            return Booklist.FindAll((x => x.Name.ToLower().Contains(name.ToLower())));
        }


        public void ShowAllBooks()
        {
            Console.WriteLine("Kitabxanada movcud olan kitablarin siyahisi:");
            foreach (Book item in Booklist)
            {
                Console.WriteLine("___________________________________________");
                Console.WriteLine(item);
                Console.WriteLine("___________________________________________");

            }
        }


        public void RemoveAllBooksByName(string name)
        {
            Booklist.RemoveAll(x => x.Name.ToUpper().Contains(name.ToUpper()));
        }


        public List<Book> SearchBooks(string name)
        {
            return Booklist.FindAll(x => x.Name.ToUpper().Contains(name.ToUpper()) || x.AuthorName.ToUpper().Contains(name.ToUpper()) || x.PageCount.ToString().ToUpper().Contains(name.ToUpper()));
        }


        public List<Book> FindAllBooksByPageCountRange(int min, int max)
        {
            return Booklist.FindAll(x => x.PageCount >= min && x.PageCount <= max);
        }


        public void RemoveByNo(string ID)
        {
            foreach (Book item in Booklist)
            {
                if (item.Code.ToUpper() == ID.ToUpper())
                {
                    Booklist.Remove(item);
                }
            }
        }
    }
}

