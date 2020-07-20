using Blazor_HelloWorld.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_HelloWorld.Data.Interface
{
    public interface IAuthorService
    {

        List<Author> GetAuthors();

        Author GetAuthorByID(int authorID);

        DateTime GetCreatedDate();
        string GetVersion();
    }
}
