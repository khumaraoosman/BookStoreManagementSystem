using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ConsoleUI.Menus
{
    public class AuthorMenu(IAuthorService authorService)
    {
        private readonly IAuthorService _authorService = authorService;

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("========== AUTHOR MENU =========");
                Console.WriteLine("1. Add Author");
                Console.WriteLine("2. Show Authors");
                Console.WriteLine("3. Author Books");
                Console.WriteLine("4. Update Author");
                Console.WriteLine("5. Delete Author");
                Console.WriteLine("0. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddAuthor(); break;
                    case "2": ShowAuthors(); break;
                    case "3": AuthorBooks(); break;
                    case "4": UpdateAuthor(); break;
                    case "5": DeleteAuthor(); break;
                    case "0": return;
                }
            }
        }

        private void DeleteAuthor()
        {
            throw new NotImplementedException();
        }

        private void UpdateAuthor()
        {
            throw new NotImplementedException();
        }

        private void AuthorBooks()
        {
            throw new NotImplementedException();
        }

        private void ShowAuthors()
        {
            throw new NotImplementedException();
        }

        private void AddAuthor()
        {
            throw new NotImplementedException();
        }
    }

    internal interface IAuthorService
    {
    }
}
