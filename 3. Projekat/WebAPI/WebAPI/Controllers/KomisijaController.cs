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
	public class KomisijaController : ControllerBase
	{
		[HttpGet("VratiSve")]
		[ProducesResponseType(typeof(List<KomisijaDTO>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> VratiSveKomisijeAsync()
		{
			var rezultat = await KomisijaDataProvider.VratiSveKomisijeAsync();
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}

		[HttpGet("VratiNastavnikeZaIspit/{ispitId}")]
		[ProducesResponseType(typeof(List<NastavnikDTO>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> VratiKomisijuZaIspitAsync(string ispitId)
		{
			var rezultat = await KomisijaDataProvider.VratiKomisijuZaIspitAsync(ispitId);
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}

		[HttpPost("DodajClana")]
		[ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DodajClanaKomisijeAsync([FromBody] KomisijaDTO novaVeza)
		{
		
			var rezultat = await KomisijaDataProvider.DodajClanaKomisijeAsync(novaVeza);
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return StatusCode(201, rezultat.Data); 
		}

		[HttpDelete("ObrisiClana/{komisijaId}")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> ObrisiClanaKomisijeAsync(int komisijaId)
		{
			var rezultat = await KomisijaDataProvider.ObrisiClanaKomisijeAsync(komisijaId);
			if (!rezultat.IsSuccess)
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			return Ok(rezultat.Data);
		}
	}
}