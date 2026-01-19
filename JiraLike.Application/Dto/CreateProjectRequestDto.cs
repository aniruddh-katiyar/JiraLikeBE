using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraLike.Application.Dto
{
    public class CreateProjectRequestDto
    {
        public string Name { get; set; } = null!;
        public string Key { get; set; } = null!;
    }

}
