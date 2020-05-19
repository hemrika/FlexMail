using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlexMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexMail.Service;

namespace FlexMail.Tests
{
    [TestClass()]
    public class CategoryTests : FlexMailTest
    {
        [ClassInitialize]
        public static void CategoryTestsInitialize(TestContext testContext)
        {
        }

        [TestMethod()]
        public void Category_CategoriesTest()
        {
            List<CategoryType> categories = new FlexMail.Category().Categories();// Client.Category.Categories();

            foreach (CategoryType category in categories)
            {
                if (category.categoryName == "Kentico Demo")
                {
                    int categoryId = category.categoryId;
                }
            }

        }

        [TestMethod()]
        public void Category_CreateTest()
        {

        }

        [TestMethod()]
        public void Category_DeleteTest()
        {

        }

        [TestMethod()]
        public void Category_UpdateTest()
        {

        }

        [TestMethod()]
        public void Category_DisposeTest()
        {
            //Client.Category.Dispose();
        }
    }
}