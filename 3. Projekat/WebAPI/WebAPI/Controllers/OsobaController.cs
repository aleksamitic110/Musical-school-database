using DatabaseAccess.DataProviders;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OsobaController : ControllerBase
    {
        [HttpPost("SacuvajOsobu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SacuvajOsobuAsync([FromBody] OsobaBasic novaOsoba)
        {
            var rezultat = await OsobaDataProvider.SacuvajOsobuAsync(novaOsoba);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data); 
        }

        [HttpDelete("ObrisiOsobu/{jmbg}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObrisiOsobuAsync([FromRoute] string jmbg)
        {
            var rezultat = await OsobaDataProvider.ObrisiOsobuAsync(jmbg);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpGet("PrikaziSveOsobe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PrikaziSveOsobeAsync()
        {
            var rezultat = await OsobaDataProvider.PrikaziSveOsobeAsync();

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data); 
        }

        [HttpPut("IzmeniOsobu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IzmeniOsobuAsync([FromBody] OsobaBasic novaOsoba)
        {

            var rezultat = await OsobaDataProvider.IzmeniOsobuAsync(novaOsoba);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }


    }
}
