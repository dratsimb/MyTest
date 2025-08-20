

namespace Safran.External.ExclusiveService.PictureThis
{
    public class PictureThisFacade(string rootUrl, string apiKey) 
        : ExclusiveKnowledgeService(rootUrl, apiKey)
    {
        /// <inheritDoc>
        public override async Task<string> IdentifyAsync()
        {
            return await Task.FromResult("unkown");
        }

        /// <inheritDoc>
        public override async Task<Guid> RequestExpertAnalysisAsync()
        {
            return await Task.FromResult(Guid.NewGuid());
        }
    }
}
