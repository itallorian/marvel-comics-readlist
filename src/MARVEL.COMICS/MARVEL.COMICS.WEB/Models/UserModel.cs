using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Models;
using MARVEL.COMICS.BUSINESSLOGIC.Models.Settings;
using MARVEL.COMICS.BUSINESSLOGIC.Models.User;
using MARVEL.COMICS.BUSINESSLOGIC.Utils;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MARVEL.COMICS.WEB.Models
{
    public class UserModel : IUserModel
    {
        private readonly AppSettings _settings;
        private readonly HttpUtils _httpUtils;

        public UserModel(AppSettings settings)
        {
            _settings = settings;
            _httpUtils = new HttpUtils();
        }

        public async Task<UserOutput> Login(string username, string password)
        {
            try
            {
                var token = await _httpUtils.GetToken
                    (
                        string.Concat(_settings.Endpoint.Api, "/token"),
                        _settings.Application.Id,
                        _settings.Application.Secret
                    );

                if (token != null)
                {

                    var payload = new Login { UserName = username, Password = password };

                    var user = await _httpUtils.Post
                        (
                            string.Concat(_settings.Endpoint.Api, "/user/login"),
                            JsonConvert.SerializeObject(payload),
                            token.Token
                        );

                    if (string.IsNullOrEmpty(user) == false)
                    {
                        return JsonConvert.DeserializeObject<UserOutput>(user);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
