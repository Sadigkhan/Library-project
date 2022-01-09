using System;
using System.Collections.Generic;
using System.Text;

namespace Daily_practice
{
    class Book
    {
        static int count=0;
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }

        public string Code;


        public Book(string name,string authorName,int pageCount)
        {
            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;
            count++;
            Code = name.Substring(0, 2) + count;

        }
        public override string ToString()
        {
            return $"\nKitabin adi:{Name}\nYazarin adi:{AuthorName}\nSehife sayi:{PageCount}\nKitabin ID nomresi:{Code}";
        }
    }
}
