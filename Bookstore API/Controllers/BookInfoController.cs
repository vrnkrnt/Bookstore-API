using Bookstore_API.Models;
using Bookstore_API.Repository;
using System;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace Bookstore_API.Controllers
{
    public class BookInfoController : ApiController
    {
        private readonly LibraryRepository _libraryRepository;

        public BookInfoController()
        {
            _libraryRepository = new LibraryRepository();
        }
        /*[HttpGet]
        public BookModel SearchBook(string ISBN)
        {
            var book = library.GetBooks(ISBN);
            return book;
        }*/

        [HttpGet]
        public IHttpActionResult SearchBook(string searchText)
        {
            var books = _libraryRepository.GetBooks(searchText);
            return Ok(books);
        }

        [HttpPost]
        [Route("api/bookinfo/createbook")]
        public IHttpActionResult CreateBook([FromBody] BookModel newBook)
        {
            if (newBook == null || string.IsNullOrEmpty(newBook.Title) || string.IsNullOrEmpty(newBook.Author) || string.IsNullOrEmpty(newBook.ISBN))
            {
                return BadRequest();
            }

            _libraryRepository.SetBook(newBook);
            return Ok();
        }

        [HttpPost]
        [Route("api/bookinfo/suggestbook")]
        public IHttpActionResult CreateSuggestion([FromBody] BookSuggestionModel suggestion)
        {
            if (suggestion == null || string.IsNullOrEmpty(suggestion.Name) || string.IsNullOrEmpty(suggestion.Author) || string.IsNullOrEmpty(suggestion.Title))
            {
                return BadRequest();
            }

            _libraryRepository.SuggestBook(suggestion);
            return Ok();
        }
    }
}
