using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FileVault.DAL;
using FileVault.Model;
using FileVault.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FileVault.Handlers
{
    public class GetDownloadFileQueryHandler : IRequestHandler<GetDownloadFileQuery, FileModel>
    {
        private readonly VaultFileContext _db;

        public GetDownloadFileQueryHandler(VaultFileContext _db)
        {
            this._db = _db;
        }

        public Task<FileModel> Handle(GetDownloadFileQuery request, CancellationToken cancellationToken)
        {
            return _db.UploadFiles.Where(r => r.Id == request.Id)
                .Include(r => r.File)
                .Select(r => new FileModel() { Content = r.File.Content, FileName = r.FileName })
                .FirstOrDefaultAsync();
        }
    }
}
