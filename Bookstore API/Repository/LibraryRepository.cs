using Bookstore_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Bookstore_API.Repository
{
    internal class LibraryRepository
    {
        private string _databasePath;

        public LibraryRepository()
        {
            _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["DatabasePath"]);
        }

        internal List<BookModel> GetBooks(string searchText)
        {
            var library = GetLibrary();
            var books = library.Books
                .Where(x => x.ISBN.Equals(searchText, StringComparison.OrdinalIgnoreCase) ||
                            x.Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            x.Author.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
            return books;
        }

        private LibraryModel GetLibrary()
        {
            var xmlSerializer = new XmlSerializer(typeof(LibraryModel));
            using (var context = new StreamReader(_databasePath))
            {
                return (LibraryModel)xmlSerializer.Deserialize(context);
            }
        }

        internal void SetBook(BookModel newBook)
        {
            var library = GetLibrary();
            library.Books.Add(newBook);

            var xmlSerializer = new XmlSerializer(typeof(LibraryModel));
            using (var writer = new StreamWriter(_databasePath))
            {
                xmlSerializer.Serialize(writer, library);
            }
        }

        internal void SuggestBook(BookSuggestionModel suggestion)
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyy-MM-dd");
            Directory.CreateDirectory(folderPath);

            string fileNameBase = $"{suggestion.Name[0]}_{DateTime.Now:yyyy-MM-dd}_{suggestion.Author[0]}";
            string fileName = fileNameBase;
            int counter = 1;
            while (File.Exists(Path.Combine(folderPath, $"{fileName}.txt")))
            {
                fileName = $"{fileNameBase}{counter}";
                counter++;
            }

            string filePath = Path.Combine(folderPath, $"{fileName}.txt");
            File.WriteAllText(filePath, $"Title: {suggestion.Title}\nSender: {suggestion.Name}"); 
        }
    }
}