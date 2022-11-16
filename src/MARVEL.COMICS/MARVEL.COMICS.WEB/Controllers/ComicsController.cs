using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Models;
using MARVEL.COMICS.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MARVEL.COMICS.WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "User")]
    public class ComicsController : Controller
    {
        private readonly IComicModel<ComicViewModel> _comicModel;

        public ComicsController(IComicModel<ComicViewModel> comicModel)
        {
            _comicModel = comicModel;
        }

        [HttpGet]
        [Route("comics")]
        public async Task<IActionResult> Index([FromQuery] string title)
        {
            try
            {
                var viewModel = await _comicModel.GetList(title);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("comics/addread/{id}")]
        public async Task<IActionResult> AddReadList([FromRoute] string id)
        {
            try
            {
                await _comicModel.AddReadList(id, Convert.ToDecimal(User.Identity.Name));

                return Redirect("/comics/readlist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("comics/removeread/{id}")]
        public async Task<IActionResult> RemoveReadList([FromRoute] decimal id)
        {
            try
            {
                await _comicModel.RemoveReadList(id);

                return Redirect("/comics/readlist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("comics/readlist")]
        public async Task<IActionResult> ReadList()
        {
            try
            {
                var viewModel = await _comicModel.GetReadList(Convert.ToDecimal(User.Identity.Name));

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
