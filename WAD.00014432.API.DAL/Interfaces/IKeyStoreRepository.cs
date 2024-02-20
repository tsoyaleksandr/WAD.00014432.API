using WAD._00014432.API.DAL.DTOs;
using WAD._00014432.API.DAL.Responses;

namespace WAD._00014432.API.DAL.Interfaces
{
	public interface IKeyStoreRepository
	{
		Task<KeyStoreReponse> GetByIdAsync(int id);
		Task<IEnumerable<KeyStoreReponse>> GetAllAsync();
		Task AddAsync(KeyStoreDto keyStore);
		Task UpdateAsync(KeyStoreDto keyStore);
		Task DeleteAsync(int id);
	}
}
