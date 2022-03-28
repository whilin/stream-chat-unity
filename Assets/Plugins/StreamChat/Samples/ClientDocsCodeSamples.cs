﻿using System.Collections.Generic;
using System.Threading.Tasks;
using StreamChat.Core;
using StreamChat.Core.Requests;

namespace Plugins.StreamChat.Samples
{
    /// <summary>
    /// Code samples for https://getstream.io/chat/docs/unity/?language=unreal
    /// </summary>
    public class ClientDocsCodeSamples
    {
        private IStreamChatClient Client;

        private async Task CreatingChannelUsingChannelId()
        {
            var channelState = await Client.ChannelApi.GetOrCreateChannelAsync(
                channelType: "messaging", channelId: "channel-id-1", new ChannelGetOrCreateRequest());
        }

        private async void CreatingChannelForListOfMembers()
        {
            var requestBody = new ChannelGetOrCreateRequest
            {
                Data = new ChannelRequest
                {
                    Members = new List<ChannelMemberRequest>
                    {
                        new ChannelMemberRequest
                        {
                            UserId = "tommaso",
                        },
                        new ChannelMemberRequest
                        {
                            UserId = "thierry",
                        },
                    }
                }
            };

            var channelState = await Client.ChannelApi.GetOrCreateChannelAsync(channelType: "messaging", requestBody);
        }

        private async Task WatchingChannel()
        {
            await Client.ChannelApi.GetOrCreateChannelAsync(channelType: "messaging", channelId: "channel-id-1",
                new ChannelGetOrCreateRequest
                {
                    Watch = true,
                });
        }

        private async Task WatchingMultipleChannels()
        {
            var user_id = "specific-user-id";

            var request = new QueryChannelsRequest
            {
                //Sort results by created_at in descending order
                Sort = new List<SortParamRequest>
                {
                    new SortParamRequest
                    {
                        Field = "created_at",
                        Direction = -1,
                    }
                },

                // Limit & Offset results
                Limit = 30,
                Offset = 0,

                // Get only channels containing a specific member
                FilterConditions = new Dictionary<string, object>
                {
                    {
                        "members", new Dictionary<string, object>
                        {
                            { "$in", new[] { user_id } }
                        }
                    }
                }
            };

            var channelsResponse = await Client.ChannelApi.QueryChannelsAsync(request);
        }

        private async Task StopWatchingChannel()
        {
            var stopWatchingResponse = await Client.ChannelApi.StopWatchingChannelAsync(channelType: "messaging",
                channelId: "channel-id-1", new ChannelStopWatchingRequest());
        }

        private async Task WatcherCount()
        {
            var user_id = "specific-user-id";

            var request = new QueryChannelsRequest
            {
                //Sort results by created_at in descending order
                Sort = new List<SortParamRequest>
                {
                    new SortParamRequest
                    {
                        Field = "created_at",
                        Direction = -1,
                    }
                },

                // Limit & Offset results
                Limit = 30,
                Offset = 0,

                // Get only channels containing a specific member
                FilterConditions = new Dictionary<string, object>
                {
                    {
                        "members", new Dictionary<string, object>
                        {
                            { "$in", new[] { user_id } }
                        }
                    }
                }
            };

            //WatcherCount is a property of ChannelState which you get either from channels query or from GetOrCreateChannel request
            var channelsResponse = await Client.ChannelApi.QueryChannelsAsync(request);

            foreach (var channelState in channelsResponse.Channels)
            {
                var watcherCount = channelState.WatcherCount;
            }
        }

        public async Task PaginatingChannelWatchersWithChannelQuery()
        {
            //Not possible yet
        }

        public async Task DeleteChannel()
        {
            var deleteChannelResponse =
                await Client.ChannelApi.DeleteChannelAsync(channelType: "messaging", channelId: "channel-id-1");
        }

        public async Task DeletingManyChannels()
        {
            var deleteChannelsResponse = await Client.ChannelApi.DeleteChannelsAsync(new DeleteChannelsRequest
            {
                Cids = new List<string>
                {
                    "messaging:channel-id-1",
                    "messaging:channel-id-2",
                    "messaging:channel-id-3",
                },
                HardDelete = true
            });
        }
    }
}