using DatabaseAccess.DataProviders;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StalniController : ControllerBase
    {
        [HttpGet("PrikaziSveStalneNastavnike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PrikaziSveStalneNastavnikeAsync()
        {
            var rezultat = await StalniDataProvider.PrikaziSveStalneNastavnikeAsync();

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPost("SacuvajStalnog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SacuvajStalnogAsync([FromBody] SacuvajStalnogDTO sacuvajStalnogDTO)
        {
            var rezultat = await StalniDataProvider.SacuvajStalnogAsync(sacuvajStalnogDTO.NoviStalni, sacuvajStalnogDTO.MentorJMBG, sacuvajStalnogDTO.NovaOsoba, sacuvajStalnogDTO.NoviNastavnik);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPut("IzmeniStalnog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IzmeniStalnogAsync([FromBody] IzmeniStalnogDTO izmeniStalnogDTO)
        {
 

            var rezultat = await StalniDataProvider.IzmeniStalnogAsync(
                izmeniStalnogDTO.NoviStalni,
                izmeniStalnogDTO.StalniId,
                izmeniStalnogDTO.MentorJMBG,
                izmeniStalnogDTO.NovaOsoba,
                izmeniStalnogDTO.NoviNastavnik,
                izmeniStalnogDTO.NastavnikId
            );

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpGet("NadjiStalnog/{nastavnikId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> NadjiStalnogAsync(int nastavnikId)
        {
            var rezultat = await StalniDataProvider.NadjiStalnogAsync(nastavnikId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpDelete("ObrisiStalnog/{stalniId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObrisiStalnogAsync(int stalniId)
        {
            var rezultat = await StalniDataProvider.ObrisiStalnogAsync(stalniId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }


    }
}
