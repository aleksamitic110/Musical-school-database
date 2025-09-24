using DatabaseAccess.DataProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PohadjaController : ControllerBase
    {
        [HttpPost("SacuvajPohadja")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SacuvajPohadjaAsync([FromQuery] int polaznikId, [FromQuery] int kursId)
        {
            var rezultat = await PohadjaDataProvider.SacuvajPohadjaAsync(polaznikId, kursId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpGet("NadjiPolaznikeKojiPohadjajuKurs/{kursId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> NadjiPolaznikeZaKursAsync(string kursId)
        {

            var rezultat = await PohadjaDataProvider.NadjiPolaznikeZaKursDTOAsync(kursId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpDelete("ObrisiPohadja/{pohadjaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObrisiPohadjaAsync(int pohadjaId)
        {

            var rezultat = await PohadjaDataProvider.ObrisiPohadjaAsync(pohadjaId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPut("IzmeniPohadja/{pohadjaId}/{noviPolaznikId}/{noviKursId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IzmeniPohadjaAsync(int pohadjaId, int noviPolaznikId, int noviKursId)
        {
            var rezultat = await PohadjaDataProvider.IzmeniPohadjaAsync(pohadjaId, noviPolaznikId, noviKursId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }




    }
}
