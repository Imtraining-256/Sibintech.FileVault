using MediatR;
using System.Collections.Generic;
using FileVault.DAL.Entities;

namespace FileVault.Queries
{
    public class GetFilesListQuery : IRequest<ICollection<UploadFile>>
    {
        public GetFilesListQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; private set; }
    }
}
