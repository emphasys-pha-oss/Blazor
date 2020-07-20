using Blazor_HelloWorld.Data.Interface;
using Blazor_HelloWorld.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazor_HelloWorld.Data.Implementation
{
    public class AuthorService : IAuthorService
    {
        public DateTime CreationDate { get; set; }

        List<Author> Authors { get; set; }
        public AuthorService()
        {
            CreationDate = DateTime.Now;

            Authors = new List<Author>();

            for (int i = 0; i < 10; i++)
            {
                Authors.Add(new Author
                {
                    AuthorID = i,
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    City = $"City",
                    EmailAddress = $"email@email.com",
                    Salary = 1000 * i
                });
            }
        }

        public List<Author> GetAuthors()
        {
            return Authors;
        }

        public Author GetAuthorByID(int authorID)
        {
            return Authors.FirstOrDefault(x => x.AuthorID == authorID);
        }

        public DateTime GetCreatedDate()
        {
            return CreationDate;
        }

        public string GetVersion()
        {
            return "V1";
        }
    }
}
