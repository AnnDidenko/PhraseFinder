using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Phrase_Finder.Domain.Helpers
{
    public class JWTHelper
    {
        public string JWTSecretKey { get; set; }

        public SymmetricSecurityKey GetSecretKey() =>
             new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTSecretKey));
    }
}
