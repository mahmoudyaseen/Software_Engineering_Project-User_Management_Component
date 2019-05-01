using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using final_with_test.Controllers;
using final_with_test.Models;
using System.Web.Http.Results;
using System.Net;
using System.Collections.Generic;

namespace final_with_test.Tests
{
    [TestClass]
    public class TestUserController
    {
        [TestMethod]
        public void PostProduct_ShouldReturnSameProduct()
        {
            var controller = new UsersController(new TestStoreAppContext());

            var item = GetDemoProduct();

            var result =
                controller.PostProduct(item) as CreatedAtRouteNegotiatedContentResult<Users>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Uemail);
            Assert.AreEqual(result.Content.Uemail, item.Uemail);
        }

        [TestMethod]
        public void PutProduct_ShouldReturnStatusCode()
        {
            var controller = new UsersController(new TestStoreAppContext());

            var item = GetDemoProduct();

            var result = controller.PutProduct(item.Uemail, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            var controller = new UsersController(new TestStoreAppContext());

            var badresult = controller.PutProduct("999", GetDemoProduct());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetProduct_ShouldReturnProductWithSameID()
        {
            var context = new TestStoreAppContext();
            context.Users.Add(GetDemoProduct());

            var controller = new UsersController(context);
            var result = controller.GetProduct("Mahmoud") as OkNegotiatedContentResult<Users>;

            Assert.IsNotNull(result);
            Assert.AreEqual("Mahmoud", result.Content.Uemail);
        }

        [TestMethod]
        public void GetProducts_ShouldReturnAllProducts()
        {
            var context = new TestStoreAppContext();
            List<UserInterests> usersInterests = new List<UserInterests>();
            usersInterests.Add(new UserInterests { Interest = "c++" });
           
            context.Users.Add(new Users()
            {
                Uemail = "Mahmoud",
                FirstName = "Mahmoud",
                LastName = "Yaseen",
                Password = "123",
                Age = 20,
                Gender = "male",
                Type = "Admin",
                UserInterests = usersInterests
            });
            context.Users.Add(new Users()
            {
                Uemail = "Mahmoud",
                FirstName = "Mahmoud",
                LastName = "Yaseen",
                Password = "123",
                Age = 20,
                Gender = "male",
                Type = "Admin",
                UserInterests = usersInterests
            });
            context.Users.Add(new Users()
            {
                Uemail = "Mahmoud",
                FirstName = "Mahmoud",
                LastName = "Yaseen",
                Password = "123",
                Age = 20,
                Gender = "male",
                Type = "Admin",
                UserInterests = usersInterests
            });

            var controller = new UsersController(context);
            var result = controller.GetProducts() as TestUserDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteProduct_ShouldReturnOK()
        {
            var context = new TestStoreAppContext();
            var item = GetDemoProduct();
            context.Users.Add(item);

            var controller = new UsersController(context);
            var result = controller.DeleteProduct("Mahmoud") as OkNegotiatedContentResult<Users>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Uemail, result.Content.Uemail);
        }

        Users GetDemoProduct()
        {
            List<UserInterests> usersInterests = new List<UserInterests>();
            usersInterests.Add(new UserInterests { Interest = "c++" });
            return new Users() { Uemail = "Mahmoud" , FirstName = "Mahmoud" , LastName = "Yaseen" ,
                                Password = "123" , Age = 20 , Gender = "male" , Type = "Admin" ,
                                UserInterests = usersInterests};
        }
    }
}
