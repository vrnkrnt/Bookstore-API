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
        private readonly LibraryRepository library;

        public BookInfoController()
        {
            library = new LibraryRepository();
        }

        [HttpGet]
        public IHttpActionResult SearchBook(string searchText)
        {
            var books = library.GetBooks(searchText);
            return Ok(books);
        }

        [HttpPost]
        [Route("api/bookinfo/createbook")]
        public IHttpActionResult CreateBook([FromBody] BookModel newBook)
        {
            library.SetBook(newBook);
            return Ok();
        }

        [HttpPost]
        [Route("api/bookinfo/suggestbook")]
        public IHttpActionResult CreateSuggestion([FromBody] BookSuggestionModel suggestion)
        {
            library.SuggestBook(suggestion);
            return Ok();
        }
    }
}
