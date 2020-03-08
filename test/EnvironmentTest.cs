using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace testing
{
    public class ClientTest
    {

        // #TODO split into call and response processing
        [Fact]
        public void ValidRequestYieldsCorrectHttpMethod()
        {
            var mockResponse = new HttpResponseMessage() { StatusCode = HttpStatusCode.Created, Content = new StringContent(ExampleInstances.GetPaymentResponseJson()) };
            var mockHandler = new HttpMessageHandlerMock(mockResponse);
            var mockClient = new HttpClient(mockHandler);

            var testedEnvironment = new Payconiq.Environment(new System.Uri("https://api.ext.payconiq.com"), mockClient);

            var payment = ExampleInstances.GetPaymentRequest();

            var result = testedEnvironment.CreatePaymentAsync(payment, "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").GetAwaiter().GetResult();

            Assert.Equal(HttpMethod.Post, mockHandler.Request.Method);
        }

        [Fact]
        public void ValidRequestSendsRequiredCredentials()
        {
            var mockResponse = new HttpResponseMessage() { StatusCode = HttpStatusCode.Created, Content = new StringContent(ExampleInstances.GetPaymentResponseJson()) };
            var mockHandler = new HttpMessageHandlerMock(mockResponse);
            var mockClient = new HttpClient(mockHandler);

            var testedEnvironment = new Payconiq.Environment(new System.Uri("https://api.ext.payconiq.com"), mockClient);

            var payment = ExampleInstances.GetPaymentRequest();

            var result = testedEnvironment.CreatePaymentAsync(payment, "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").GetAwaiter().GetResult();

            Assert.Equal(new AuthenticationHeaderValue("Bearer", "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"), mockHandler.Request.Headers.Authorization);
        }

        [Fact]
        public void ValidRequestSendsRequiredContentType()
        {
            var mockResponse = new HttpResponseMessage() { StatusCode = HttpStatusCode.Created, Content = new StringContent(ExampleInstances.GetPaymentResponseJson()) };
            var mockHandler = new HttpMessageHandlerMock(mockResponse);
            var mockClient = new HttpClient(mockHandler);

            var testedEnvironment = new Payconiq.Environment(new System.Uri("https://api.ext.payconiq.com"), mockClient);

            var payment = ExampleInstances.GetPaymentRequest();

            var result = testedEnvironment.CreatePaymentAsync(payment, "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").GetAwaiter().GetResult();
            Assert.Equal(new MediaTypeHeaderValue("application/json"), mockHandler.Request.Content.Headers.ContentType);
        }

        [Fact]
        public void ValidRequestSendsCorrectContent()
        {
            var mockResponse = new HttpResponseMessage() { StatusCode = HttpStatusCode.Created, Content = new StringContent(ExampleInstances.GetPaymentResponseJson()) };
            var mockHandler = new HttpMessageHandlerMock(mockResponse);
            var mockClient = new HttpClient(mockHandler);

            var testedEnvironment = new Payconiq.Environment(new System.Uri("https://api.ext.payconiq.com"), mockClient);

            var payment = ExampleInstances.GetPaymentRequest();

            var result = testedEnvironment.CreatePaymentAsync(payment, "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").GetAwaiter().GetResult();
            Assert.Equal(ExampleInstances.GetPaymentRequestJson(), mockHandler.Request.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        }

    }
}