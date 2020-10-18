using FileVault.Extensions;
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
        public async Task<IActionResult> GetFilesList(string userName)
        {
            var files= await _mediator.Send(new GetFilesListQuery(userName));

            return Ok(files);
        }

        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> GetDownloadFile([FromQuery]int id)
        {
            var file = await _mediator.Send(new GetDownloadFileQuery(id));

            return file == null
                ? (IActionResult) NotFound()
                : File(file.Content, "APPLICATION/octet-stream", file.FileName);
        }

        [HttpPost]
        [Route("AddFile")]
        public async Task<IActionResult> AddFile([FromForm]IFormFile file, [FromForm]string userName)
        {
            await _mediator.Send(new AddFileToUserCommand(userName, await file.GetBytes(), file.FileName));

            return Ok();
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
