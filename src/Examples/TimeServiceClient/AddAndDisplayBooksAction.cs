//-------------------------------------------------------------------------------
// <copyright file="AddAndDisplayBooksAction.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Author: Remo Gloor (remo.gloor@gmail.com)
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace TimeService.Client
{
    using System;
    using System.Linq;

    using TimeService.Client.BookStore;

    /// <summary>
    /// Adds a book and shows a rondom one from the list.
    /// </summary>
    public class AddAndDisplayBooksAction : IBookAction
    {
        /// <summary>
        /// The book store entities.
        /// </summary>
        private readonly BookStoreEntities bookStoreEntities;

        /// <summary>
        /// A random number generator.
        /// </summary>
        private readonly Random randomNumberGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddAndDisplayBooksAction"/> class.
        /// </summary>
        /// <param name="bookStoreEntities">The book store entities.</param>
        public AddAndDisplayBooksAction(BookStoreEntities bookStoreEntities)
        {
            this.bookStoreEntities = bookStoreEntities;
            this.randomNumberGenerator = new Random();
        }

        /// <summary>
        /// Performs the action.
        /// </summary>
        public void PerformAction()
        {
            this.AddRandomBook();
            this.ShowRandomBook();
        }

        /// <summary>
        /// Shows a random book.
        /// </summary>
        private void ShowRandomBook()
        {
            int bookCount = this.bookStoreEntities.Books.Count();
            int randomBook = this.randomNumberGenerator.Next(bookCount);
            var book = this.bookStoreEntities.Books.Skip(randomBook).First();

            Console.WriteLine("Book ({1}/{0}): {2}\r\n{3}", bookCount, randomBook, book.Title, book.Description);
        }

        /// <summary>
        /// Adds a new random book.
        /// </summary>
        private void AddRandomBook()
        {
            var book = new Book
                {
                    Title = "SomeTitle: " + Guid.NewGuid(),
                    Description = "SomeDescription: " + Guid.NewGuid()
                };
            this.bookStoreEntities.AddToBooks(book);
            this.bookStoreEntities.SaveChanges();
        }
    }
}