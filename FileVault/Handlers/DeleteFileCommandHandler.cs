using System.Threading;
using System.Threading.Tasks;
using FileVault.DAL;
using FileVault.DAL.Entities;
using FileVault.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FileVault.Handlers
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, UploadFile>
    {
        private readonly VaultFileContext _dbContext;

        public DeleteFileCommandHandler(VaultFileContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<UploadFile> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var file = await _dbContext.UploadFiles.FirstOrDefaultAsync(r => r.Id == request.Id);

            if (file != null)
            {
                _dbContext.UploadFiles.Remove(file);
            }

            return file;
        }
    }
}
