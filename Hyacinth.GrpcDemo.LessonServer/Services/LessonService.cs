using Grpc.Core;
using System.Threading.Tasks;

namespace Hyacinth.GrpcDemo.LessonServer
{
    public class LessonService : Lesson.LessonBase
    {
        public override Task<LessonReply> FindLesson(LessonRequest request, ServerCallContext context)
        {
            return Task.FromResult(new LessonReply()
            {
                Lesson = new LessonReply.Types.LessonModel()
                {
                    Id = request.Id,
                    Name = "�������",
                    Remark = "�ú�ѧϰ����������",
                }
            });
        }
    }
}
