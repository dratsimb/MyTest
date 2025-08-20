using System.Text;
using System.Text.Json;

namespace Safran.Client
{
    public class BaseWrapper
    {
        private HttpClient _httpClient = new HttpClient();

        protected Uri RootUri { get; }

        public BaseWrapper(string rootUri) : this(new Uri(rootUri)) 
        {
        
        }

        public BaseWrapper(Uri rootUri) 
        {
            RootUri = rootUri;
        }

        protected async Task<T> GetAsync<T>(string url, Dictionary<string, object> parameters)
        {
            var query = $"{url}{ConvertToQueryString(parameters)}";

            var res = await _httpClient.GetAsync(query);

            return await ConvertAsync<T>(res);
        }

        protected async Task<T> DeleteAsync<T>(string url, Dictionary<string, object> parameters)
        {
            var query = $"{url}{ConvertToQueryString(parameters)}";

            var res = await _httpClient.DeleteAsync(query);

            return await ConvertAsync<T>(res);
        }


        protected async Task<T> PostAsync<T>(string url, Dictionary<string, object> parameters, object content)
        {
            var query = $"{url}{ConvertToQueryString(parameters)}";

            var json = JsonSerializer.Serialize(content);

            var jsonContent = new StringContent(json);
 
            var res = await _httpClient.PostAsync(query, jsonContent);

            return await ConvertAsync<T>(res);
        }

        protected async Task<T> PutAsync<T>(string url, Dictionary<string, object> parameters, object content)
        {
            var query = $"{url}{ConvertToQueryString(parameters)}";

            var json = JsonSerializer.Serialize(content);

            var jsonContent = new StringContent(json);
 
            var res = await _httpClient.PutAsync(query, jsonContent);

            return await ConvertAsync<T>(res);
        }

        protected async Task<T> PatchAsync<T>(string url, Dictionary<string, object> parameters, object content)
        {
            var query = $"{url}{ConvertToQueryString(parameters)}";

            var json = JsonSerializer.Serialize(content);

            var jsonContent = new StringContent(json);
 
            var res = await _httpClient.PatchAsync(query, jsonContent);

            return await ConvertAsync<T>(res);
        }

        private static string ConvertToQueryString(Dictionary<string, object> parameters)
        {
            var list = new List<string>();
            foreach (var kv in parameters)
            {
                list.Add($"{kv.Key}={kv.Value}");
            }

            return "?" + string.Join('&', list);
        }

        private static async Task<T>? ConvertAsync<T>(HttpResponseMessage response)
        {
            var text = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    throw new NotFoundException(text);

                case System.Net.HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(text);

                case System.Net.HttpStatusCode.BadRequest:
                    throw new BadRequestException(text);

                case System.Net.HttpStatusCode.Forbidden:
                    throw new ForbiddenException(text);

                case System.Net.HttpStatusCode.PaymentRequired:
                    throw new MustPayException(text);

                case System.Net.HttpStatusCode.Accepted:
                case System.Net.HttpStatusCode.NoContent:
                    return default;

                default:
                    break;
            }

            var res = JsonSerializer.Deserialize<T>(text);

            return res;
        }
    }
}
