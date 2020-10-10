using FileVault.DAL.Entities;
using MediatR;

namespace FileVault.Queries
{
    public class DeleteFileCommand : IRequest<UploadFile>
    {
        public DeleteFileCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
