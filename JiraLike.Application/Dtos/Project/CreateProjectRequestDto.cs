namespace JiraLike.Application.Dto.Project
{
    public class CreateProjectRequestDto
    {
        public string Name { get; set; } = null!;
        public string Key { get; set; } = null!;

        public string ProjectDescription { get; set; } = null!;
    }

}
