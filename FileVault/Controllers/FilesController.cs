﻿using FileVault.Extensions;
using FileVault.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<FilesController>
        [HttpGet]
        [Route("GetFilesList/{userName}")]
        //todo empty string 
        public async Task<IActionResult> GetFilesList(string userName)
        {
            var files= await _mediator.Send(new GetFilesListQuery(userName));

            return Ok(files);
        }

        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> GetDownloadFile([FromHeader]int id, [FromHeader]string fileName)
        {
            var file = await _mediator.Send(new GetDownloadFileQuery(id, fileName));

            return file == null
                ? (IActionResult) NotFound(fileName)
                : File(file.Content, "APPLICATION/octet-stream", file.FileName);
        }

        [HttpPost]
        [Route("AddFile")]
        public async Task<IActionResult> AddFile([FromForm]IFormFile file, [FromForm]string userName)
        {
            var uploadFile = await _mediator.Send(new AddFileToUserCommand(userName, await file.GetBytes(), file.FileName));

            return uploadFile == null ? (IActionResult) NotFound() : Ok(uploadFile);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var file = await _mediator.Send(new DeleteFileCommand(id));

            return file == null ? (IActionResult) NotFound() : Ok(file);
        }
    }
}
