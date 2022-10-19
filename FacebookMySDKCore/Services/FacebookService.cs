using FacebookMySDKCore.Data;
using FacebookMySDKCore.Models;
using System.Threading.Tasks;

namespace FacebookMySDKCore.Services
{
    public interface IFacebookService
    {
        Task<Account> GetAccountAsync(string accessToken);

        Task PostOnWallAsync(string accessToken, string message);
    }

    internal class FacebookService : IFacebookService
    {

        #region Properties
        private readonly IFacebookClient _facebookClient;
        #endregion Properties



        #region Commands

        #endregion Commands



        #region Constructors
        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }
        #endregion Constructors



        #region Methods
        public async Task<Account> GetAccountAsync(string accessToken)
        {
            var result = await _facebookClient.GetAsync<dynamic>(accessToken, "me", "fields=id,name,email,first_name,last_name,username");

            if (result == null) return new Account();

            var account = new Account
            {
                Id = result.id,
                Email = result.email,
                Name = result.name,
                FirstName = result.first_name,
                LastName = result.last_name,
                UserName = result.username
            };


            return account;
        }

        public async Task PostOnWallAsync(string accessToken, string message) => await _facebookClient.PostAsync(accessToken, "me/feed", new { message });
        #endregion Methods

    }
}
