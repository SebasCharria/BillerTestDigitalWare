using AutoMapper;
using Billing.Invoices.Application.SearchAll;
using Billing.Invoices.Domain;
using Billing.Invoices.Domain.Exceptions;
using Billing.Invoices.Infrastructure.Mappings;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BillingTest.Invoices.Application.SearchAll
{
    public class InvoicesSearchAllShould
    {
        public readonly InvoicesSearchAllManager searchAllManager;
        private readonly Mapper mapper;
        public readonly Mock<IInvoiceRepository> repository;
        public InvoicesSearchAllShould()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>() { new InvoiceProfile() });
            });
            mapper = new Mapper(mapperConfiguration);

            repository = new Mock<IInvoiceRepository>();
            searchAllManager = new InvoicesSearchAllManager(repository.Object, mapper);
        }

        [Fact]
        public void valid_search_invoices()
        {
            repository
                .Setup(ri => ri.Search())
                .Returns(Enumerable.Empty<Invoice>())
                .Verifiable();

            var invoices = searchAllManager.Search();
            
            repository.Verify();
        }

        [Fact]
        public void valid_throw_not_found_invoice()
        {
            repository
                .Setup(ri => ri.Search())
                .Returns(It.IsAny<IEnumerable<Invoice>>());

            // act - val
            Assert.Throws<InvoiceNotFound>(searchAllManager.Search);
            
        }

    }
}
