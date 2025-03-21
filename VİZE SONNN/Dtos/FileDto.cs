﻿namespace vize.Dtos
{
    public class FileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public int Size { get; set; }


        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int CategoryId { get; internal set; }
    }
}
