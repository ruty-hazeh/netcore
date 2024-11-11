using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.classes_enums;
using Microsoft.AspNetCore.Mvc;
using poolProject;
using poolProject.Controllers;
namespace Test1
{
    public class SwimmerTest
    {
        private readonly SwimmerController _controller;
        public SwimmerTest()
        {
            FakeContext context=new FakeContext();  
            _controller = new SwimmerController(context);
        }

        [Fact]
        public void GetAll_ReturnsListOfSwimmers()
        {
            var result = _controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnsOk()
        {
            var id =2;

            var result = _controller.Get(id);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void GetById_Returns_NotFound()
        {
            var id = 1;

            var result = _controller.Get(id);

            Assert.IsType<NotFoundObjectResult>(result);

        }
    }
}
