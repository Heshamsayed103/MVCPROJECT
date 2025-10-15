using Twilio;

namespace Company.G04.PL.Helper
{
    public class TwilioService(Microsoft.Extensions.Options.IOptions<TwilioSettings> _options) : ITwilioService
    {
        public MessageResource SendSms(Sms sms)
        {
         // Initialize Connetion
         TwilioClient.Init(_options.Value.AccountSID , _options.Value.AuthToken);



            // Build Message

            var message = MessageResource.Create(
                body:sms.Body,
                to : sms.To,
                from: _options.Value.PhoneNumber

            );


            // return Message

            return message;

        }
    }
}
