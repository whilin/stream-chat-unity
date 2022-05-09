using System.Net;
using System.Net.Http.Headers;

public class HttpReponseGenericMessage 
{
       // public HttpReponseGenericMessage()

        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
        public bool IsSuccessStatusCode { get; set; }
}