using DatabaseAccess.DataProviders;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OdrasliController : ControllerBase
    {
        [HttpGet("PrikaziOdrasle")]
        [ProducesResponseType(typeof(List<OdrasliDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PrikaziOdrasleAsync()
        {
            var rezultat = await OdrasliDataProvider.PrikaziOdrasleAsync();

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPost("SacuvajOdraslog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SacuvajOdraslogPolaznikaAsync([FromBody] OdrasliSaveDto model)
        {
            var rezultat = await OdrasliDataProvider.SacuvajOdraslogPolaznikaAsync(
              model
            );

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpDelete("ObrisiOdraslog/{polaznikId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObrisiOdraslogPolaznikaAsync(int polaznikId)
        {
            var rezultat = await OdrasliDataProvider.ObrisiOdraslogPolaznikaAsync(polaznikId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPut("IzmeniPodatkeOdraslogPolaznika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IzmeniPodatkeOdraslogPolaznikaAsync([FromBody] OdrasliUpdateDto model)
        {

            var rezultat = await OdrasliDataProvider.IzmeniOdraslogPolaznikaAsync(model);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }




    }
}
