using CrispChat.Entities;
using CrispChat.HttpClients;
using CrispChat.Repositories;
using MongoDB.Driver;
using System.Text.Json;

namespace CrispChat.Services
{
    public class ConversationsService : IConversationsService
    {
        private readonly ICrispChatHttpClient _crispChatHttpClient;
        private readonly IConversationRepository _conversationRepository;
        private readonly IVisitorRepository _visitorRepository;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMetaRepository _metaRepository;
        private readonly IRoutingRepository _routingRepository;

        public ConversationsService(ICrispChatHttpClient crispChatHttpClient,
            IConversationRepository conversationRepository, IPeopleRepository peopleRepository,
            IVisitorRepository visitorRepository, IWebsiteRepository websiteRepository,
            IMessageRepository messageRepository, IRoutingRepository routingRepository, IMetaRepository metaRepository)
        {
            _crispChatHttpClient = crispChatHttpClient;
            _conversationRepository = conversationRepository;
            _peopleRepository = peopleRepository;
            _visitorRepository = visitorRepository;
            _websiteRepository = websiteRepository;
            _messageRepository = messageRepository;
            _routingRepository = routingRepository;
            _metaRepository = metaRepository;
        }

        public async Task<bool> GetConversationsAsync(DateTime start, DateTime end)
        {
            var conversations = new List<Conversation>();
            for (int i = 1; i < int.MaxValue; i++)
            {
                var res = await _crispChatHttpClient.GetConversations(i, start, end);
                if (res == null) continue;
                if (res.Count == 0) break;

                var sessionIds = res.Select(x => x.SessionId).ToList();
                var cons = await _conversationRepository.FindAll().Find(x => sessionIds.Contains(x.SessionId)).ToListAsync();
                var sessionIdsRemove = cons.Select(x => x.SessionId).ToList();
                res.RemoveAll(x => sessionIdsRemove.Contains(x.SessionId));
                conversations.AddRange(res);
            }
            await _conversationRepository.CreateManyAsync(conversations);
            return true;
        }


        public async Task<bool> GetPeoplesAsync(DateTime start, DateTime end)
        {
            var peoples = new List<People>();
            for (int i = 1; i < int.MaxValue; i++)
            {
                var res = await _crispChatHttpClient.GetPeople(i, start, end);
                if (res == null) continue;
                if (res.Count == 0) break;

                var peopleIds = res.Select(x => x.PeopleId).ToList();
                var peos = await _peopleRepository.FindAll().Find(x => peopleIds.Contains(x.PeopleId)).ToListAsync();
                var peopleIdsRemove = peos.Select(x => x.PeopleId).ToList();
                res.RemoveAll(x => peopleIdsRemove.Contains(x.PeopleId));
                peoples.AddRange(res);
            }
            await _peopleRepository.CreateManyAsync(peoples);
            return true;
        }


        public async Task<bool> GetVisitorsAsync()
        {
            var visitors = new List<Visitor>();
            for (int i = 1; i < int.MaxValue; i++)
            {
                var res = await _crispChatHttpClient.GetVisitor(i);
                if (res == null) continue;
                if (res.Count() == 0) break;

                var visitorIds = res.Select(x => x.SessionId).ToList();
                var vis = await _visitorRepository.FindAll().Find(x => visitorIds.Contains(x.SessionId)).ToListAsync();
                var visitorIdsRemove = vis.Select(x => x.SessionId).ToList();
                res.RemoveAll(x => visitorIdsRemove.Contains(x.SessionId));
                visitors.AddRange(res);
            }
            await _visitorRepository.CreateManyAsync(visitors);
            return true;
        }

        public async Task<bool> GetWebsite(string websiteId)
        {
            var res = await _crispChatHttpClient.GetConfigWebsite(websiteId);
            if (res == null) return false;

            var website = await _websiteRepository.FindAll().Find(x => x.WebsiteId == res.WebsiteId).FirstOrDefaultAsync();

            if (website == null) await _websiteRepository.CreateAsync(res); ;

            return true;
        }

        public async Task HandleSyncSession()
        {
            var listWrites = new List<WriteModel<Conversation>>();
            var messages = new List<Message>();
            var metas = new List<Metas>();
            var routings = new List<Routing>();
            var segments = new List<Segment>();
            var conversations = await _conversationRepository.GetSyncPaging();
            foreach (var conversation in conversations)
            {
                
                try
                {
                    var message = await _crispChatHttpClient.GetMessages(conversation.SessionId);
                    if (message != null)
                    {
                        messages.AddRange(message);
                    }
                    //var segment = await _crispChatHttpClient.GetSegments(conversation.SessionId);
                    //if (message != null)
                    //{
                    //    var mes = new Message()
                    //    {
                    //        SessionId = conversation.SessionId,
                    //        Data = JsonSerializer.Serialize(message)
                    //    };
                    //    messages.Add(mes);
                    //}
                    var meta = await _crispChatHttpClient.GetMetas(conversation.SessionId);
                    if (meta != null)
                    {
                        metas.Add(meta);
                    }
                    var routing = await _crispChatHttpClient.GetRouting(conversation.SessionId);
                    if (routing != null)
                    {
                        routings.Add(routing);
                    }
                    var update = Builders<Conversation>.Update.Set(x => x.IsSync, true);
                    var filter = Builders<Conversation>.Filter.Eq(x => x.Id, conversation.Id);
                    listWrites.Add(new UpdateOneModel<Conversation>(filter, update));
                }
                catch (Exception e)
                {
                }
            }

            var messageBySessionIds = messages.Select(x => x.SessionId).Distinct().ToList();
            var messageRemove = await _messageRepository.FindAll().Find(x => messageBySessionIds.Contains(x.SessionId)).ToListAsync();
            var messageRemoveSessionId = messageRemove.Select(x => x.SessionId).Distinct().ToList();
            messages.RemoveAll(x => messageRemoveSessionId.Contains(x.SessionId));

            if (messages.Count > 0) await _messageRepository.CreateManyAsync(messages);
            if (metas.Count > 0) await _metaRepository.CreateManyAsync(metas);
            if (routings.Count > 0) await _routingRepository.CreateManyAsync(routings);
            if (listWrites.Count > 0) await _conversationRepository.BulkWriteAsync(listWrites);
        }
    }
}
