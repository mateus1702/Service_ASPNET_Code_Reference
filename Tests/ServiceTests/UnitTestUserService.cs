using System;
using System.Linq;
using DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceModel.DTO;
using ServiceModel.Services;

namespace Tests
{
    [TestClass]
    public class UnitTestUserService
    {
        private static Random RandomGenerator = new Random();

        [TestMethod]
        public void CreateUser()
        {
            UserService service = new UserService();

            var userDTO = new UserDTO(
                new User()
                {
                    Name = "User Name",                   
                });

            var Id = service.CreateUser(userDTO);

            Assert.IsTrue(Id > 0);
        }

        [TestMethod]
        public void ReadUser()
        {
            UserService service = new UserService();

            var modelId = service.ListUsers().First().Id;

            var readModel = service.ReadUser(modelId);

            Assert.IsTrue(readModel != null);
        }

        [TestMethod]
        public void UpdateUser()
        {
            UserService service = new UserService();

            var modelId = service.ListUsers().First().Id;

            var oldModel = service.ReadUser(modelId);

            var randomNumber = RandomGenerator.Next(99);
            oldModel.Name = randomNumber.ToString();

            service.UpdateUser(oldModel);

            var changedModel = service.ReadUser(modelId);


            Assert.IsTrue(changedModel.Name == oldModel.Name);
        }

        [TestMethod]
        public void DeleteUser()
        {
            UserService service = new UserService();

            var modelId = service.ListUsers().First().Id;

            service.DeleteUser(modelId);

            var deletedModel = service.ReadUser(modelId);

            Assert.IsTrue(deletedModel == null);
        }

        [TestMethod]
        public void CreateTask()
        {
            UserService userService = new UserService();
            var userId = userService.ListUsers().First().Id;

            TaskService taskService = new TaskService();

            var taskDTO = new TaskDTO(
                new Task()
                {
                    Name = "Task Name",
                    Date = DateTime.Now,
                    Done = true,
                    UserId = userId,                    
                });

            var Id = taskService.CreateTask(taskDTO);

            Assert.IsTrue(Id > 0);
        }

        [TestMethod]
        public void ReadTask()
        {
            UserService userService = new UserService();
            var userId = userService.ListUsers().First().Id;

            TaskService taskService = new TaskService();
            var taskId = taskService.ListTasks(userId).First().Id;

            var readModel = taskService.ReadTask(taskId);

            Assert.IsTrue(readModel != null);
        }

        [TestMethod]
        public void UpdateTask()
        {
            UserService userService = new UserService();
            var userId = userService.ListUsers().First().Id;

            TaskService taskService = new TaskService();
            var taskId = taskService.ListTasks(userId).First().Id;

            var oldModel = taskService.ReadTask(taskId);

            var randomNumber = RandomGenerator.Next(99);
            oldModel.Name = randomNumber.ToString();

            taskService.UpdateTask(oldModel);

            var changedModel = taskService.ReadTask(taskId);

            Assert.IsTrue(changedModel.Name == oldModel.Name);
        }

        [TestMethod]
        public void DeleteTask()
        {
            UserService userService = new UserService();
            var userId = userService.ListUsers().First().Id;

            TaskService taskService = new TaskService();
            var taskId = taskService.ListTasks(userId).First().Id;

            taskService.DeleteTask(taskId);

            var deletedModel = taskService.ReadTask(taskId);

            Assert.IsTrue(deletedModel == null);
        }
    }
}
