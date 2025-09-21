using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Collections.Generic;

public class SmsService
{
    private readonly string accountSid = "";
    private readonly string authToken = "";
    private static Dictionary<string, string> _codes = new Dictionary<string, string>();

    public SmsService()
    {
        TwilioClient.Init(accountSid, authToken);
    }

    public void SendSms(string to)
    {
        var code = new Random().Next(1000, 9999).ToString();
        _codes[to] = code;
        var messageOptions = new CreateMessageOptions(new PhoneNumber(to));
        messageOptions.MessagingServiceSid = "";
        messageOptions.Body = $"Seu código é {code}";
        var message = MessageResource.Create(messageOptions);
    }

    public bool ValidateCode(string to, string code)
    {
        return _codes.ContainsKey(to) && _codes[to] == code;
    }
}
