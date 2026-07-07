using System;
namespace LibraryManagementSystem
{
    class Program
    {
        // class to handle book information
        class Book
        {
            public string title;
            public string author;
            public int publishedYear;
            public bool IsCheckedOut;
        }
        List<Book> books = new List<Book>();

        static void Main(string[] args)
        {
            bool run_program = true;
            Program program = new Program();
            while (run_program)
            {
                Console.WriteLine("Welcome to Austin's Library Management System\n" +
                    "Select from the following options:\n" +
                    "1. Add Book\n" +
                    "2. List Books\n" +
                    "3. Search Book\n" +
                    "4. Check Out Book\n" +
                    "5. Return Book\n" +
                    "6. Exit");
                // get and validate input 
                int input = program.numberValidation(Console.ReadLine());
                // switch statement for user input 
                switch (input)
                {
                    case 1:
                        // Add book to library
                        program.addBook();
                        break;
                    case 2:
                        // list books
                        program.list();
                        break;
                    case 3:
                        // Search for books
                        program.bookSearch();
                        break;
                    case 4:
                        // Check out a book
                        program.bookCheckout();
                        break;
                    case 5:
                        // return a book
                        program.bookReturn();
                        break;
                    case 6:
                        // end program
                        run_program = false;
                        break;
                }
            }
        }
        #region input validation
        string inputValidation(string input)
        {
            // while input is blank ask user for their input
            while(string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input can not be empty");
                input = Console.ReadLine();
            }
            // return input as string
            return input;
        }
        #endregion

        #region number validation
        int numberValidation(string input)
        {
            while(true)
            {
                int number = 0;
               while(string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input an not be empty");
                    input = Console.ReadLine();
                }
               if (int.TryParse(input, out number))
                {
                    return number;
                }
                Console.WriteLine("Enter a valid number");
                input = Console.ReadLine();
               
            }
        }
        #endregion

        #region Add Books
        void addBook()
        {
            Console.WriteLine("How many books do you want to add?");
            int num = numberValidation(Console.ReadLine());
            // for loop to add number of books
            for (int i = 0; i < num; i++)
            {

                Book book = new Book(); // Create a new book each loop
                Console.WriteLine($"Enter the title for book {i + 1}");
                string title = inputValidation(Console.ReadLine());
                book.title = title;
                Console.WriteLine($"Enter the author for book {i + 1}");
                string author = inputValidation(Console.ReadLine());
                book.author = author;
                Console.WriteLine($"Enter the year book {i + 1} was published");
                int year = numberValidation(Console.ReadLine());
                book.publishedYear = year;
                // automatically assume book is not checked out yet.
                book.IsCheckedOut = false;
                books.Add(book);
                Console.WriteLine("Book added");
                Console.WriteLine($"books count{books.Count}");
            }
        }
        #endregion

        #region List books
        void list()
        {
            // list all books 
            foreach (Book book in books)
            {
                Console.WriteLine(book.title);
                Console.WriteLine(book.author);
                Console.WriteLine(book.publishedYear);
            }
        }
        #endregion

        #region Book Search
        void bookSearch()
        {
            while (true)
            {
                Console.WriteLine("What is the title of the book you are looking for ?");
                string bookTitle = inputValidation(Console.ReadLine());
                bool bookFound = false;
                foreach (Book book in books)
                {
                    if (book.title.Contains(bookTitle))
                    {
                        Console.WriteLine($"Book Title: {book.title}");
                        Console.WriteLine($"Book author: {book.author}");
                        Console.WriteLine($"Published Year: {book.publishedYear}");
                        Console.WriteLine($"Checked out? {book.IsCheckedOut}");
                        bookFound = true;
                        return;
                    }
                }
                if (!bookFound)
                {
                    Console.WriteLine("Book not found, try searching again.");
                }
            }
        }

        #endregion

        #region Book Checkout
        void bookCheckout()
        {
            Console.WriteLine("If you haven't yet, get a list of the books in the library by hitting 2 at the menu");
            Console.WriteLine("What is the title of the book you want to checkout?");
            string checkOut = inputValidation(Console.ReadLine());
            bool bookFound = false;
            foreach(Book book in books)
            {
                if (book.title.Contains (checkOut))
                {
                    if (book.IsCheckedOut)
                    {
                        Console.WriteLine("That book is already checked out");
                    }
                    else
                    {
                        book.IsCheckedOut = true;
                        Console.WriteLine("Book has been checked out");
                    }
                    bookFound = true;
                    return;
                }
            }
            if (!bookFound)
            {
                Console.WriteLine("Book not found, try again");
            }
        }
        #endregion

        #region Book Return
        void bookReturn()
        {
            Console.WriteLine("What is the title of the book you are returning ?");
            bool bookFound = false;
            string bookTitle = inputValidation(Console.ReadLine());
            foreach(Book book in books)
            {
                if (book.title.Contains(bookTitle) && book.IsCheckedOut)
                {
                    book.IsCheckedOut = false;
                    Console.WriteLine("Book returned");
                    bookFound = true;
                    return;
                }
            }
            if (!bookFound)
            {
                Console.WriteLine("book not found");
            }
        }
        #endregion
    }
}