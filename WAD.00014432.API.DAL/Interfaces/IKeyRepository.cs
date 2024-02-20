using WAD._00014432.API.DAL.DTOs;
using WAD._00014432.API.DAL.Responses;

namespace WAD._00014432.API.DAL.Interfaces
{
	public interface IKeyRepository
	{
		Task<KeyResponse> GetByIdAsync(int id);
		Task<IEnumerable<KeyResponse>> GetAllAsync();
		Task AddAsync(KeyDto key);
		Task UpdateAsync(KeyDto key);
		Task DeleteAsync(int id);
	}
}
