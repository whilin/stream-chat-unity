﻿using StreamChat.Core.DTO.Models;
using StreamChat.Core.DTO.Responses;
using StreamChat.Core.Helpers;

namespace StreamChat.Core.Models
{
    public class User : ModelBase, ILoadableFrom<UserObjectDTO, User>, ILoadableFrom<UserResponseDTO, User>, ISavableTo<UserObjectDTO>
    {
        /// <summary>
        /// Expiration date of the ban
        /// </summary>
        public System.DateTimeOffset? BanExpires { get; set; }

        /// <summary>
        /// Whether a user is banned or not
        /// </summary>
        public bool? Banned { get; set; }

        /// <summary>
        /// Date/time of creation
        /// </summary>
        public System.DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Date of deactivation
        /// </summary>
        public System.DateTimeOffset? DeactivatedAt { get; set; }

        /// <summary>
        /// Date/time of deletion
        /// </summary>
        public System.DateTimeOffset? DeletedAt { get; set; }

        /// <summary>
        /// Unique user identifier
        /// </summary>
        public string Id { get; set; }

        public bool? Invisible { get; set; }

        /// <summary>
        /// Preferred language of a user
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Date of last activity
        /// </summary>
        public System.DateTimeOffset? LastActive { get; set; }

        /// <summary>
        /// Whether a user online or not
        /// </summary>
        public bool? Online { get; set; }

        public PushNotificationSettings PushNotifications { get; set; } //Todo: DTO -> Model

        /// <summary>
        /// Revocation date for tokens
        /// </summary>
        public System.DateTimeOffset? RevokeTokensIssuedBefore { get; set; }

        /// <summary>
        /// Determines the set of user permissions
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// List of teams user is a part of
        /// </summary>
        public System.Collections.Generic.List<string> Teams { get; set; }

        /// <summary>
        /// Date/time of the last update
        /// </summary>
        public System.DateTimeOffset? UpdatedAt { get; set; }

        //Not in API
        public string Name;
        public string Image;

        User ILoadableFrom<UserObjectDTO, User>.LoadFromDto(UserObjectDTO dto)
        {
            AdditionalProperties = dto.AdditionalProperties;
            BanExpires = dto.BanExpires;
            Banned = dto.Banned;
            CreatedAt = dto.CreatedAt;
            DeactivatedAt = dto.DeactivatedAt;
            DeletedAt = dto.DeletedAt;
            Id = dto.Id;
            Invisible = dto.Invisible;
            Language = dto.Language;
            LastActive = dto.LastActive;
            Online = dto.Online;
            PushNotifications = PushNotifications.TryLoadFromDto(dto.PushNotifications);
            RevokeTokensIssuedBefore = dto.RevokeTokensIssuedBefore;
            Role = dto.Role;
            Teams = dto.Teams;
            UpdatedAt = dto.UpdatedAt;

            //Not in API spec
            Name = dto.Name;
            Image = dto.Image;

            return this;
        }

        User ILoadableFrom<UserResponseDTO, User>.LoadFromDto(UserResponseDTO dto)
        {
            AdditionalProperties = dto.AdditionalProperties;
            BanExpires = dto.BanExpires;
            Banned = dto.Banned;
            CreatedAt = dto.CreatedAt;
            DeactivatedAt = dto.DeactivatedAt;
            DeletedAt = dto.DeletedAt;
            Id = dto.Id;
            Invisible = dto.Invisible;
            Language = dto.Language;
            LastActive = dto.LastActive;
            Online = dto.Online;
            PushNotifications = PushNotifications.TryLoadFromDto(dto.PushNotifications);
            RevokeTokensIssuedBefore = dto.RevokeTokensIssuedBefore;
            Role = dto.Role;
            Teams = dto.Teams;
            UpdatedAt = dto.UpdatedAt;

            //Not in API spec
            Name = dto.Name;
            Image = dto.Image;

            return this;
        }

        UserObjectDTO ISavableTo<UserObjectDTO>.SaveToDto() =>
            new UserObjectDTO
            {
                BanExpires = BanExpires,
                Banned = Banned,
                CreatedAt = CreatedAt,
                DeactivatedAt = DeactivatedAt,
                DeletedAt = DeletedAt,
                Id = Id,
                Invisible = Invisible,
                Language = Language,
                LastActive = LastActive,
                Online = Online,
                PushNotifications = PushNotifications.TrySaveToDto(),
                RevokeTokensIssuedBefore = RevokeTokensIssuedBefore,
                Role = Role,
                Teams = Teams,
                UpdatedAt = UpdatedAt,
                AdditionalProperties = AdditionalProperties,
                Name = Name,
                Image = Image,
            };
    }
}