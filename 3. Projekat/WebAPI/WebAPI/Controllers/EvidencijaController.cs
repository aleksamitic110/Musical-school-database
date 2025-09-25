using DatabaseAccess.DataProviders;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EvidencijaController : ControllerBase
	{
		[HttpGet("VratiSveEvidencije")]
		[ProducesResponseType(typeof(List<EvidencijaDTO>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> VratiSveEvidencijeAsync()
		{
			var rezultat = await EvidencijaDataProvider.VratiSveEvidencijeAsync();

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data);
		}

		[HttpGet("NadjiEvidenciju/{evidencijaId}")]
		[ProducesResponseType(typeof(EvidencijaDTO), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> NadjiEvidencijuAsync(int evidencijaId)
		{
			var rezultat = await EvidencijaDataProvider.NadjiEvidencijuAsync(evidencijaId);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data);
		}

		[HttpPost("DodajEvidenciju")]
		[ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DodajEvidencijuAsync([FromBody] EvidencijaDTO novaEvidencija)
		{
			var rezultat = await EvidencijaDataProvider.DodajEvidencijuAsync(novaEvidencija);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

            return Ok(rezultat.Data);
        }

		[HttpPut("IzmeniEvidenciju")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> IzmeniEvidencijuAsync([FromBody] EvidencijaDTO podaci)
		{
			var rezultat = await EvidencijaDataProvider.IzmeniEvidencijuAsync(podaci);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data);
		}

		[HttpDelete("ObrisiEvidenciju/{evidencijaId}")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> ObrisiEvidencijuAsync(int evidencijaId)
		{
			var rezultat = await EvidencijaDataProvider.ObrisiEvidencijuAsync(evidencijaId);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data);
		}
	}
}