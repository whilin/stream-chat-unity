using UnityEngine;

namespace StreamChat.Core.Auth
{
    /// <summary>
    /// Asset to keep auth credentials
    /// </summary>
    [CreateAssetMenu(fileName = "AuthCredentials", menuName = StreamChatClient.MenuPrefix + "Config/Create auth credentials asset", order = 1)]
    public class AuthCredentialsAsset : ScriptableObject
    {
        public AuthCredentials Credentials => new AuthCredentials(_apiKey, _testUserToken, _testUserId);

        [Header("Your `Api Key`")]
        [Tooltip("You can find it in Stream Dashboard")]
        [SerializeField]
        private string _apiKey;

        [SerializeField]
        private string _testUserToken;

        [SerializeField]
        private string _testUserId;
    }
}