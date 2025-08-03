using ETLProject.API.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EtlController : ControllerBase
{
    private readonly EtlService _etlService;
    private readonly IWebHostEnvironment _env;

    public EtlController(EtlService etlService, IWebHostEnvironment env)
    {
        _etlService = etlService;
        _env = env;
    }

    [HttpPost("upload")]
    public IActionResult UploadCsv([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file provided.");

        var uploadPath = Path.Combine(_env.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadPath);

        var filePath = Path.Combine(uploadPath, file.FileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(stream);

        var grades = _etlService.ExtractAndTransform(filePath);
        var result = _etlService.GetAverageByStudent(grades);

        var outputFilePath = Path.Combine(uploadPath, "transformed.csv");
        _etlService.ExportTransformedData(result, outputFilePath);

        return Ok(new
        {
            message = "ETL completed",
            download = $"{Request.Scheme}://{Request.Host}/uploads/transformed.csv"
        });
    }
}
