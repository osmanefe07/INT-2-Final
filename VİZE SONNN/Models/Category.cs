namespace vize.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<File> Files { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}

