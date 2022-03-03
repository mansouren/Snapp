using Kavenegar;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Senders
{
   public static class SendSms
    {
        public static void VerifySend(string to, string template, string token)
        {
            var api = new KavenegarApi("");

            var strTo = to;
            var strTemplate = template;
            var strToken = token;

            api.VerifyLookup(strTo, strToken, strTemplate);
        }
    }
}
