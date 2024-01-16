using DataGraph.Core.Models.DataScheme.Requests;
using DataGraph.Core.Services.DataScheme;
using Microsoft.AspNetCore.Mvc;

namespace DataGraph.Web;

[Route("api/[controller]")]
public class DataSchemeController : ControllerBase
{
    [HttpPost("getScheme")]
    public async Task<IActionResult> GetDataSchemeAsync([FromBody] GetDataSchemeRequest request, [FromServices] IDataSchemaService dataSchemaService) 
        => Ok(await dataSchemaService.GetDataSchemeAsync(request.ConnectionString));
}
