﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using StreamChat.Core.DTO.Requests;

namespace StreamChat.Core.Requests
{
    public partial class UpdateUserPartialRequest : RequestObjectBase, ISavableTo<UpdateUserPartialRequestDTO>
    {
        /// <summary>
        /// User ID to update
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Sets new field values
        /// </summary>
        public Dictionary<string, object> Set { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Array of field names to unset
        /// </summary>
        public List<string> Unset { get; set; } = new List<string>();

        UpdateUserPartialRequestDTO ISavableTo<UpdateUserPartialRequestDTO>.SaveToDto()
        {
            return new UpdateUserPartialRequestDTO
            {
                Id = Id,
                Set = Set,
                Unset = Unset,
                AdditionalProperties = AdditionalProperties,
            };
        }
    }
}