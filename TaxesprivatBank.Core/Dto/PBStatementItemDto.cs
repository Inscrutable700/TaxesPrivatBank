﻿using System;
using System.Globalization;
using RestSharp.Deserializers;

namespace TaxesprivatBank.Core.Dto
{
    /// <summary>
    /// The statement item DTO.
    /// </summary>
    public class PBStatementItemDto
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        [DeserializeAs(Name = "@n")]
        public string N { get; set; }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        public InfoDto Info { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public AmountDto Amount { get; set; }

        /// <summary>
        /// Gets or sets the purpose.
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// Gets or sets the credit.
        /// </summary>
        public SomeDto Credit { get; set; }

        /// <summary>
        /// Gets or sets the debet.
        /// </summary>
        public SomeDto Debet { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        public double Course { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is taxed.
        /// </summary>
        public bool IsTaxed { get; set; }

        /// <summary>
        /// Gets or sets the amount in uah.
        /// </summary>
        public double AmountInUAH { get; set; }

        /// <summary>
        /// The info model DTO.
        /// </summary>
        public class InfoDto
        {
            /// <summary>
            /// Gets or sets the post date.
            /// </summary>
            public DateTime PostDate { get; set; }

            /// <summary>
            /// Gets or sets the short type.
            /// </summary>
            [DeserializeAs(Name = "@shorttype")]
            public string ShortType { get; set; }

            /// <summary>
            /// Gets or sets the post date formatted.
            /// </summary>
            [DeserializeAs(Name = "@postdate")]
            public string PostDateFormatted {
                get
                {
                    return this.PostDate.ToString("yyyyMMddTHH:mm:ss");
                }
                set
                {
                    this.PostDate = DateTime.ParseExact(value, "yyyyMMddTHH:mm:ss", CultureInfo.InvariantCulture);
                }
            }
        }

        /// <summary>
        /// The amount DTO.
        /// </summary>
        public class AmountDto
        {
            /// <summary>
            /// Gets or sets the amount.
            /// </summary>
            [DeserializeAs(Name = "@amt")]
            public double Amount { get; set; }

            /// <summary>
            /// Gets or sets the CCY.
            /// </summary>
            [DeserializeAs(Name = "@ccy")]
            public string CCY { get; set; }
        }

        /// <summary>
        /// The credit DTO.
        /// </summary>
        public class SomeDto
        {
            /// <summary>
            /// Gets or sets the account.
            /// </summary>
            public AccountDto Account { get; set; }
        }

        /// <summary>
        /// The account DTO.
        /// </summary>
        public class AccountDto
        {
            /// <summary>
            /// Gets or sets the number.
            /// </summary>
            [DeserializeAs(Name = "@number")]
            public string Number { get; set; }
        }
    }
}
