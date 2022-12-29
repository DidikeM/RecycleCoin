using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoReplyService;
namespace RecycleCoin.API.Concrete;

    public class AutoReplyServices
    {
        public static async Task<string> ReplyQuestion(string question,string userApi)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:7337");

            var client = new QuestionReplyer.QuestionReplyerClient(channel);

            var response = await client.replyQuestionAsync(new Question
            {
                QuestionMessage = question,
                UserApiKey = userApi
            });
            return response.ReplyMessage;
        }
    }
