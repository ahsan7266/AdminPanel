namespace Admin.Models.Portfolio
{
    public class SkillViewModel
    {
        public Guid SkillId { get; set; }
        public string? Name { get; set; }
        public int Percentage { get; set; }
        public Guid PeronalinfoId { get; set; }
    }
}
