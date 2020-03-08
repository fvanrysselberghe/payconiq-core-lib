using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using Xunit;

namespace testing
{

    public class SerializationTest
    {
        // We rely on the serialization later on => ensure that it is in line with the examples
        [Fact]
        void TestPaymentResponseSerialization()
        {
            var response = ExampleInstances.GetPaymentResponse();
            string expected = "{\"paymentId\":\"5aa9a9700000000000000000\",\"status\":\"PENDING\",\"createdAt\":\"2018-09-18T11:43:29.160Z\",\"expiresAt\":\"2018-09-18T11:43:29.160Z\",\"description\":\"Sample description\",\"reference\":\"987456264\",\"amount\":112,\"currency\":\"EUR\",\"creditor\":{\"profileId\":\"5b71369f5832fd22658e0ef4\",\"merchantId\":\"5b71369f5832fd09188e0915\",\"name\":\"Merchant Name\",\"iban\":\"NL47FRBK0293409698\",\"callbackUrl\":\"https://www.testcallback.com/payconiq/payment\"},\"_links\":{\"self\":{\"href\":\"https://api.ext.payconiq.com/v3/payments/5bdb1685b93d1c000bde96f2\"},\"deeplink\":{\"href\":\"https://payconiq.com/pay/2/5bdb1685b93d1c000bde96f2\"},\"qrcode\":{\"href\":\"https://portal.ext.payconiq.com/qrcode?c=https%3A%2F%2Fpayconiq.com%2Fpay%2F2%2F5bdb1685b93d1c000bde96f2\"},\"cancel\":{\"href\":\"https://api.ext.payconiq.com/v3/payments/5bdb1685b93d1c000bde96f2\"}}}";

            Assert.Equal(expected, JsonSerializer.Serialize(response, Payconiq.SerializationStyle.GetJsonSerializationOptions()));
        }

        [Fact]
        void TestPaymentRequestSerialization()
        {
            var request = ExampleInstances.GetPaymentRequest();
            string expected = "{\"amount\":1,\"currency\":\"EUR\",\"callbackUrl\":\"https://dummy.network/api/v1/orders/payconiq\",\"description\":\"Test payment 12345\",\"reference\":\"12345\",\"bulkId\":\"Bulk-1-200\"}";

            Assert.Equal(expected, JsonSerializer.Serialize(request, Payconiq.SerializationStyle.GetJsonSerializationOptions()));
        }
    }
}