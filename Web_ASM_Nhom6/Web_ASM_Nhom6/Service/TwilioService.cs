using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Web_ASM_Nhom6.Service
{
    public class TwilioService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromPhoneNumber;

        public TwilioService(IConfiguration configuration)
        {
            _accountSid = configuration["Authentication:Twilio:AccountSID"];
            _authToken = configuration["Authentication:Twilio:AuthToken"];
            _fromPhoneNumber = configuration["Authentication:Twilio:PhoneNumber"];
            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendSms(string toPhoneNumber, string message)
        {
            var messageOptions = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
            {
                From = new PhoneNumber(_fromPhoneNumber),
                Body = message
            };
            MessageResource.Create(messageOptions);
        }
    }
}
