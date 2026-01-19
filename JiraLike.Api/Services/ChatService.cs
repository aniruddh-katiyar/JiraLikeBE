namespace JiraLike.Api.Services
{
    using JiraLike.Api.services;

    public class ChatService
    {
        private readonly KnowledgeService _knowledge;
        private readonly GroqService _groq;

        public ChatService(KnowledgeService knowledge, GroqService groq)
        {
            _knowledge = knowledge;
            _groq = groq;
        }

        public async Task<string> HandleAsync(string question)
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
