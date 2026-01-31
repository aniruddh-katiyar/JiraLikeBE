namespace JiraLike.Application.Command.Ai
{
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class ImproveProjectDiscriptionRequestQuery :  IRequest<string>
    {
        [Required]
        public string RawDescription { get; set; }
        public ImproveProjectDiscriptionRequestQuery(string rawDescription )
        {
            RawDescription = rawDescription;
        }
    }
}
