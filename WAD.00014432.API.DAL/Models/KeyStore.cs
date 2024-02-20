namespace WAD._00014432.API.DAL.Models
{
	public class KeyStore : CoreModel
	{
		public string Name { get; set; }

		public ICollection<Key> Keys { get; set; }
	}
}
