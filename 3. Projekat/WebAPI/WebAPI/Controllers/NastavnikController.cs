
using Microsoft.AspNetCore.Mvc;
using MuzickaSkola;
using NHibernate;
using Muzicka_skola;
using DatabaseAccess.DataProviders;
using DatabaseAccess.DTOs;
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

        [HttpPost("SacuvajNastavnika")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SacuvajNastavnika([FromBody] NastavnikBasic noviNastavnik, [FromQuery] string osobaJMBG)
        {

            var rezultat = await NastavnikDataProvider.SacuvajNastavnikaAsync(noviNastavnik, osobaJMBG);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(new { NastavnikId = rezultat.Data });
        }

        [HttpGet("NadjiNastavnika/{nId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> NadjiNastavnika(int nId)
        {
            var rezultat = await NastavnikDataProvider.NadjiNastavnikaAsync(nId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpDelete("ObrisiNastavnika/{nastavnikId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObrisiNastavnika(int nastavnikId)
        {
            var rezultat = await NastavnikDataProvider.ObrisiNastavnikaAsync(nastavnikId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(new { Success = rezultat.Data });
        }

        [HttpGet("PrikaziMentora/{nastavnikId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PrikaziMentora(int nastavnikId)
        {
            var rezultat = await NastavnikDataProvider.PrikaziMentoraAsync(nastavnikId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpGet("PrikaziKomeJeMentor/{jmbg}")]
        [ProducesResponseType(typeof(List<NastavnikDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PrikaziKomeJeMentorAsync(string jmbg)
        {
            var rezultat = await NastavnikDataProvider.PrikaziKomeJeMentorAsync(jmbg);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPut("IzmeniNastavnika/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IzmeniNastavnikaAsync(int id, [FromBody] NastavnikBasic noviNastavnik)
        {
            var rezultat = await NastavnikDataProvider.IzmeniNastavnikaAsync(noviNastavnik, id);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }


    }


}
