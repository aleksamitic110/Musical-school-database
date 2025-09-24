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
	public class CasController : ControllerBase
	{
		[HttpGet("VratiSveCasove")]
		[ProducesResponseType(typeof(List<CasDTO>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> VratiSveCasoveAsync()
		{
			var rezultat = await CasDataProvider.VratiSveCasoveAsync();

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data);
		}

		[HttpGet("NadjiCas/{casId}")]
		[ProducesResponseType(typeof(CasDTO), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> NadjiCasAsync(string casId)
		{
			var rezultat = await CasDataProvider.NadjiCasAsync(casId);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data);
		}

		[HttpPost("DodajCas")]
		[ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DodajCasAsync([FromBody] CasDTO noviCas)
		{
			var rezultat = await CasDataProvider.DodajCasAsync(noviCas);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}


			return CreatedAtAction(nameof(NadjiCasAsync), new { casId = rezultat.Data }, null);
		}

		[HttpPut("IzmeniCas")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> IzmeniCasAsync([FromBody] CasDTO podaci)
		{
			var rezultat = await CasDataProvider.IzmeniCasAsync(podaci);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data); 
		}

		[HttpDelete("ObrisiCas/{casId}")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> ObrisiCasAsync(string casId)
		{
			var rezultat = await CasDataProvider.ObrisiCasAsync(casId);

			if (!rezultat.IsSuccess)
			{
				return StatusCode(rezultat.Error.StatusCode, rezultat.Error.Message);
			}

			return Ok(rezultat.Data); 
		}
	}
}