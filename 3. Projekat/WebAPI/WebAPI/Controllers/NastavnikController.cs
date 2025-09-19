
using Microsoft.AspNetCore.Mvc;
using MuzickaSkola;
using NHibernate;
using Muzicka_skola;
using DatabaseAccess.DataProviders;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NastavnikController:ControllerBase
    {

        [HttpGet("PrikaziSveNastavnike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSviNastavnici()
        {
            var result = await NastavnikDataProvider.PrikaziSveNastavnike();

            if (result.IsError)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Data);
        }

    }


}
