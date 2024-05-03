using MoretelecomPaymentAPI.Main;

namespace MoretelecomPaymentAPI
{
    public interface ITokenRefresher
    {
        AuthenticationResponse Refresh(RefreshCred refreshCred);
    }
}
