using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Services
{

    public class GoogleService
    {
        UserCredential? credential;

        public const string ClientId = "35469603597-htfvps87d81eqfe57r9n65g8iejb41fm.apps.googleusercontent.com";

        public static readonly ClientSecrets clientSecrets = new ClientSecrets
        {
            ClientId = "35469603597-htfvps87d81eqfe57r9n65g8iejb41fm.apps.googleusercontent.com",
            ClientSecret = "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"
        };

    public async Task<Payload> GoogleLogin()
        {
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                new[] { PeopleServiceService.Scope.UserinfoProfile, PeopleServiceService.Scope.UserinfoEmail },
                "user",
                CancellationToken.None,
                new FileDataStore("Drive.Auth.Store"));

            try
            {
                if (credential.Token.IsExpired(SystemClock.Default))
                {
                    bool success = await credential.RefreshTokenAsync(CancellationToken.None);
                    if (!success)
                    {
                        GoogleLogout();
                        throw new Exception("Failed to refresh access token.");
                    }
                }
            }
            catch (Exception ex)
            {
                GoogleLogout();
            }

            var payload = await GoogleJsonWebSignature.ValidateAsync(credential.Token.IdToken.ToString());
            payload.JwtId = credential.Token.IdToken;
            return payload;
        }


        public void GoogleLogout()
        {
            if (credential != null)
            {
                // Invalidar la sesión actual
                credential?.RevokeTokenAsync(CancellationToken.None).Wait();

                // Eliminar el token de acceso
                new FileDataStore("Drive.Auth.Store").ClearAsync().Wait();

                credential = null;
            }
        }

    }
}
