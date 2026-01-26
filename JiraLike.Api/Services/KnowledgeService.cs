//namespace JiraLike.Api.services
//{
//    public class KnowledgeService
//    {
//        private readonly string _knowledgePath;

//        public KnowledgeService(IWebHostEnvironment env)
//        {
//            _knowledgePath = Path.Combine(env.ContentRootPath, "KnowledgeBase");
//        }

//        public string LoadAll()
//        {
//            if (!Directory.Exists(_knowledgePath))
//                return string.Empty;

//            var files = Directory.GetFiles(_knowledgePath, "*.md");
//            return string.Join("\n", files.Select(File.ReadAllText));
//        }
//    }

//}
