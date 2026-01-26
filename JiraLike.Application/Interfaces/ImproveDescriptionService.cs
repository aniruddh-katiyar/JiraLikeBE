//--
//This service is used for genrate project description.
//--
namespace JiraLike.Application.Interfaces
{
    /// <summary>
    /// ImproveDescriptionService
    /// </summary>
    public class ImproveDescriptionService
    {
        private readonly IAiService _aiService;
        /// <summary>
        /// Constructor that initilize ai service.
        /// </summary>
        /// <param name="aiService"></param>
        public ImproveDescriptionService(IAiService aiService)
        {
            _aiService = aiService;
        }

        /// <summary>
        /// This methida takes promt and give response.
        /// </summary>
        /// <param name="rawDescription"></param>
        /// <returns></returns>
        public async Task<string> ImproveDiscriptionAsync(string rawDescription, CancellationToken cancellationToken)
        {
           

            var prompt = $"""
                 You are an expert product manager working with agile software teams.
                
                You will receive a raw, unstructured project idea written by a user.
                
                Your task is to generate a professional, well-structured project description suitable for a Jira-like project management system.
                
                Guidelines:
                - Do NOT invent requirements that are not implied.
                - Improve clarity, professionalism, and structure.
                - Keep the description concise and practical.
                - Assume the project is a software project unless stated otherwise.
                - Use clear headings.
                
                Output Format (STRICT – do not add extra text):
                
                Project Overview:
                <2–3 sentences describing the purpose and value of the project>
                
                Objectives:
                - <Objective 1>
                - <Objective 2>
                - <Objective 3>
                
                Key Features:
                - <Feature 1>
                - <Feature 2>
                - <Feature 3>
                
                Scope:
                In Scope:
                - <Item 1>
                - <Item 2>
                
                Out of Scope:
                - <Item 1>
                - <Item 2>
                
                Target Users:
                - <User type>
                
                Success Criteria:
                - <Clear measurable outcome>
                
                Input:
                {rawDescription}
                
                """;

            return await _aiService.Generate(prompt);
        }

    }
}

