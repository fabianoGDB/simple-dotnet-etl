using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PowerBiController : ControllerBase
{
    [HttpGet("embed")]
    public IActionResult GetEmbed()
    {
        var embedUrl = "https://app.powerbi.com/reportEmbed?reportId=YOUR_REPORT_ID&groupId=YOUR_GROUP_ID&autoAuth=true&ctid=YOUR_TENANT_ID";

        var iframe = $@"<iframe width='100%' height='600px' 
            src='{embedUrl}' 
            frameborder='0' allowFullScreen='true'></iframe>";

        return Content(iframe, "text/html");
    }
}
