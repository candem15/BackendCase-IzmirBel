namespace Application.Features.Commands.Token.GetToken
{
    public class GetTokenCommandResponse
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}