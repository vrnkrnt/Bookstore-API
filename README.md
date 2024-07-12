# Bookstore-API

### Project description
This project involves a series of enhancements and extensions to an existing library system written in .NET C#. Below is a summary of the main tasks and the changes that have been implemented:

1. **Move hardcoded database link to configuration file:**
   - The link to the database XML file, which was previously hardcoded in `LibraryRepository.cs`, has been moved to a configuration file (`web.config` or `appsettings.json`). This allows users to change the database path without recompiling the code.

2. **Build a web page for book information via ISBN:**
   - A simple web application has been created to communicate with `BookInfoController` to search for books by ISBN.
   - The webpage is built using HTML and utilizes JavaScript/jQuery to send and receive data from the API. The information returned by the API is displayed on the webpage.

3. **Error handling and validation of incoming data:**
   - The API has been enhanced with validation to ensure incoming strings are not null, empty, or only contain whitespace. If invalid data is sent, the API returns an error message instead of crashing.
   - If a book is not found, this is handled on the webpage to clearly indicate an error has occurred, instead of displaying "Book not found!".

4. **Enhanced search functionality:**
   - The search functionality has been extended to support searches by title and author, in addition to ISBN. The result is a list of all matches that meet the search criteria.

5. **Add new books to the library:**
   - A POST method has been added to the API to enable the creation of new book objects in the XML file.
   - The method calls an internal SET method in `LibraryRepository` that handles the insertion of new books.

6. **New view for submitting new book values to the API:**
   - A new view has been created on the website where users can add new books. This view validates that no fields are empty or contain only whitespace. Error messages are displayed for invalid input.

7. **Function to submit book suggestions to the API:**
   - A function has been implemented that allows users to submit book suggestions to the API, including the name of the person submitting the suggestion, the author's name, and the book title.
   - The API checks if a folder for the current date exists in the project, creating one if it does not. It then saves a file with the suggestion in the folder. The filename follows a specific format and uses auto-increment for name conflicts.

### Summary
These enhancements and extensions have been made to increase the flexibility, usability, and functionality of the library system. The project now includes more robust error handling, improved search functionality, and capabilities for users to easily add new books and suggest new titles.
