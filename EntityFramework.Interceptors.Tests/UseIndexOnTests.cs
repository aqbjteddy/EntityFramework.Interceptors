using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Interceptors.Tests
{
    [TestClass]
    public class UseIndexOnTests
    {
        [TestMethod]
        public void ShouldHitUseIndexOn()
        {
            var context = new TestDbContext();
            var products = context.UseIndex<Product>("IX_RegionCode").ToList();
        }
    }
}
