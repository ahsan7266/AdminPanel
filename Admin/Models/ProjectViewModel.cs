namespace Admin.Models
{
    public class ProjectViewModel
    {
        public Guid ProjectId { get; set; }
        public string? Name { get; set; }

        public IFormFile? Img { get; set; }
        public string? ImgBase64 { get; set; }
        public string? ImgName { get; set; }
        public string? ImgFileName { get; set; }

        public IFormFile? ProjectFile { get; set; }
        public string? ProjectFileBase64 { get; set; }
        public string? ProjectFName { get; set; }
        public string? ProjectFileName { get; set; }

        public string? Url { get; set; }
        public string? Type { get; set; }
        public Guid PeronalinfoId { get; set; }
    }
}
