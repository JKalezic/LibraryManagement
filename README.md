# Library Management System

## Overview
A CLI application for managing a library's book collection and members. 
It tracks which books are available, which are borrowed, and by whom.

## Commands
- `add book` — Add a new book to the library
- `add member` — Register a new member
- `list books` — Show all books and their availability
- `list members` — Show all members and how many books they have borrowed
- `search` — Search for books by title or author
- `borrow` — Borrow a book by book ID and member ID
- `return` — Return a borrowed book
- `member books` — Show all books currently borrowed by a member
- `seed` — Populate the library with 50 books and 10 members
- `quit` — Exit the application

## Classes
**Book** — Represents a book with a title, author, and availability status. 
Created with a constructor that requires a title and author, and defaults to available.

**Member** — Represents a library member with a name and a list of currently borrowed books.

**Library** — Manages the collections of books and members. Contains all the logic 
for adding, searching, borrowing, and returning books.

## Technologies
- C# / .NET
- NUnit for unit testing

## What I Learned
- How to structure code across multiple classes and files
- Constructors — requiring data upfront when creating an object
- Encapsulation — keeping data private inside a class and exposing only what's needed
- Guard clauses — returning early from a method when something is wrong
- How to write unit tests with NUnit using Arrange, Act, Assert pattern
- The difference between a folder-based and solution-based Visual Studio setup

## Challenges
Setting up the test project was the most complex part — the test project needed 
to be a sibling of the main project rather than nested inside it, and Visual Studio 
required a solution file to properly discover and run the tests.

## Tests
7 unit tests covering:
- Borrowing marks a book as unavailable
- Returning marks a book as available
- New books default to available
- Borrowing an already borrowed book leaves it unavailable
- Returning a book removes it from the member's borrowed list
- Invalid book and member IDs don't crash the application

To run tests:
cd LibraryManagement.Tests
dotnet test