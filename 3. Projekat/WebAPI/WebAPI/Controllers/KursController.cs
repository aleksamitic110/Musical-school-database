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
	public class KursController : ControllerBase
	{
		[HttpGet("VratiSve")]
		[ProducesResponseType(typeof(List<KursDTO>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> VratiSveKurseveAsync()
		{
			var rezultat = await KursDataProvider.VratiSveKurseveAsync();
			if (!rezultat.IsSuccess) return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}

		[HttpGet("VratiPolaznike/{kursId}")]
		[ProducesResponseType(typeof(List<PolaznikDTO>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> VratiPolaznikeKursaAsync(string kursId)
		{
			var rezultat = await KursDataProvider.VratiPolaznikeKursaAsync(kursId);
			if (!rezultat.IsSuccess) return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}

		[HttpPost("Dodaj")]
		[ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DodajKursAsync([FromBody] KursDTO novi)
		{
			var rezultat = await KursDataProvider.DodajKursAsync(novi);
			if (!rezultat.IsSuccess) return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return StatusCode(201, rezultat.Data);
		}

		[HttpPut("Izmeni")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> IzmeniKursAsync([FromBody] KursDTO podaci)
		{
			var rezultat = await KursDataProvider.IzmeniKursAsync(podaci);
			if (!rezultat.IsSuccess) return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}

		[HttpDelete("Obrisi/{kursId}")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> ObrisiKursAsync(string kursId)
		{
			var rezultat = await KursDataProvider.ObrisiKursAsync(kursId);
			if (!rezultat.IsSuccess) return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}
	}
}