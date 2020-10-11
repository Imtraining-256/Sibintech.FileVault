using FileVault.Model;
using MediatR;

namespace FileVault.Queries
{
    public class GetDownloadFileQuery : IRequest<FileModel>
    {
        public GetDownloadFileQuery(int id, string fileName)
        {
            Id = id;
            FileName = fileName;
        }

        public int Id { get; private set; }
        public string FileName { get; private set; }
    }
}
