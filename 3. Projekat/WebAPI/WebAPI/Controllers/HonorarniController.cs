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
	public class HonorarniController : ControllerBase
	{
		[HttpGet("VratiSve")]
		[ProducesResponseType(typeof(List<HonorarniDTO>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> VratiSveHonorarneAsync()
		{
			var rezultat = await HonorarniDataProvider.VratiSveHonorarneAsync();
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}

		[HttpGet("Nadji/{id}")]
		[ProducesResponseType(typeof(HonorarniDTO), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> NadjiHonorarnogAsync(int id)
		{
			var rezultat = await HonorarniDataProvider.NadjiHonorarnogAsync(id);
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}

		[HttpPost("Dodaj")]
		[ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DodajHonorarnogAsync([FromBody] HonorarniDTO novi)
		{
			var rezultat = await HonorarniDataProvider.DodajHonorarnogAsync(novi);
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return CreatedAtAction(nameof(NadjiHonorarnogAsync), new { id = rezultat.Data }, null);
		}

		[HttpPut("Izmeni/{id}")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> IzmeniHonorarnogAsync(int id, [FromBody] HonorarniDTO podaci)
		{
			var rezultat = await HonorarniDataProvider.IzmeniHonorarnogAsync(id, podaci);
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}

		[HttpDelete("Obrisi/{id}")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)] 
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> ObrisiHonorarnogAsync(int id)
		{
			var rezultat = await HonorarniDataProvider.ObrisiHonorarnogAsync(id);
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}
	}
}