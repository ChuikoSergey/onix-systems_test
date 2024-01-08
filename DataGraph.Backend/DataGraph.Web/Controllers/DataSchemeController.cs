using DataGraph.Core.Services.DataScheme;
using Microsoft.AspNetCore.Mvc;

namespace DataGraph.Web;

[Route("api/[controller]")]
public class DataSchemeController : ControllerBase
{
    [HttpGet]
    public IActionResult GetDataScheme([FromServices] IDataSchemaService dataSchemaService) 
        => Ok(dataSchemaService.GetDataScheme());
}
