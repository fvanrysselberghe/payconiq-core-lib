using System.Text.Json;
using Payconiq;

namespace testing
{
    /// <summary>
    /// Instances that correspond to the examples on the payconiq developer website
    /// </summary>
    public class ExampleInstances
    {
        /// <summary>
        /// Example response for the Create Payment
        /// see https://developer.payconiq.com/online-payments-dock/#create-payment78 (8 March 2020)
        /// </summary>
        /// <returns>PaymentResponse</returns>
        public static PaymentResponse GetPaymentResponse()
        {
            return new Payconiq.PaymentResponse()
            {
                PaymentId = "5aa9a9700000000000000000",
                Status = Payconiq.PaymentStatus.PENDING,
                CreatedAt = "2018-09-18T11:43:29.160Z",
                ExpiresAt = "2018-09-18T11:43:29.160Z",
                Description = "Sample description",
                Reference = "987456264",
                Amount = 112,
                Currency = "EUR",
                Creditor = new Payconiq.Creditor() { ProfileId = "5b71369f5832fd22658e0ef4", MerchantId = "5b71369f5832fd09188e0915", Name = "Merchant Name", Iban = "NL47FRBK0293409698", CallbackUrl = "https://www.testcallback.com/payconiq/payment" },
                Links = new Payconiq.Links()
                {
                    Self = new Payconiq.Hypermedia() { Href = new System.Uri("https://api.ext.payconiq.com/v3/payments/5bdb1685b93d1c000bde96f2") },
                    Deeplink = new Payconiq.Hypermedia() { Href = new System.Uri("https://payconiq.com/pay/2/5bdb1685b93d1c000bde96f2") },
                    Qrcode = new Payconiq.Hypermedia() { Href = new System.Uri("https://portal.ext.payconiq.com/qrcode?c=https%3A%2F%2Fpayconiq.com%2Fpay%2F2%2F5bdb1685b93d1c000bde96f2") },
                    Cancel = new Payconiq.Hypermedia() { Href = new System.Uri("https://api.ext.payconiq.com/v3/payments/5bdb1685b93d1c000bde96f2") }
                }
            };
        }

        /// <summary>
        /// Returns the JSON representation of GetPaymentResponse
        /// </summary>
        /// <returns></returns>
        public static string GetPaymentResponseJson()
        {
            return JsonSerializer.Serialize(GetPaymentResponse(), Payconiq.SerializationStyle.GetJsonSerializationOptions());
        }

        /// <summary>
        /// Example request for the Create Payment
        /// see https://developer.payconiq.com/online-payments-dock/#create-payment78 (8 March 2020)
        /// </summary>
        /// <returns>PaymentRequest</returns>

        public static Payconiq.PaymentRequest GetPaymentRequest()
        {
            return new Payconiq.PaymentRequest(1)
            {
                CallbackUrl = new System.Uri("https://dummy.network/api/v1/orders/payconiq"),
                Description = "Test payment 12345",
                Reference = "12345",
                BulkId = "Bulk-1-200"
            };
        }

        public static string GetPaymentRequestJson()
        {
            return JsonSerializer.Serialize(GetPaymentRequest(), Payconiq.SerializationStyle.GetJsonSerializationOptions());
        }

    }
}