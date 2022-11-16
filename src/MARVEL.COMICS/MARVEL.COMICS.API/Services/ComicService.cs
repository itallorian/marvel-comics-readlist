using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Repositories;
using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Services;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Comics;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Settings;
using MARVEL.COMICS.BUSINESSLOGIC.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MARVEL.COMICS.API.Services
{
    public class ComicService : IComicService
    {
        /// <summary>
        /// Global class of settings loaded at the start of the application.
        /// </summary>
        private readonly AppSettings _settings;

        private readonly HttpUtils _httpUtils;

        private readonly IReadingListRepository _readingListRepository;

        public ComicService(AppSettings settings, IReadingListRepository readingListRepository)
        {
            _settings = settings;

            _httpUtils = new HttpUtils();
            _readingListRepository = readingListRepository;
        }

        public async Task AddToReadingList(string comicId, decimal userId)
        {
            _readingListRepository.AddReadingList(comicId, userId);

            await Task.CompletedTask;
        }

        public async Task<Comic> ListComics(string title)
        {
            try
            {
                var endpoint = string.Concat
                    (
                        _settings.Marvel.ApiEndpoint,
                        string.Format
                            (
                                "/comics?orderBy=focDate&limit={0}&apikey={1}&hash={2}&ts={3}",
                                _settings.Marvel.SearchLimit,
                                _settings.Marvel.PublicKey,
                                _settings.Marvel.Hash,
                                _settings.Marvel.TimeStamp
                            )
                    );

                if (string.IsNullOrEmpty(title) == false)
                {
                    endpoint += "&title=" + title;
                }

                var comics = JsonConvert.DeserializeObject<Comic>(await _httpUtils.Get(endpoint));

                return comics;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task MarkAsRead(decimal id)
        {
            _readingListRepository.MarkAsRead(id);

            await Task.CompletedTask;
        }

        public async Task RemoveFromReadingList(decimal id)
        {
            _readingListRepository.RemoveFromReadingList(id);

            await Task.CompletedTask;
        }

        public async Task<List<ReadingList>> GetAll(decimal userId)
        {
            var result = _readingListRepository.GetAll(userId);

            foreach (var item in result)
            {
                await GetItem(item);
            }

            return result;
        }

        public async Task GetItem(ReadingList register)
        {
            try
            {
                var endpoint = string.Concat
                    (
                        _settings.Marvel.ApiEndpoint,
                        string.Format
                            (
                                "/comics/{0}?apikey={1}&hash={2}&ts={3}",
                                register.ComicId,
                                _settings.Marvel.PublicKey,
                                _settings.Marvel.Hash,
                                _settings.Marvel.TimeStamp
                            )
                    );


                var comics = JsonConvert.DeserializeObject<Comic>(await _httpUtils.Get(endpoint));

                register.Comic = comics;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
