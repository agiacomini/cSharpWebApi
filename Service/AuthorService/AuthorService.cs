using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data;
using cSharpWebApi.Data.Author;
using cSharpWebApi.Data.Author.Dto;
using cSharpWebApi.Data.AuthorBook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cSharpWebApi.Service.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly DatabaseContext _context;

        public AuthorService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Author>> CreateAuthor(CreateAuthor author)
        {
            var newauthor = new Author()
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                AddressId = author.AddressId
            };
            foreach (var item in author.BookId)
            {
                newauthor.AuthorBooks.Add(new AuthorBook()
                {
                    Author = newauthor,
                    BookId = item
                });
            }

            _context.Authors.Add(newauthor);
            await _context.SaveChangesAsync();

            // return await GetAllAuthors();
            return await _context.Authors.ToListAsync();
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            var authors = await _context.Authors.Include(x => x.AuthorBooks)
                                                .ThenInclude(ab => ab.Book)
                                                .ToListAsync();
            return authors;
        }

        public async Task<Author?> GetSingleAuthor(int id)
        {
            var author = await _context.Authors.Include(x => x.AuthorBooks)
                                               .ThenInclude(y => y.Book)
                                               .FirstOrDefaultAsync(x => x.Id == id);
            if (author is null)
                return null;
            return author;
        }

        public async Task<Author?> UpdateAuthor(int id, UpdateAuthor author)
        {
            var authorToUpdate = _context.Authors
                                         .Include(x => x.AuthorBooks)
                                         .ThenInclude(x => x.Book)
                                         .FirstOrDefault(x => x.Id == id);

            authorToUpdate.FirstName = author.FirstName != null ? author.FirstName : authorToUpdate.FirstName;
            authorToUpdate.LastName = author.LastName != null ? author.LastName : authorToUpdate.LastName;
            authorToUpdate.AddressId = (int)(author.AddressId != null ? author.AddressId : authorToUpdate.AddressId);

            if (author.BookId != null && author.BookId.Length > 0){
                // var existingAuthorBookIds = authorToUpdate.AuthorBooks.Select(x => x.Id).ToList();
                var existingBookIds = authorToUpdate.AuthorBooks.Select(x => x.BookId).ToList();

                var selectedBookIds = author.BookId.ToList();

                var toAdd = selectedBookIds.Except(existingBookIds).ToList();
                var toRemove = existingBookIds.Except(selectedBookIds).ToList();

                var listAuthorBookToRemove = new List<AuthorBook>();
                foreach (var item in toRemove)
                {
                   listAuthorBookToRemove.Add(_context.AuthorBook
                                              .Where(x => x.BookId == item && x.AuthorId == id)
                                              .FirstOrDefault<AuthorBook>());
                }
                foreach (var item in listAuthorBookToRemove)
                {
                    _context.AuthorBook.Remove(item);
                }

                var listAuthorBookToAdd = new List<AuthorBook>();
                foreach (var item in toAdd)
                {
                    listAuthorBookToAdd.Add(new AuthorBook()
                    {
                        AuthorId = id,
                        BookId = item
                    });
                }
                foreach (var item in listAuthorBookToAdd)
                {
                    _context.AuthorBook.Add(item);
                }

                authorToUpdate.AuthorBooks = authorToUpdate.AuthorBooks.Where(x => !toRemove.Contains(x.BookId)).ToList();
            }

            _context.Authors.Update(authorToUpdate);
            await _context.SaveChangesAsync();
            return authorToUpdate;
        }

        public async Task<ActionResult<IEnumerable<Author>>> DeleteAuthor(int id)
        {
            var authorToDelete = await _context.Authors.Include(x => x.AuthorBooks)
                                                       .FirstOrDefaultAsync(x => x.Id == id);
            if (authorToDelete is null)
                return null;
                
            _context.Authors.Remove(authorToDelete);
            await _context.SaveChangesAsync();

            return await _context.Authors.ToListAsync();
        }
    }
}