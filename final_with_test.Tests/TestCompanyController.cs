using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using System.Net;
using System.Collections.Generic;
using final_with_test.Controllers;
using final_with_test.Models;

namespace final_with_test.Tests
{
    [TestClass]
    public class TestCompanyController
    {
        [TestMethod]
        public void PostProduct_ShouldReturnSameProduct()
        {
            var controller = new CompaniesController(new TestStoreAppContext());

            var item = GetDemoProduct();

            var result =
                controller.PostProduct(item) as CreatedAtRouteNegotiatedContentResult<Company>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Cemail);
            Assert.AreEqual(result.Content.Cemail, item.Cemail);
        }

        [TestMethod]
        public void PutProduct_ShouldReturnStatusCode()
        {
            var controller = new CompaniesController(new TestStoreAppContext());

            var item = GetDemoProduct();

            var result = controller.PutProduct(item.Cemail, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            var controller = new CompaniesController(new TestStoreAppContext());

            var badresult = controller.PutProduct("999", GetDemoProduct());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetProduct_ShouldReturnProductWithSameID()
        {
            var context = new TestStoreAppContext();
            context.Company.Add(GetDemoProduct());

            var controller = new CompaniesController(context);
            var result = controller.GetProduct("Mahmoud") as OkNegotiatedContentResult<Company>;

            Assert.IsNotNull(result);
            Assert.AreEqual("Mahmoud", result.Content.Cemail);
        }

        [TestMethod]
        public void GetProducts_ShouldReturnAllProducts()
        {
            var context = new TestStoreAppContext();
            List<CompanyInterests> companyInterests = new List<CompanyInterests>();
            companyInterests.Add(new CompanyInterests { Interest = "c++" });
           
            context.Company.Add(new Company()
            {
                Cemail = "Mahmoud",
                Cname = "MMM",
                Location = "Giza",
                NumberOfEmplyees = 200,
                Password = "1223",
                CompanyInterests = companyInterests
            });
            context.Company.Add(new Company()
            {
                Cemail = "Mahmoud",
                Cname = "MMM",
                Location = "Giza",
                NumberOfEmplyees = 200,
                Password = "1223",
                CompanyInterests = companyInterests
            });
            context.Company.Add(new Company()
            {
                Cemail = "Mahmoud",
                Cname = "MMM",
                Location = "Giza",
                NumberOfEmplyees = 200,
                Password = "1223",
                CompanyInterests = companyInterests
            });

            var controller = new CompaniesController(context);
            var result = controller.GetProducts() as TestCompanyDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteProduct_ShouldReturnOK()
        {
            var context = new TestStoreAppContext();
            var item = GetDemoProduct();
            context.Company.Add(item);

            var controller = new CompaniesController(context);
            var result = controller.DeleteProduct("Mahmoud") as OkNegotiatedContentResult<Company>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Cemail, result.Content.Cemail);
        }

        Company GetDemoProduct()
        {
            List<CompanyInterests> companyInterests = new List<CompanyInterests>();
            companyInterests.Add(new CompanyInterests { Interest = "c++" });
            return new Company() { Cemail = "Mahmoud" , Cname = "MMM" , Location = "Giza" ,
                                    NumberOfEmplyees = 200 , Password = "1223" ,
                                     CompanyInterests = companyInterests
            };
        }
    }
}
