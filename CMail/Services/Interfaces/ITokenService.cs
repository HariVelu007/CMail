using CMail.ViewModel;
using System.Threading.Tasks;

namespace CMail.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(string userid);
        TokenViewModel GetUserByToken(string token);

    }
}
