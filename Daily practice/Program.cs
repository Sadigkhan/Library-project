using System;
using System.Collections;
using System.Collections.Generic;

namespace Daily_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            do
            {
                Console.WriteLine("***************Khan Library***************");
                Console.WriteLine("Etmek istediyiniz emeliyyatin qarsisindaki nomreni daxil edin:");
                Console.WriteLine("\n1-Kitab elave et:");
                Console.WriteLine("\n2-Axtardigini adda kitablarin siyahisi:");
                Console.WriteLine("\n3-Butun kitablari goster:");
                Console.WriteLine("\n4-Ada gore kitablarin silinmesi:");
                Console.WriteLine("\n5-Kitab axtarisi:");
                Console.WriteLine("\n6-Sehife araligina gore kitab axtarisi:");
                Console.WriteLine("\n7-ID nomresine gore kitabin silinmesi:");
                Console.WriteLine("\nDaxil et:");

                string enter = Console.ReadLine();
                int checkEnter;
                int.TryParse(enter, out checkEnter);
                switch (checkEnter)
                {
                    case 1:
                        Console.Clear();
                       AddBook(ref library);
                        break;
                    case 2:
                        Console.Clear();
                        FindAllBooksByName(ref library);
                        break;
                    case 3:
                        Console.Clear();
                        ShowAllBooks(ref library);
                        break;
                    case 4:
                        Console.Clear();
                        RemoveAllBooksByName(ref library);
                        break;
                    case 5:
                        Console.Clear();
                        SearchBooks(ref library);
                        break;
                    case 6:
                        Console.Clear();
                        FindAllBooksByPageCountRange(ref library);
                        break;
                    case 7:
                        Console.Clear();
                        RemoveByNo(ref library);
                        break;                 
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun daxil edin");
                        break;


                }

            } while (true);
            
        }

        private static void RemoveByNo(ref Library library)
        {
            string ID = string.Empty;

            Console.WriteLine("Silmek istediyiniz kitaba uygun ID nomresini daxil edin...");
            ID = Console.ReadLine();
            bool finder = true;
            foreach (Book item in library.Booklist)
            {
                if (item.Code.ToUpper() == ID.ToUpper())
                {
                    library.Booklist.Remove(item);
                    finder = false;
                    Console.WriteLine("Daxil etdiyiniz ID nomresine uygun kitab tapildi ve ugurla kitabxana siyahisindan silindi...");
                    break;
                }
            }

            if (finder)
            {
                Console.WriteLine("Daxil olunan ID nomresine uygun kitab movcud deyil...");
            }

        }

        private static void FindAllBooksByPageCountRange(ref Library library)
        {
            if (library.Booklist.Count == 0)
            {
                Console.WriteLine("Kitabxanada hec bir kitab movcud deyil...");
                return;
            }
            string min = string.Empty;
            Console.WriteLine("Minimal sehife sayini daxil edin:");
            reEnterMin:
            min = Console.ReadLine();
            int min1;
            if (!int.TryParse(min,out min1)||min1<0)
            {
                Console.WriteLine("Duzgun daxil edin");
                goto reEnterMin;
            }

            string max = string.Empty;
            Console.WriteLine("Maksimal sehife sayini daxil edin");
            reEnterMax:
            max = Console.ReadLine();
            int max1;
            if (!int.TryParse(max, out max1)||max1<0)
            {
                Console.WriteLine("Duzgun daxil edin");
                goto reEnterMax;
            }
            if (int.TryParse(min, out min1)&&int.TryParse(max,out max1))
            {
                if (min1>max1)
                {
                    Console.WriteLine("Minimal deyer maksimal deyerden cox ola bilmez");
                }
                List<Book> Range = new List<Book>(library.Booklist.FindAll(x => x.PageCount >= min1 && x.PageCount <= max1));
                if (Range.Count==0)
                {
                    Console.WriteLine("Axtarisa uygun hec bir kitab movcud deyil...");
                    return;
                }
                Console.Clear();
                Console.WriteLine("Axtarisiniza uygun kitablarin siyahisi:");
                foreach (Book item in Range)
                {
                    
                    Console.WriteLine("____________________________");
                    Console.WriteLine(item);
                    Console.WriteLine("____________________________");
                };
            }
            else
            {
                Console.WriteLine("Duzgun daxil edin");
            }
            return;
            
            
        }

        private static void SearchBooks(ref Library library)
        {
            string value = string.Empty;
            if (library.Booklist.Count > 0)
            {
                bool check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Axtardiginiz kitabin her hansisa bir elametini daxil edin...");
                    }
                    else
                    {
                        Console.WriteLine("Bu elametde hec bir kitab movcud deyil...");
                    }
                    value = Console.ReadLine();
                    check = false;
                } while (!(library.Booklist.Exists((x => x.Name.ToUpper().Contains(value.ToUpper()) || x.AuthorName.ToUpper().Contains(value.ToUpper()) || x.PageCount.ToString().ToUpper().Contains(value.ToUpper())))));
               
                Console.WriteLine("Axtarisiniza uygun kitablar:");
                library.FindAllBooksByName(value);
            }
            else
            {
                Console.WriteLine("Kitabxananinzda hec bir kitab movcud deyil:");
            }
            List<Book> Result = new List<Book>(library.Booklist.FindAll((x => x.Name.ToUpper().Contains(value.ToUpper()) || x.AuthorName.ToUpper().Contains(value.ToUpper()) || x.PageCount.ToString().ToUpper().Contains(value.ToUpper()))));
            foreach (Book item in Result)
            {
                Console.WriteLine("_____________________________");
                Console.WriteLine(item);
                Console.WriteLine("_____________________________");
            }
        }

        private static void RemoveAllBooksByName(ref Library library)
        {
            string bookname = string.Empty;
            if (library.Booklist.Count > 0)
            {          
                bool check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Hansi addaki kitablari silmek isteyirsiniz?");
                    }
                    else
                    {
                        Console.WriteLine("Bu adda hec bir kitab movcud deyil...");
                    }
                    bookname = Console.ReadLine();
                    check = false;
                } while (!(library.Booklist.Exists(x => x.Name.ToUpper().Contains(bookname.ToUpper()))));
                Console.WriteLine("Daxil etdiyiniz ada uygun asagidaki kitablar tapildi ve silindi:");
                library.FindAllBooksByName(bookname);
            }
            else
            {
                Console.WriteLine("Kitabxananinzda hec bir kitab movcud deyil:");
            }
            List<Book> Result1 = new List<Book>(library.Booklist.FindAll((x => x.Name.ToLower().Contains(bookname))));
            foreach (Book item in Result1)
            {
                Console.WriteLine(item);
            }
            List<Book> Result = new List<Book>(library.Booklist.RemoveAll((x => x.Name.ToLower().Contains(bookname))));           
        }

        private static void ShowAllBooks(ref Library library)
        {
            library.ShowAllBooks();
        }

        private static void FindAllBooksByName(ref Library library)
        {
            string bookname = string.Empty;
            if (library.Booklist.Count > 0)
            {
                bool check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Hansi addaki kitablari axtarmaq isteyirsiniz?");
                    }
                    else
                    {
                        Console.WriteLine("Bu adda hec bir kitab movcud deyil...");
                    }
                    bookname = Console.ReadLine();
                    check = false;
                } while (!(library.Booklist.Exists(x => x.Name.ToUpper().Contains(bookname.ToUpper()))));
                Console.WriteLine("Axtarisiniza uygun kitablar:");
                library.FindAllBooksByName(bookname);
            }
            else
            {
                Console.WriteLine("Kitabxananinzda hec bir kitab movcud deyil:");
            }
            List<Book> Result = new List<Book>(library.Booklist.FindAll((x => x.Name.ToLower().Contains(bookname))));
            foreach (Book item in Result)
            {
                Console.WriteLine(item);
            }
        }
       
        private static void AddBook(ref Library library)
        {
            Console.WriteLine("Elave etmek istediyiniz kitabin adini daxil edin: ");
            reEnterBookName:
            string BookName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(BookName))
            {
                Console.WriteLine("Kitabin adini duzgun daxil edin");
                goto reEnterBookName;
            }
            Console.WriteLine("\nYazarin adini daxil edin: ");
            reEnterAuthorName:
            string AuthorName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(AuthorName))
            {
                Console.WriteLine("Yazarin adini duzgun daxil edin");
                goto reEnterAuthorName;
            }
            
            Console.WriteLine("\nKitabin vereq sayini daxil edin: ");
            reEnterPageCount:
            string PageCount = Console.ReadLine();
            int PageCount1 = 0;
            while (!int.TryParse(PageCount, out PageCount1))
            {
                Console.WriteLine("Sehife sayini duzgun daxil edin:");
                goto reEnterPageCount;
            }

            library.AddBook(BookName, AuthorName, PageCount1);
        }


    }
}