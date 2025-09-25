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
	public class IspitController : ControllerBase
	{
		[HttpGet("VratiSve")]
		[ProducesResponseType(typeof(List<IspitDTO>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> VratiSveIspiteAsync()
		{
			var rezultat = await IspitDataProvider.VratiSveIspiteAsync();
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}

		[HttpPost("Dodaj")]
		[ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DodajIspitAsync([FromBody] IspitSaveDto novi)
		{
			var rezultat = await IspitDataProvider.SacuvajIspitAsync(novi);
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
            return Ok(rezultat.Data);
        }

		[HttpPut("Izmeni")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> IzmeniIspitAsync([FromBody] IspitUpdateDto podaci)
		{
			var rezultat = await IspitDataProvider.IzmeniIspitAsync(podaci);
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}

		[HttpDelete("Obrisi/{ispitId}")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> ObrisiIspitAsync(string ispitId)
		{
			var rezultat = await IspitDataProvider.ObrisiIspitAsync(ispitId);
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}
	}
}