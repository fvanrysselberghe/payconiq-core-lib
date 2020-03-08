using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Payconiq;

namespace Payconiq
{

    public class Environment
    {
        /// <summary>
        /// A payconiq API environment like production or testing
        /// It is the main access point for the API.
        /// </summary>
        /// <param name="uri">URL that corresponds to the environment</param>
        /// <param name="client">Client used for the underlying connections</param>
        public Environment(Uri uri, HttpClient client)
        {
            _uri = uri;
            _client = client;

            _serializeOptions = SerializationStyle.GetJsonSerializationOptions();
        }

        private readonly Uri _uri;
        private readonly HttpClient _client;

        private readonly JsonSerializerOptions _serializeOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };

        public async Task<PaymentResponse> CreatePaymentAsync(
            PaymentRequest request,
            string key)
        {
            var httpResponse = await _client.SendAsync(asHttpRequest(request, key));
            return await asResponseAsync(httpResponse);
        }

        private HttpRequestMessage asHttpRequest(
            PaymentRequest request,
            string key)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, PaymentRequestUri);

            //create header
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", key);

            //create body
            var content = JsonSerializer.Serialize(request, _serializeOptions);
            httpRequest.Content = new StringContent(content);
            httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpRequest;
        }

        private Uri PaymentRequestUri
        {
            get
            {
                return new Uri(_uri, "v3/payments");
            }
        }

        private async Task<PaymentResponse> asResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return new PaymentResponse(); // #TODO throw exception instead

            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonSerializer.Deserialize<PaymentResponse>(content, _serializeOptions);
            }
            catch (JsonException exception)
            {
                System.Console.WriteLine(exception.Message);
                return new PaymentResponse();
            }
        }

        public async void GetQrAsync(Uri qrUri)
        {
            byte[] content = await _client.GetByteArrayAsync(qrUri);
        }
    }
}