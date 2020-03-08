using System.Net.Http;
using System.Threading.Tasks;

namespace testing
{
    public class HttpMessageHandlerMock : HttpMessageHandler
    {
        HttpResponseMessage _response;
        public HttpRequestMessage Request { get; set; }

        public HttpMessageHandlerMock(HttpResponseMessage response)
        {
            _response = response;
        }

        protected override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(
            System.Net.Http.HttpRequestMessage request,
            System.Threading.CancellationToken cancellationToken)
        {
            Request = request;
            return Task.FromResult(_response);
        }
    }
}