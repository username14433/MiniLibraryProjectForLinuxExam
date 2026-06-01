using Microsoft.AspNetCore.Mvc;

namespace LinuxAdminExamApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "Healthy",
            service = "LinuxAdminExamApi",
            port = 5000,
            checkedAt = DateTime.UtcNow
        });
    }
}
