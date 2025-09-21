using Microsoft.AspNetCore.Mvc;
using BetHunterBusiness;
using Org.BouncyCastle.Asn1.Ocsp;
using BetHunterModel;

[ApiController]
[Route("api/[controller]")]
public class SmsController : ControllerBase
{
    private readonly SmsService _smsService;

    public SmsController(SmsService smsService)
    {
        _smsService = smsService;
    }

    [HttpPost("send")]
    public IActionResult SendSms([FromBody] SmsRequest request)
    {
        _smsService.SendSms(request.To);
        return Ok("SMS enviado");
    }

    [HttpPost("confirm")]
    public IActionResult ConfirmSms([FromBody] ConfirmRequest request)
    {
        bool confirmed = _smsService.ValidateCode(request.To, request.Code);
        return confirmed ? Ok("Código confirmado") : BadRequest("Código inválido");
    }
}
