using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace StreamChat.Libs.Http {
    //Todo: refactor methods to remove duplication
    //Probably best to use HttpClient.SendAsync only with optional content instead specialized methods that have common logic
    //We could also not pass TRequestDto TResponseDto but have it registered in a map so that calls are not bloated with so many types

    /// <summary>
    /// Base Api client
    /// </summary>
    public class HttpClientWebGLAdapter : IHttpClient {
        bool verbose = false;

        string accessToken = string.Empty;
        Dictionary<string, string> defaultCustomHeaders = new Dictionary<string, string> ();

        public void SetDefaultAuthenticationHeader (string accessToken) {
            this.accessToken = accessToken;
        }

        public void AddDefaultCustomHeader (string key, string value) {
            defaultCustomHeaders.Add (key, value);
        }

        public Task<HttpReponseGenericMessage> PostAsync (Uri uri, ByteArrayContent content) {
            throw new NotImplementedException ();
        }

        public Task<HttpReponseGenericMessage> PostAsync (Uri uri, MultipartFormDataContent content) {
            throw new NotImplementedException ();
        }

        public Task<HttpReponseGenericMessage> PostAsync (Uri uri, HttpContent content) {
            //UnityWebRequest request = UnityWebRequest.Post(uri, )
            throw new NotImplementedException ();
        }

        public async Task<HttpReponseGenericMessage> PostAsync (Uri uri, string content) {
            UnityWebRequest request = new UnityWebRequest (uri, "POST");


            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes (content);
            request.uploadHandler = (UploadHandler) new UploadHandlerRaw (bodyRaw);
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer ();
            request.uploadHandler.contentType = "application/json";

            SetDefaultHeader (request);

            var message = await SendRequest (request);
            return message;

            /*

            HttpReponseGenericMessage responseModel = new HttpReponseGenericMessage ();
            responseModel.StatusCode = (HttpStatusCode) request.responseCode;

            if (request.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log ($"PostAsync Error:{request.error}");
                responseModel.IsSuccessStatusCode = false;

            } else if (request.result == UnityWebRequest.Result.ProtocolError) {
                string msg = request.downloadHandler.text ?? string.Empty;

                Debug.Log ($"PostAsync Error:{request.error} msg:{msg}");

                responseModel.IsSuccessStatusCode = false;
            } else {
                if (verbose)
                    Debug.LogFormat ("SendNetRequest Response:{0}, Document:{1}", request.responseCode, request.downloadHandler.text);

                String res = request.downloadHandler.text;

                responseModel.IsSuccessStatusCode = true;
                responseModel.Content = res;
            }

            return responseModel;
            */
        }

        public async Task<HttpReponseGenericMessage> DeleteAsync (Uri uri) {
            UnityWebRequest request = new UnityWebRequest (uri, "DELETE");

            // byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes (content);
            // request.uploadHandler = (UploadHandler) new UploadHandlerRaw (bodyRaw);
            // request.uploadHandler.contentType = "application/json";
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer ();

            SetDefaultHeader (request);

            var message = await SendRequest (request);
            return message;

            /*

            HttpReponseGenericMessage responseModel = new HttpReponseGenericMessage ();
            responseModel.StatusCode = (HttpStatusCode) request.responseCode;

            if (request.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log ($"DeleteAsync Error:{request.error}");
                responseModel.IsSuccessStatusCode = false;
                responseModel.Content = request.error;

            } else if (request.result == UnityWebRequest.Result.ProtocolError) {
                string msg = request.downloadHandler.text ?? string.Empty;
                Debug.Log ($"DeleteAsync Error:{request.error} msg:{msg}");

                responseModel.IsSuccessStatusCode = false;
                responseModel.Content = request.error;
            } else {
                if (verbose)
                    Debug.LogFormat ("SendNetRequest Response:{0}, Document:{1}", request.responseCode, request.downloadHandler.text);

                String res = request.downloadHandler.text;

                responseModel.IsSuccessStatusCode = true;
                responseModel.Content = res;
            }

            return responseModel;
            */
        }

        public async Task<HttpReponseGenericMessage> GetAsync (Uri uri) {
            UnityWebRequest request = UnityWebRequest.Get (uri);

            // byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes (content);
            // request.uploadHandler = (UploadHandler) new UploadHandlerRaw (bodyRaw);
            // request.uploadHandler.contentType = "application/json";
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer ();

            SetDefaultHeader (request);

            var message = await SendRequest (request);
            return message;
            /*

            await request.SendWebRequest ();

            HttpReponseGenericMessage responseModel = new HttpReponseGenericMessage ();
            responseModel.StatusCode = (HttpStatusCode) request.responseCode;

            if (request.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log ($"RequestAsync Error:{request.error}");
                responseModel.IsSuccessStatusCode = false;
                responseModel.Content = request.error;

            } else if (request.result == UnityWebRequest.Result.ProtocolError) {
                string msg = request.downloadHandler.text ?? string.Empty;
                Debug.Log ($"RequestAsync Error:{request.error} msg:{msg}");

                responseModel.IsSuccessStatusCode = false;
                responseModel.Content = request.error;
            } else {
                if (verbose)
                    Debug.LogFormat ("SendNetRequest Response:{0}, Document:{1}", request.responseCode, request.downloadHandler.text);

                String res = request.downloadHandler.text;

                responseModel.IsSuccessStatusCode = true;
                responseModel.Content = res;
            }

            return responseModel;
            */
        }

        //참조
        //https://github.com/Kubos-cz/Unity-WebRequest-Example/blob/master/PatchRequest.cs

        public async Task<HttpReponseGenericMessage> PatchAsync (Uri uri, string content) {

            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes (content);

            UnityWebRequest request = UnityWebRequest.Put (uri, bodyRaw);
            request.method = "PATCH";

            SetDefaultHeader (request);
            request.SetRequestHeader ("Content-Type", "application/json");
            request.SetRequestHeader ("Content-length", (bodyRaw.Length.ToString ()));

            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer ();

            var message = await SendRequest (request);
            return message;

            /*
                        await request.SendWebRequest ();

                        HttpReponseGenericMessage responseModel = new HttpReponseGenericMessage ();
                        responseModel.StatusCode = (HttpStatusCode) request.responseCode;

                        if (request.result == UnityWebRequest.Result.ConnectionError) {
                            Debug.Log ($"RequestAsync Error:{request.error}");
                            responseModel.IsSuccessStatusCode = false;
                            responseModel.Content = request.error;

                        } else if (request.result == UnityWebRequest.Result.ProtocolError) {
                            string msg = request.downloadHandler.text ?? string.Empty;
                            Debug.Log ($"RequestAsync Error:{request.error} msg:{msg}");

                            responseModel.IsSuccessStatusCode = false;
                            responseModel.Content = request.error;
                        } else {
                            if (verbose)
                                Debug.LogFormat ("SendNetRequest Response:{0}, Document:{1}", request.responseCode, request.downloadHandler.text);

                            String res = request.downloadHandler.text;

                            responseModel.IsSuccessStatusCode = true;
                            responseModel.Content = res;
                        }

                        return responseModel;
            */
        }

        private void SetDefaultHeader (UnityWebRequest request) {
            request.SetRequestHeader ("Authorization", accessToken);
            foreach (var keyValue in defaultCustomHeaders) {
                request.SetRequestHeader (keyValue.Key, keyValue.Value);
            }
        }

        private async Task<HttpReponseGenericMessage> SendRequest (UnityWebRequest request) {

            await request.SendWebRequest ();

            HttpReponseGenericMessage responseModel = new HttpReponseGenericMessage ();
            responseModel.StatusCode = (HttpStatusCode) request.responseCode;

            if (request.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log ($"RequestAsync Error:{request.error}");
                responseModel.IsSuccessStatusCode = false;
                responseModel.Content = request.error;

            } else if (request.result == UnityWebRequest.Result.ProtocolError) {
                string msg = request.downloadHandler.text ?? string.Empty;
                Debug.Log ($"RequestAsync Error:{request.error} msg:{msg}");

                responseModel.IsSuccessStatusCode = false;
                responseModel.Content = request.error;
            } else {
                if (verbose)
                    Debug.LogFormat ("SendNetRequest Response:{0}, Document:{1}", request.responseCode, request.downloadHandler.text);

                String res = request.downloadHandler.text;

                responseModel.IsSuccessStatusCode = true;
                responseModel.Content = res;
            }

            return responseModel;
        }
    }

}