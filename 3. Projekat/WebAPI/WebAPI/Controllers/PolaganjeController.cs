using DatabaseAccess.DataProviders;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PolaganjeController : ControllerBase
    {
        [HttpGet("VratiPolaznikeKojiSuPolagaliIspit/{ispitId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> VratiPolaznikeKojiSuPolagaliIspitAsync(string ispitId)
        {

            var rezultat = await PolaganjeDataProvider.VratiPolaznikeKojiSuPolagaliIspitAsync(ispitId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPut("OceniPolaganje/{polaganjeId}/{ocena}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> OceniPolaganjePolaznikaAsync(int polaganjeId, int ocena)
        {
            bool polozio = ocena > 5;
            var rezultat = await PolaganjeDataProvider.OceniPolaganjePolaznikaAsync(polaganjeId, polozio, ocena);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPost("DodajPolaganje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DodajPolaganjeAsync([FromBody] DodajPolaganjeDTO dodajPolaganjeDto)
        {
            var rezultat = await PolaganjeDataProvider.DodajPolaganjeAsync(dodajPolaganjeDto.PolaznikIds, dodajPolaganjeDto.IspitId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpDelete("ObrisiPolaganje/{polaganjeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObrisiPolaganjeAsync(int polaganjeId)
        {

            var rezultat = await PolaganjeDataProvider.ObrisiPolaganjeAsync(polaganjeId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

    }
}
