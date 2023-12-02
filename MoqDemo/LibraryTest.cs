using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using ClassLibrary3;

namespace MoqDemo
{
    [TestFixture]
    public class LibraryTest
    {
        [Test]
        public void GetAllBooksForCategory_returns_list_of_available_books()
        {
            //1
            var bookServiceStub = new Mock<IBookService>();
            //2
            bookServiceStub
                .Setup(x => x.GetBooksForCategory("UnitTesting"))
                .Returns(new List<string>
                {
            "The Art of Unit Testing",
            "Test-Driven Development",
            "Working Effectively with Legacy Code"
                });
            //3
            var accountService = new AccountService(bookServiceStub.Object);
            IEnumerable<string> result = accountService.GetAllBooksForCategory("UnitTesting");
            ClassicAssert.AreEqual(3, result.Count());
        }


    }
    }
