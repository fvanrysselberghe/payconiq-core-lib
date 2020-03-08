using System;

namespace Payconiq
{
    public class PaymentRequest
    {
        public PaymentRequest(uint amount) => Amount = amount;
        /// <summary>
        /// Payment amount in euro cents
        /// </summary>
        /// <value></value>
        public uint Amount { get; set; }

        /// <summary>
        /// Payment currency code in ISO 4217 format
        /// Only Euros supported at the moment
        /// </summary>
        public string Currency { get; set; } = "EUR";

        /// <summary>
        /// A url which the Merchant or Partner will be notified
        /// of a payment. Must be Https for production.
        /// </summary>
        /// <value></value>
        public Uri CallbackUrl { get; set; }

        public string Description { get; set; }

        public string Reference { get; set; }

        public string BulkId { get; set; }
    }
}