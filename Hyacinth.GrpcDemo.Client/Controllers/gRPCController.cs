using Hyacinth.GrpcDemo.LessonServer;
using Hyacinth.GrpcDemo.UserServer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hyacinth.GrpcDemo.Client.Controllers
{
    public class gRPCController : Controller
    {
        private readonly User.UserClient _userClient;
        private readonly Lesson.LessonClient _lessonClient;

        public gRPCController(User.UserClient userClient, Lesson.LessonClient lessonClient)
        {
            _userClient = userClient;
            _lessonClient = lessonClient;
        }

        public async Task<IActionResult> Index()
        {
            {
                var reply = await this._lessonClient.FindLessonAsync(new LessonRequest() { Id = 123 });
                Console.WriteLine($"_lessonClient {Thread.CurrentThread.ManagedThreadId} 服务返回数据1： {Newtonsoft.Json.JsonConvert.SerializeObject(reply.Lesson)}");
            }

            {
                var reply = await this._userClient.FindUserAsync(new UserRequest() { Id = 123 });
                Console.WriteLine($"_userClient {Thread.CurrentThread.ManagedThreadId} 服务返回数据2： {Newtonsoft.Json.JsonConvert.SerializeObject(reply.User)}");
                base.ViewBag.Luck = reply.User.Name;
            }

            {
                var reply = this._lessonClient.FindLesson(new LessonRequest() { Id = 123 });
                Console.WriteLine($"_lessonClient {Thread.CurrentThread.ManagedThreadId} 同步调用数据3： {Newtonsoft.Json.JsonConvert.SerializeObject(reply.Lesson)}");
            }

            return View();
        }
    }
}
