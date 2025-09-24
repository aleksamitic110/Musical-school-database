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
	public class FilijalaController : ControllerBase
	{
		[HttpGet("VratiSveFilijale")]
		[ProducesResponseType(typeof(List<FilijalaDTO>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> VratiSveFilijaleAsync()
		{
			var rezultat = await FilijalaDataProvider.VratiSveFilijaleAsync();

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data);
		}

		[HttpGet("NadjiFilijalu/{filijalaId}")]
		[ProducesResponseType(typeof(FilijalaDTO), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> NadjiFilijaluAsync(string filijalaId)
		{
			var rezultat = await FilijalaDataProvider.NadjiFilijaluAsync(filijalaId);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data);
		}

		[HttpPost("DodajFilijalu")]
		[ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DodajFilijaluAsync([FromBody] FilijalaDTO novaFilijala)
		{
			var rezultat = await FilijalaDataProvider.DodajFilijaluAsync(novaFilijala);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return CreatedAtAction(nameof(NadjiFilijaluAsync), new { filijalaId = rezultat.Data }, null);
		}

		[HttpPut("IzmeniFilijalu")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> IzmeniFilijaluAsync([FromBody] FilijalaDTO podaci)
		{
			var rezultat = await FilijalaDataProvider.IzmeniFilijaluAsync(podaci);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data);
		}

		[HttpDelete("ObrisiFilijalu/{filijalaId}")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> ObrisiFilijaluAsync(string filijalaId)
		{
			var rezultat = await FilijalaDataProvider.ObrisiFilijaluAsync(filijalaId);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data);
		}
	}
}