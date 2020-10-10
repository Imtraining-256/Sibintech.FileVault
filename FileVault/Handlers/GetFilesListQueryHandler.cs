using FileVault.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FileVault.DAL;
using FileVault.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileVault.Handlers
{
    public class GetFilesListQueryHandler : IRequestHandler<GetFilesListQuery, ICollection<UploadFile>>
    {
        private readonly VaultFileContext _db;

        public GetFilesListQueryHandler(VaultFileContext db)
        {
            _db = db;
        }

        public async Task<ICollection<UploadFile>> Handle(GetFilesListQuery request, CancellationToken cancellationToken)
        {
            return await _db.UploadFiles.Where(r => r.User.Name == request.UserName).ToListAsync();
        }
    }
}
