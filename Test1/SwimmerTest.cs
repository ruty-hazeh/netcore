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
        [Fact]
        public void GetAll_ReturnsNotEmpty()
        {
            var controller = new SwimmerController();
            var result = controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);  
            var value = Assert.IsType<List<Swimmer>>(okResult.Value);
            Assert.NotEmpty(value);
        }



        [Fact]
        public void GetById_ReturnsNotFound()
        {
            int id = 1;
            var controller = new SwimmerController();
            var result = controller.Get(id);
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public void GetByActivityName_ReturnsNotFound()
        {
            string activityName = "beginnings";
            var controller = new SwimmerController();
            var result = controller.Get(activityName);
            Assert.IsType<NotFoundObjectResult>(result);
        }

    }

}
