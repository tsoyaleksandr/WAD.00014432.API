using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WAD._00014432.API.DAL.Data;
using WAD._00014432.API.DAL.DTOs;
using WAD._00014432.API.DAL.Interfaces;
using WAD._00014432.API.DAL.Models;
using WAD._00014432.API.DAL.Responses;

namespace WAD._00014432.API.DAL.Repositories
{
	public class KeyStoreRepository : IKeyStoreRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public KeyStoreRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<KeyStoreReponse> GetByIdAsync(int id)
		{
			var result = await _context.KeyStores.FindAsync(id);

			return _mapper.Map<KeyStoreReponse>(result);
		}

		public async Task<IEnumerable<KeyStoreReponse>> GetAllAsync()
		{
			var result = await _context.KeyStores
				.Include(ks => ks.Keys)
				.ToListAsync();

			return _mapper.Map<ICollection<KeyStoreReponse>>(result.ToList());
		}

		public async Task AddAsync(KeyStoreDto keyStore)
		{
			var result = _mapper.Map<KeyStore>(keyStore);

			result.CreatedAt = DateTime.UtcNow;
			result.UpdatedAt = DateTime.UtcNow;

			await _context.KeyStores.AddAsync(result);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(KeyStoreDto keyStore)
		{
			var result = _mapper.Map<KeyStore>(keyStore);

			result.UpdatedAt = DateTime.UtcNow;

			_context.KeyStores.Update(result);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var result = await _context.KeyStores.FindAsync(id);

			if (result != null)
			{
				_context.KeyStores.Remove(result);
				await _context.SaveChangesAsync();
			}
		}
	}
}
