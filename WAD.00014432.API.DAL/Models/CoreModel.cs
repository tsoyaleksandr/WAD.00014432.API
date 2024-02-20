namespace WAD._00014432.API.DAL.Models
{
    public abstract class CoreModel
    {
        // Main class to inherit all other classes
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
