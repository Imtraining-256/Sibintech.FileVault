using FileVault.DAL.Entities;
using MediatR;

namespace FileVault.Queries
{
    public class AddFileToUserCommand : IRequest<UploadFile>
    {
        public AddFileToUserCommand(string userName, byte[] content, string fileName)
        {
            UserName = userName;
            Content = content;
            FileName = fileName;    
        }

        public string UserName { get; private set; }
        public byte[] Content { get; private set; }
        public string FileName { get; private set; }


    }
}
