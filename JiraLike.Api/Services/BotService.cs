namespace JiraLike.Api.Services
{
    using JiraLike.Api.services;

    public class BotService
    {
        private readonly KnowledgeService _knowledge;
        private readonly OllamaService _ollama;

        public BotService(KnowledgeService knowledge, OllamaService ollama)
        {
            _knowledge = knowledge;
            _ollama = ollama;
        }

        public async Task<string> Ask(string question)
        {
            var context = _knowledge.LoadAll();

            var prompt = $"""
Answer the QUESTION using ONLY the FACTS from CONTEXT.

If the answer is NOT found in CONTEXT, reply exactly:
This information is not available in the project documentation.

CONTEXT:
{context}

QUESTION:
{question}

FACTUAL ANSWER (may combine multiple facts):
""";


            var answer = await _ollama.Generate(prompt);

            // Hard guard against instruction echo / assistant chatter
            if (string.IsNullOrWhiteSpace(answer) ||
                answer.Contains("sure", StringComparison.OrdinalIgnoreCase) ||
                answer.Contains("i can", StringComparison.OrdinalIgnoreCase) ||
                answer.Contains("context", StringComparison.OrdinalIgnoreCase))
            {
                return "This information is not available in the project documentation.";
            }

            return answer.Trim();
        }
    }
}
