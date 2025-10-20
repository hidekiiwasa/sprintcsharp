using Microsoft.AspNetCore.Mvc;
using BetHunterBusiness;
using BetHunterModel;   
using System.Threading.Tasks;
using BetHunterModel;
using BetHunterBusiness;

[ApiController]
[Route("api/[controller]")]
public class AIController : ControllerBase
{
    private readonly OpenAIService _openAIService;

    public AIController(OpenAIService openAIService)
    {
        _openAIService = openAIService;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> AskAI([FromBody] AiRequestText aiRequestText)
    {
        if (string.IsNullOrWhiteSpace(aiRequestText.Text))
            return BadRequest("Campo 'text' é obrigatório.");

        var result = await _openAIService.GetAnalysisOfTextAsync(aiRequestText.Text);
        return Ok(result);
    }
}
