using Microsoft.AspNetCore.Mvc;
using WAD._00014432.API.DAL.DTOs;
using WAD._00014432.API.DAL.Interfaces;
using WAD._00014432.API.DAL.Responses;

namespace WAD._00014432.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KeyStoreController : ControllerBase
	{
		private readonly IKeyStoreRepository _keyStoreRepository;

		public KeyStoreController(IKeyStoreRepository keyStoreRepository)
		{
			_keyStoreRepository = keyStoreRepository;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<KeyStoreReponse>> Get(int id)
		{
			var keyStore = await _keyStoreRepository.GetByIdAsync(id);
			if (keyStore == null)
			{
				return NotFound();
			}
			return Ok(keyStore);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<KeyStoreReponse>>> GetAll()
		{
			var keyStores = await _keyStoreRepository.GetAllAsync();
			return Ok(keyStores);
		}

		[HttpPost]
		public async Task<IActionResult> Post(KeyStoreDto keyStore)
		{
			await _keyStoreRepository.AddAsync(keyStore);
			return CreatedAtAction(nameof(Get), new { id = keyStore.Id }, keyStore);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, KeyStoreDto keyStore)
		{
			if (id != keyStore.Id)
			{
				return BadRequest();
			}
			await _keyStoreRepository.UpdateAsync(keyStore);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _keyStoreRepository.DeleteAsync(id);
			return NoContent();
		}
	}
}
