using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Hyacinth.GrpcDemo.UserServer
{
    public class UserService : User.UserBase
    {
        public override Task<UserReply> FindUser(UserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserReply()
            {
                User = new UserReply.Types.UserModel()
                {
                    Id = request.Id,
                    Name = "Hyacinth" + new Random().Next(1, 1516) % 156,
                    Account = "99205814@qq.com",
                    Password = "123456"
                }
            });
        }
    }
}
