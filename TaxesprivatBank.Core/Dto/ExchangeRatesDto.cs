using System.Collections.Generic;
using RestSharp.Deserializers;

namespace TaxesprivatBank.Core.Dto
{
    /// <summary>
    /// The exchange rate DTO.
    /// </summary>
    public class ExchangeRatesDto
    {
        /// <summary>
        /// Gets or sets the exchange rates.
        /// </summary>
        [DeserializeAs(Name = "exchangeRate")]
        public List<ExchangeRateDto> ExchangeRates { get; set; }
    }
}
