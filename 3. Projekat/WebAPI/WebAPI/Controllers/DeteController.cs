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
        [HttpGet("VratiDecuStaratelja/{starateljId}")]
        [ProducesResponseType(typeof(List<DeteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> VratiDecuStarateljaAsync(int starateljId)
        {
            var rezultat = await DeteDataProvider.VratiDecuStarateljaAsync(starateljId);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPost("SacuvajDete/{starateljId}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SacuvajDeteAsync(int starateljId, [FromBody] SacuvajDeteDTO sacuvajDeteDTO)
        {
            var rezultat = await DeteDataProvider.SacuvajDeteAsync(sacuvajDeteDTO.NovoDete, starateljId, sacuvajDeteDTO.NoviPolaznik, sacuvajDeteDTO.NovaOsoba);

            if (!rezultat.IsSuccess)
            {
                return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            }

            return Ok(rezultat.Data);
        }

        [HttpPut("IzmeniDete/{idDeteta}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IzmeniDeteAsync(int idDeteta, [FromBody] DeteUpdateRequest request)
        {
            request.Dete.IdDeteta = idDeteta;

            var rezultat = await DeteDataProvider.IzmeniDeteAsync(request.Dete, request.NoviPolaznik, request.NovaOsoba);

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
