using Billing.Invoices.Application.Delete;
using Billing.Invoices.Domain;
using Billing.Invoices.Domain.Exceptions;
using BillingTest.Invoices.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BillingTest.Invoices.Application.Delete
{
    public class InvoicesDeleteShould
    {
        public readonly InvoicesDeleteManager deleteManager;
        public readonly Mock<IInvoiceRepository> repository;
        public InvoicesDeleteShould()
        {
            repository = new Mock<IInvoiceRepository>();
            deleteManager = new InvoicesDeleteManager(repository.Object);
        }

        [Fact]
        public void valid_delete_invoice()
        {
            // setp
            repository
                .Setup(ri => ri.GetById(It.IsAny<int>()))
                .Returns(InvoiceMother.StandardInvoice());

            // act
            deleteManager.Delete(1);

            // val
            repository.Verify(ri => ri.Delete(It.IsAny<Invoice>()));
            repository.Verify(ri => ri.GetById(It.IsAny<int>()));
        }
    
        [Fact]
        public void valid_throw_not_found_invoice()
        {
            // setp
            repository
                .Setup(ri => ri.GetById(It.IsAny<int>()))
                .Returns(It.IsAny<Invoice>());

            // act - val
            Assert.Throws<InvoiceNotFound>(() => deleteManager.Delete(1));

        }
    }
}
