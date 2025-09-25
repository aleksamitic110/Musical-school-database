using Microsoft.AspNetCore.Mvc;
using MuzickaSkola;
using Muzicka_skola;
using NHibernate;
using DatabaseAccess.DataProviders;
using DatabaseAccess.DTOs;

namespace WebAPI.Controllers
    {
        [ApiController]
        [Route("[controller]")]
    
        public class PolaznikController : ControllerBase
        {

        [HttpGet("VratiPolaznike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> VratiPolaznikeAsync()
        {
            var rezultat = await PolaznikDataProvider.VratiSvePolaznikeAsync();

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpDelete("ObrisiPolaznika/{polaznikId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObrisiPolaznikaAsync(int polaznikId)
        {


            var rezultat = await PolaznikDataProvider.ObrisiPolaznikaAsync(polaznikId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPut("IzmeniPolaznika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IzmeniPolaznikaAsync([FromBody] PolaznikUpdateDto polaznikUpdateDto)
        {

            var rezultat = await PolaznikDataProvider.IzmeniPolaznikaAsync(polaznikUpdateDto);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPost("DodajPolaznika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DodajPolaznikaAsync([FromBody] PolaznikSaveDto polaznikSaveDto)
        {

            var rezultat = await PolaznikDataProvider.SacuvajPolaznikaAsync(polaznikSaveDto);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

    }
}

