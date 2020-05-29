using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panda.Domain;
using PandaApp.Data;
using PandaApp.Models.Receipt;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PandaApp.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly PandaDbContext context;

        public ReceiptsController(PandaDbContext context)
        {
            this.context = context;
        }

        public IActionResult My()
        {
            List<ReceiptMyViewModel> myReceipts = this.context.Receipts
                .Include(receipt => receipt.Recipient)
                .Where(receipt => receipt.Recipient.UserName == this.User.Identity.Name)
                .Select(receipt => new ReceiptMyViewModel
                {
                    Id = receipt.Id,
                    Fee = receipt.Fee,
                    IssuedOn = receipt.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Recipient = receipt.Recipient.UserName
                })
                .ToList();

            return View(myReceipts);
        }

        [HttpGet("/Receipts/Details/{id}")]
        public IActionResult Details(string id)
        {
            Receipt receiptFromDb = this.context.Receipts
                .Where(receipt => receipt.Id == id)
                .Include(receipt => receipt.Package)
                .Include(receipt => receipt.Recipient)
                .SingleOrDefault();

            ReceiptDetailsViewModel viewModel = new ReceiptDetailsViewModel
            {
                Id = receiptFromDb.Id,
                Total = receiptFromDb.Fee,
                Recipient = receiptFromDb.Recipient.UserName,
                DeliveryAddress = receiptFromDb.Package.ShippingAddress,
                PackageWeight = receiptFromDb.Package.Weight,
                PackageDescription = receiptFromDb.Package.Description,
                IssuedOn = receiptFromDb.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            };

            return this.View(viewModel);
        }

    }
}