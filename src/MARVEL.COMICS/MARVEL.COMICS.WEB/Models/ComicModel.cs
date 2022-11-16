using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Models;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Comics;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Settings;
using MARVEL.COMICS.BUSINESSLOGIC.Utils;
using MARVEL.COMICS.WEB.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MARVEL.COMICS.WEB.Models
{
    public class ComicModel : IComicModel<ComicViewModel>
    {
        private readonly AppSettings _settings;
        private readonly HttpUtils _httpUtils;

        public ComicModel(AppSettings settings)
        {
            _settings = settings;
            _httpUtils = new HttpUtils();
        }

        public async Task AddReadList(string comicId, decimal userId)
        {
            try
            {
                var token = await _httpUtils.GetToken(string.Concat(_settings.Endpoint.Api, "/token"), _settings.Application.Id, _settings.Application.Secret);

                if (token != null)
                {
                    var endpoint = string.Concat(_settings.Endpoint.Api, "/comics/addreadlist");

                    var paylod = new ReadingList { ComicId = comicId, UserId = userId };

                    await _httpUtils.Post(endpoint, JsonConvert.SerializeObject(paylod), token.Token);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ComicViewModel>> GetList(string title)
        {
            try
            {
                var viewModel = new List<ComicViewModel>();

                var token = await _httpUtils.GetToken(string.Concat(_settings.Endpoint.Api, "/token"), _settings.Application.Id, _settings.Application.Secret);

                if (token != null)
                {
                    var endpoint = string.Concat(_settings.Endpoint.Api, "/comics");

                    if (string.IsNullOrEmpty(title) == false)
                    {
                        endpoint += "?title=" + title;
                    }

                    var comics = await _httpUtils.Get(endpoint, token.Token);

                    if (string.IsNullOrEmpty(comics) == false)
                    {
                        var result = JsonConvert.DeserializeObject<ComicOutput>(comics);

                        if (result.Comic.status == "Ok" && result.Comic.data?.results.Count > 0)
                        {
                            foreach (var item in result.Comic.data.results)
                            {
                                var thumbnail = string.Concat(item.thumbnail.path, ".", item.thumbnail.extension);

                                viewModel.Add(new ComicViewModel(item.id, item.title, item.description, thumbnail));
                            }
                        }
                    }
                }

                return viewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ComicViewModel>> GetReadList(decimal id)
        {
            try
            {
                var viewModel = new List<ComicViewModel>();

                var token = await _httpUtils.GetToken(string.Concat(_settings.Endpoint.Api, "/token"), _settings.Application.Id, _settings.Application.Secret);

                if (token != null)
                {
                    var endpoint = string.Concat(_settings.Endpoint.Api, "/comics/getall/", id.ToString());

                    var comics = await _httpUtils.Get(endpoint, token.Token);

                    if (string.IsNullOrEmpty(comics) == false)
                    {
                        var result = JsonConvert.DeserializeObject<ComicOutput>(comics);

                        if (result.Success == true)
                        {
                            foreach (var item in result.ReadingList)
                            {
                                var register = item.Comic.data.results[0];

                                var thumbnail = string.Concat(register.thumbnail.path, ".", register.thumbnail.extension);

                                var comic = new ComicViewModel(register.id, register.title, register.description, thumbnail);

                                comic.ReadingListId = item.Id;

                                viewModel.Add(comic);
                            }
                        }
                    }
                }

                return viewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }

        public async Task RemoveReadList(decimal id)
        {
            try
            {
                var token = await _httpUtils.GetToken(string.Concat(_settings.Endpoint.Api, "/token"), _settings.Application.Id, _settings.Application.Secret);

                if (token != null)
                {
                    var endpoint = string.Concat(_settings.Endpoint.Api, "/comics/removefromreadinglist/", id);

                    await _httpUtils.Get(endpoint, token.Token);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
