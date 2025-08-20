namespace Safran.External.ExclusiveService.PlantNet
{
    /// <summary>
    /// The plantNet client
    /// </summary>
    /// <param name="rootUrl"></param>
    /// <param name="apiKey"></param>
    public class PlantNetFacade(string rootUrl, string apiKey) : 
        ExclusiveKnowledgeService(rootUrl, apiKey)
    {
        /// <inheritDoc>
        public override async Task<string> IdentifyAsync()
        {
            return await Task.FromResult("unkown");
        }

        /// <inheritDoc>
        public override async Task<Guid> RequestExpertAnalysisAsync()
        {
            return await Task.FromResult( Guid.NewGuid());
        }
    }
}
