using DatabaseAccess.DataProviders;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeteController : ControllerBase
    {

        [HttpPost("SacuvajDete")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SacuvajDeteAsync([FromBody] DeteSaveDto sacuvajDeteDTO)
        {
            var rezultat = await DeteDataProvider.SacuvajDeteAsync(sacuvajDeteDTO);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPut("IzmeniDete")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IzmeniDeteAsync([FromBody] DeteUpdateDto izmeniDeteDTO)
        {

            var rezultat = await DeteDataProvider.IzmeniDeteAsync(izmeniDeteDTO);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpDelete("ObrisiDete/{idDeteta}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObrisiDeteAsync(int idDeteta)
        {
            var rezultat = await DeteDataProvider.ObrisiDeteAsync(idDeteta);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpGet("VratiDecu")]
        [ProducesResponseType(typeof(List<DeteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> VratiDecuAsync()
        {
            var rezultat = await DeteDataProvider.VratiDecuAsync();

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }




    }
}
