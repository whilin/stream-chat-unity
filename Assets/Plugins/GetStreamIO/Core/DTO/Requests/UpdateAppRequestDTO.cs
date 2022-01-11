//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------


using GetStreamIO.Core.DTO.Responses;
using GetStreamIO.Core.DTO.Events;
using GetStreamIO.Core.DTO.Models;

namespace GetStreamIO.Core.DTO.Requests
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class UpdateAppRequestDTO
    {
        [Newtonsoft.Json.JsonProperty("apn_config", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public APNConfigRequestDTO ApnConfig { get; set; }

        [Newtonsoft.Json.JsonProperty("async_url_enrich_enabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AsyncUrlEnrichEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("auto_translation_enabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AutoTranslationEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("before_message_send_hook_url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BeforeMessageSendHookUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_hide_members_only", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ChannelHideMembersOnly { get; set; }

        [Newtonsoft.Json.JsonProperty("custom_action_handler_url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CustomActionHandlerUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("disable_auth_checks", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool DisableAuthChecks { get; set; }

        [Newtonsoft.Json.JsonProperty("disable_permissions_checks", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool DisablePermissionsChecks { get; set; }

        [Newtonsoft.Json.JsonProperty("enforce_unique_usernames", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public UpdateAppRequestEnforceUniqueUsernames EnforceUniqueUsernames { get; set; }

        [Newtonsoft.Json.JsonProperty("file_upload_config", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FileUploadConfigRequestDTO FileUploadConfig { get; set; }

        [Newtonsoft.Json.JsonProperty("firebase_config", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FirebaseConfigRequestDTO FirebaseConfig { get; set; }

        [Newtonsoft.Json.JsonProperty("grants", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<string>> Grants { get; set; }

        [Newtonsoft.Json.JsonProperty("huawei_config", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HuaweiConfigRequestDTO HuaweiConfig { get; set; }

        [Newtonsoft.Json.JsonProperty("image_moderation_enabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ImageModerationEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("image_moderation_labels", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ImageModerationLabels { get; set; }

        [Newtonsoft.Json.JsonProperty("image_upload_config", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FileUploadConfigRequestDTO ImageUploadConfig { get; set; }

        [Newtonsoft.Json.JsonProperty("migrate_permissions_to_v2", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool MigratePermissionsToV2 { get; set; }

        [Newtonsoft.Json.JsonProperty("multi_tenant_enabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool MultiTenantEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("permission_version", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public VersionType PermissionVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("push_config", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PushConfigRequestDTO PushConfig { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke_tokens_issued_before", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset RevokeTokensIssuedBefore { get; set; }

        [Newtonsoft.Json.JsonProperty("sqs_key", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SqsKey { get; set; }

        [Newtonsoft.Json.JsonProperty("sqs_secret", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SqsSecret { get; set; }

        [Newtonsoft.Json.JsonProperty("sqs_url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SqsUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("user_search_disallowed_roles", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> UserSearchDisallowedRoles { get; set; }

        [Newtonsoft.Json.JsonProperty("webhook_events", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> WebhookEvents { get; set; }

        [Newtonsoft.Json.JsonProperty("webhook_url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WebhookUrl { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

    }

}

