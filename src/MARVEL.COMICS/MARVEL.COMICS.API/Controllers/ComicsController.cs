using MARVEL.COMICS.BUSINESSLOGIC.Constants;
using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Services;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Comics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MARVEL.COMICS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComicsController : ControllerBase
    {
        private ComicOutput _output;

        /// <summary>
        /// Property to return status code.
        /// </summary>
        private HttpStatusCode _httpStatusCode;

        private readonly IComicService _comicService;

        public ComicsController(IComicService comicService)
        {
            _output = new ComicOutput();

            _comicService = comicService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListComics([FromQuery] string title)
        {
            try
            {
                var comics = await _comicService.ListComics(title);

                if (comics != null)
                {
                    _output.Message = "Success";
                    _output.Success = true;
                    _output.Comic = comics;
                    _httpStatusCode = HttpStatusCode.OK;
                }
                else
                {
                    _httpStatusCode = HttpStatusCode.BadRequest;
                    _output.Message = "Failed";
                }
            }
            catch (Exception)
            {
                _httpStatusCode = HttpStatusCode.InternalServerError;
                _output.Message = Messages.InternalErrorWithoutTreatment;
            }

            return StatusCode(_httpStatusCode.GetHashCode(), _output);
        }

        [HttpPost]
        [Route("addreadlist")]
        public async Task<IActionResult> AddReadingList([FromBody] ReadingList readingList)
        {
            try
            {
                await _comicService.AddToReadingList(readingList.ComicId, readingList.UserId);

                _httpStatusCode = HttpStatusCode.NoContent;
                _output.Success = true;
            }
            catch (Exception)
            {
                _httpStatusCode = HttpStatusCode.InternalServerError;
                _output.Message = Messages.InternalErrorWithoutTreatment;
            }

            return StatusCode(_httpStatusCode.GetHashCode(), _output);
        }

        [HttpGet]
        [Route("markasread/{id}")]
        public async Task<IActionResult> MarkAsRead([FromRoute] decimal id)
        {
            try
            {
                await _comicService.MarkAsRead(id);

                _httpStatusCode = HttpStatusCode.NoContent;
                _output.Success = true;
            }
            catch (Exception)
            {
                _httpStatusCode = HttpStatusCode.InternalServerError;
                _output.Message = Messages.InternalErrorWithoutTreatment;
            }

            return StatusCode(_httpStatusCode.GetHashCode(), _output);
        }

        [HttpGet]
        [Route("removefromreadinglist/{id}")]
        public async Task<IActionResult> RemoveFromReadingList([FromRoute] decimal id)
        {
            try
            {
                await _comicService.RemoveFromReadingList(id);

                _httpStatusCode = HttpStatusCode.NoContent;
                _output.Success = true;
            }
            catch (Exception)
            {
                _httpStatusCode = HttpStatusCode.InternalServerError;
                _output.Message = Messages.InternalErrorWithoutTreatment;
            }

            return StatusCode(_httpStatusCode.GetHashCode(), _output);
        }

        [HttpGet]
        [Route("getall/{id}")]
        public async Task<IActionResult> GetAll([FromRoute] decimal id)
        {
            try
            {
                var comics = await _comicService.GetAll(id);

                _httpStatusCode = HttpStatusCode.OK;
                _output.ReadingList = comics;
                _output.Success = true;
            }
            catch (Exception)
            {
                _httpStatusCode = HttpStatusCode.InternalServerError;
                _output.Message = Messages.InternalErrorWithoutTreatment;
            }

            return StatusCode(_httpStatusCode.GetHashCode(), _output);
        }
    }
}
