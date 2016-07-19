﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaxesPrivatBank.Business;
using TaxesPrivatBank.Business.Interfaces;
using TaxesPrivatBank.Helpers;
using TaxesPrivatBank.ViewModels;

namespace TaxesPrivatBank.Controllers
{
    /// <summary>
    /// The taxes controller.
    /// </summary>
    public class TaxesController : Controller
    {
        /// <summary>
        /// The privat bank manager.
        /// </summary>
        private IPrivatBankManager privatBankManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxesController"/> class.
        /// </summary>
        public TaxesController()
        {
            this.privatBankManager = new PrivatBankManager();
        }

        /// <summary>
        /// The generate taxes page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            TaxesViewModel model = new TaxesViewModel();

            string sessionID = CookieHelper.PBSessionID;
            var taxes = this.privatBankManager
                .GetTaxes(sessionID, DateTime.Parse("04.01.2016"), DateTime.Parse("06.30.2016"), 5);

            model.FullAmount = taxes.FullAmount;
            model.StartDate = taxes.StartDate;
            model.EndDate = taxes.EndDate;
            model.TaxesAmount = taxes.TaxesAmount;
            model.InterestRate = taxes.InterestRate;

            List<TaxesViewModel.Statement> credits = new List<TaxesViewModel.Statement>();
            foreach (var statement in taxes.Statements)
            {
                credits.Add(new TaxesViewModel.Statement()
                {
                    Amount = statement.Amount.Amount,
                    Description = statement.Purpose,
                    IsTaxed = statement.IsTaxed,
                    CCY = statement.Amount.CCY,
                    Date = statement.Info.PostDate,
                    CurrencyExchange = statement.Course,
                    AmountInUAH = statement.AmountInUAH,
                });
            }

            model.Statements = credits.ToArray();

            return View(model);
        }
    }
}