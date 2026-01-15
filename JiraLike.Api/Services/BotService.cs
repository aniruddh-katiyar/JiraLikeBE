namespace JiraLike.Api.Services
{
    using JiraLike.Api.services;

    public class BotService
    {
        private readonly KnowledgeService _knowledge;
        private readonly GroqService _groq;

        public BotService(KnowledgeService knowledge, GroqService groq)
        {
            _knowledge = knowledge;
            _groq = groq;
        }

        public async Task<string> Ask(string question)
        {
            var context = _knowledge.LoadAll();

            var prompt = $"""
Answer the QUESTION using the CONTEXT.
Be concise and factual.

CONTEXT:
{context}

QUESTION:
{question}
""";

            return await _groq.Generate(prompt);
        }

    }


}
