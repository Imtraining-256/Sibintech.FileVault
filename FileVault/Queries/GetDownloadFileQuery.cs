using FileVault.Model;
using MediatR;

namespace FileVault.Queries
{
    public class GetDownloadFileQuery : IRequest<FileModel>
    {
        public GetDownloadFileQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
