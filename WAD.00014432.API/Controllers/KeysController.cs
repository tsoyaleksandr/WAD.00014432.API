using Microsoft.AspNetCore.Mvc;
using WAD._00014432.API.DAL.DTOs;
using WAD._00014432.API.DAL.Interfaces;
using WAD._00014432.API.DAL.Responses;

namespace WAD._00014432.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KeysController : ControllerBase
	{
		private readonly IKeyRepository _keyRepository;

		public KeysController(IKeyRepository keyRepository)
		{
			_keyRepository = keyRepository;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<KeyResponse>> Get(int id)
		{
			var key = await _keyRepository.GetByIdAsync(id);
			if (key == null)
			{
				return NotFound();
			}
			return Ok(key);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<KeyResponse>>> GetAll()
		{
			var keys = await _keyRepository.GetAllAsync();
			return Ok(keys);
		}

		[HttpPost]
		public async Task<IActionResult> Post(KeyDto key)
		{
			await _keyRepository.AddAsync(key);
			return CreatedAtAction(nameof(Get), new { id = key.Id }, key);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, KeyDto key)
		{
			if (id != key.Id)
			{
				return BadRequest();
			}
			await _keyRepository.UpdateAsync(key);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _keyRepository.DeleteAsync(id);
			return NoContent();
		}
	}
}
