
using Safran.External.ExclusiveService.PictureThis;
using Safran.External.ExclusiveService.PlantNet;
using System.Reflection;

namespace Safran.External.ExclusiveService
{
    public abstract class ExclusiveKnowledgeService
    {
        public string RootUrl { get; }

        public string ApiKey { get; }

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="rootUrl">the root url of the api</param>
        /// <param name="apiKey">the api key to use</param>
        public ExclusiveKnowledgeService(string rootUrl, string apiKey)
        {
            RootUrl = rootUrl;
            ApiKey = apiKey;
        }

        public abstract Task<string> IdentifyAsync();

        public abstract Task<Guid> RequestExpertAnalysisAsync();

        /// <summary>
        /// Gets an instance of the given class
        /// </summary>
        /// <param name="className"></param>
        /// <param name="rootUrl"></param>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">if the class name is not found in this assembly</exception>
        /// <exception cref="ArgumentException"></exception>
        public static ExclusiveKnowledgeService? GetInstance(string className, string rootUrl, string login, string pwd)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(className);

            var type = Assembly.GetExecutingAssembly().GetType(className)
                ?? throw new NotImplementedException("the requested class doesn't exist");
            
            return GetInstance(type, rootUrl, login, pwd);
        }

        /// <summary>
        /// Gets an instance of the given class
        /// </summary>
        /// <param name="type"></param>
        /// <param name="rootUrl"></param>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static ExclusiveKnowledgeService? GetInstance(Type type, string rootUrl, string login, string pwd)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(rootUrl);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(login);

            if (Activator.CreateInstance(type, new { rootUrl, login, pwd }) is not ExclusiveKnowledgeService res)
            {
                throw new ArgumentException($"the type {type} doesn't inherit the ExclusiveKnowledgeService class");
            }

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="rootUrl"></param>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public ExclusiveKnowledgeService GetInstance(KnowlegeProviders type, string rootUrl, string apiKey)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(rootUrl);

            return type switch
            {
                KnowlegeProviders.PlantNet => new PlantNetFacade(rootUrl, apiKey),
                KnowlegeProviders.PictureThis => new PictureThisFacade(rootUrl, apiKey),
                _ => throw new NotImplementedException($"{type} is not implemented in the factory")
            };
        }
    }
}
