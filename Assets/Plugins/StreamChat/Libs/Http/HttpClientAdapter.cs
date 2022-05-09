using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StreamChat.Libs.Http {
    /// <summary>
    /// .NET http client adapter
    /// </summary>
    public class HttpClientAdapter : IHttpClient {
        public HttpClientAdapter () {
            _httpClient = new HttpClient ();
        }

        public void SetDefaultAuthenticationHeader (string value) => _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue (value);

        public void AddDefaultCustomHeader (string key, string value) => _httpClient.DefaultRequestHeaders.Add (key, value);

        public async Task<HttpReponseGenericMessage> GetAsync (Uri uri) {
            var httpResponse = await _httpClient.GetAsync (uri);
            var genericMessage = new HttpReponseGenericMessage ();
            genericMessage.StatusCode = httpResponse.StatusCode;
            genericMessage.IsSuccessStatusCode = httpResponse.IsSuccessStatusCode;
            genericMessage.Content = await httpResponse.Content.ReadAsStringAsync ();

            return genericMessage;
        }

        public async Task<HttpReponseGenericMessage> PostAsync (Uri uri, string content) {
            var httpResponse = await _httpClient.PostAsync (uri, new StringContent (content));
            var genericMessage = new HttpReponseGenericMessage ();
            genericMessage.StatusCode = httpResponse.StatusCode;
            genericMessage.IsSuccessStatusCode = httpResponse.IsSuccessStatusCode;
            genericMessage.Content = await httpResponse.Content.ReadAsStringAsync ();

            return genericMessage;
        }

        public async Task<HttpReponseGenericMessage> PostAsync (Uri uri, HttpContent content) {
            var httpResponse = await _httpClient.PostAsync (uri, content);
            var genericMessage = new HttpReponseGenericMessage ();
            genericMessage.StatusCode = httpResponse.StatusCode;
            genericMessage.IsSuccessStatusCode = httpResponse.IsSuccessStatusCode;
            genericMessage.Content = await httpResponse.Content.ReadAsStringAsync ();

            return genericMessage;
        }

        public async Task<HttpReponseGenericMessage> PostAsync (Uri uri, MultipartFormDataContent content) {
            var httpResponse = await _httpClient.PostAsync (uri, content);
            var genericMessage = new HttpReponseGenericMessage ();
            genericMessage.StatusCode = httpResponse.StatusCode;
            genericMessage.IsSuccessStatusCode = httpResponse.IsSuccessStatusCode;
            genericMessage.Content = await httpResponse.Content.ReadAsStringAsync ();

            return genericMessage;
        }

        public async Task<HttpReponseGenericMessage> PostAsync (Uri uri, ByteArrayContent content) {
            var httpResponse = await _httpClient.PostAsync (uri, content);
            var genericMessage = new HttpReponseGenericMessage ();
            genericMessage.StatusCode = httpResponse.StatusCode;
            genericMessage.IsSuccessStatusCode = httpResponse.IsSuccessStatusCode;
            genericMessage.Content = await httpResponse.Content.ReadAsStringAsync ();

            return genericMessage;
        }

        public async Task<HttpReponseGenericMessage> PatchAsync (Uri uri, string content) {
            var httpResponse = await _httpClient.SendAsync (new HttpRequestMessage (new HttpMethod ("PATCH"), uri) { Content = new StringContent (content) });
            var genericMessage = new HttpReponseGenericMessage ();
            genericMessage.StatusCode = httpResponse.StatusCode;
            genericMessage.IsSuccessStatusCode = httpResponse.IsSuccessStatusCode;
            genericMessage.Content = await httpResponse.Content.ReadAsStringAsync ();

            return genericMessage;
        }

        public async Task<HttpReponseGenericMessage> DeleteAsync (Uri uri) {
            var httpResponse = await _httpClient.DeleteAsync (uri);
            var genericMessage = new HttpReponseGenericMessage ();
            genericMessage.StatusCode = httpResponse.StatusCode;
            genericMessage.IsSuccessStatusCode = httpResponse.IsSuccessStatusCode;
            genericMessage.Content = await httpResponse.Content.ReadAsStringAsync ();

            return genericMessage;
        }

        private readonly HttpClient _httpClient;
    }
}