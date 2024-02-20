using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WAD._00014432.API.DAL.Data;
using WAD._00014432.API.DAL.DTOs;
using WAD._00014432.API.DAL.Interfaces;
using WAD._00014432.API.DAL.Models;
using WAD._00014432.API.DAL.Responses;

namespace WAD._00014432.API.DAL.Repositories
{
	public class KeyRepository : IKeyRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public KeyRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<KeyResponse> GetByIdAsync(int id)
		{
			var result = await _context.Keys.FindAsync(id);

			return _mapper.Map<KeyResponse>(result);
		}

		public async Task<IEnumerable<KeyResponse>> GetAllAsync()
		{
			var result = await _context.Keys.ToListAsync();

			return _mapper.Map<IEnumerable<KeyResponse>>(result);
		}

		public async Task AddAsync(KeyDto key)
		{
			var result = _mapper.Map<Key>(key);

			result.CreatedAt = DateTime.UtcNow;
			result.UpdatedAt = DateTime.UtcNow;
			await _context.Keys.AddAsync(result);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(KeyDto key)
		{
			var result = _mapper.Map<Key>(key);

			result.UpdatedAt = DateTime.UtcNow;
			_context.Keys.Update(result);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var result = await _context.Keys.FindAsync(id);

			if (result != null)
			{
				_context.Keys.Remove(result);
				await _context.SaveChangesAsync();
			}
		}
	}
}
