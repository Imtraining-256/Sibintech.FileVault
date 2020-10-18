using FileVault.DAL;
using FileVault.DAL.Entities;
using FileVault.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace FileVault.Handlers
{
    public class AddFileToUserCommandHandler : IRequestHandler<AddFileToUserCommand, Unit>
    {
        private readonly VaultFileContext _dbContext;

        public AddFileToUserCommandHandler(VaultFileContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddFileToUserCommand request, CancellationToken cancellationToken)   
        {
            var user = await GetOrCreateUser(request.UserName);

            var file = await GetOrCreateFile(request.Content);

            await AddFileToUser(user, file, request.FileName);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task<UploadFile> AddFileToUser(User user, File file, string requestFileName)
        {
            var uploadFile =
                await _dbContext.UploadFiles.FirstOrDefaultAsync(r => r.UserId == user.Id && r.FileId == file.Id && r.FileName == requestFileName);

            if (uploadFile != null)
            {
                return uploadFile;
            }

            uploadFile = new UploadFile(file.Id, requestFileName, DateTime.Now);

            user.UploadFiles ??= new List<UploadFile>();

            user.UploadFiles.Add(uploadFile);

            return uploadFile;
        }

        private async Task<User> GetOrCreateUser(string userName)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(r => r.Name == userName);

            if (user == null)
            {
                user = new User(userName);

                await _dbContext.Users.AddAsync(user);
            }

            return user;
        }

        private async Task<File> GetOrCreateFile(byte[] content)
        {
            var hash = CalcHash(content);

            var file = await _dbContext.Files.FirstOrDefaultAsync(r => r.Hash == hash);

            if (file == null)
            {
                file = new File(content, hash);

                await _dbContext.Files.AddAsync(file);

                await _dbContext.SaveChangesAsync();
            }

            return file;
        }

        private string CalcHash(byte[] content)
        {
            using var sha256 = new SHA256Managed();

            byte[] bytes = sha256.ComputeHash(content);

            var hash = new System.Text.StringBuilder();

            foreach (var theByte in bytes)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }

    }
}
