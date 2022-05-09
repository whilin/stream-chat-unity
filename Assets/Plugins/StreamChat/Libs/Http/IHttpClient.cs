using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StreamChat.Libs.Http
{
    /// <summary>
    /// Http client
    /// </summary>
    public interface IHttpClient
    {
        void SetDefaultAuthenticationHeader(string value);

        void AddDefaultCustomHeader(string key, string value);

        Task<HttpReponseGenericMessage> PostAsync(Uri uri, ByteArrayContent content);

        Task<HttpReponseGenericMessage> PostAsync(Uri uri, string content);

        Task<HttpReponseGenericMessage> DeleteAsync(Uri uri);

        Task<HttpReponseGenericMessage> GetAsync(Uri uri);

        Task<HttpReponseGenericMessage> PatchAsync(Uri uri, string content);

        Task<HttpReponseGenericMessage> PostAsync(Uri uri, MultipartFormDataContent content);

        Task<HttpReponseGenericMessage> PostAsync(Uri uri, HttpContent content);
    }
}