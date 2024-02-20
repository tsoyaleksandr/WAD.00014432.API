namespace WAD._00014432.API.DAL.Models
{
	public class Key : CoreModel
	{
		public string Name { get; set; }

		public string Value { get; set; }

		public string Description { get; set; }

		public int KeyStoreId { get; set; }

		public KeyStore KeyStore { get; set; }
	}
}
