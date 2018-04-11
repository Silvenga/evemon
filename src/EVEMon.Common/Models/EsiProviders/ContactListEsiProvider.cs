using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using EVEMon.Common.Collections;
using EVEMon.Common.Constants;
using EVEMon.Common.Enumerations;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace EVEMon.Common.Models.EsiProviders
{
    public class ContactListEsiProvider : IEsiProvider<SerializableAPIContactList>
    {
        private readonly IContactsApi _contactsApi;
        private readonly ICharacterApi _characterApi;
        private readonly IUniverseApi _universeApi;
        private IDictionary<int, string> _factionNames;

        public Enum Provides { get; } = CCPAPICharacterMethods.ContactList;

        public ContactListEsiProvider()
        {
            _contactsApi = new ContactsApi();
            _characterApi = new CharacterApi();
            _universeApi = new UniverseApi();
        }

        public CCPAPIResult<SerializableAPIContactList> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var characterId = int.Parse(legacyPostData["characterID"]);

            _factionNames = GetFactionNames(dataSource);

            var result = new CCPAPIResult<SerializableAPIContactList>
            {
                Result = new SerializableAPIContactList()
            };

            var characterInfo = _characterApi.GetCharactersCharacterId(characterId, dataSource, accessToken);

            result.Result.Contacts = GetCharacterContacts(characterId, dataSource, accessToken);
            result.Result.CorporateContacts = GetCorpContacts(characterInfo.CorporationId.GetValueOrDefault(), dataSource, accessToken);
            result.Result.AllianceContacts = GetAllianceContacts(characterInfo.AllianceId.GetValueOrDefault(), dataSource, accessToken);

            return result;
        }

        private Collection<SerializableContactListItem> GetCharacterContacts(int characterId, string dataSource, string accessToken)
        {
            var contacts = GetAllPages(page => _contactsApi.GetCharactersCharacterIdContactsWithHttpInfo(characterId, dataSource, page, accessToken)).ToList();
            var names = GetNames(contacts.Where(x => x.ContactType != GetCharactersCharacterIdContacts200Ok.ContactTypeEnum.Faction).Select(x => x.ContactId).ToList(), dataSource);

            var mapped =  contacts.Select(x => new SerializableContactListItem
            {
                Standing = x.Standing.GetValueOrDefault(),
                ContactID = x.ContactId.GetValueOrDefault(),
                InWatchlist = x.IsWatched.GetValueOrDefault(),
                Group = ContactGroup.Personal,
                //Yea gross because normal universe names api doesnt handle factions
                ContactName = x.ContactType == GetCharactersCharacterIdContacts200Ok.ContactTypeEnum.Faction ? _factionNames[x.ContactId.GetValueOrDefault()] : names[x.ContactId.GetValueOrDefault()],
                ContactTypeID = GetCharacterContactTypeId(x.ContactType),
            }).ToList();

            return new Collection<SerializableContactListItem>(mapped);

        }

        private long GetCharacterContactTypeId(GetCharactersCharacterIdContacts200Ok.ContactTypeEnum contactType)
        {
            switch (contactType)
            {
                case GetCharactersCharacterIdContacts200Ok.ContactTypeEnum.Character:
                    return DBConstants.CharacterAmarrID; //assume this one, theres really a range
                case GetCharactersCharacterIdContacts200Ok.ContactTypeEnum.Corporation:
                    return DBConstants.CorporationID;
                case GetCharactersCharacterIdContacts200Ok.ContactTypeEnum.Alliance:
                    return DBConstants.AllianceID;
                case GetCharactersCharacterIdContacts200Ok.ContactTypeEnum.Faction:
                    return DBConstants.AllianceID; //also fudging this one
                default:
                    throw new ArgumentOutOfRangeException(nameof(contactType), contactType, null);
            }
        }

        private Collection<SerializableContactListItem> GetCorpContacts(int characterId, string dataSource, string accessToken)
        {
            var contacts = GetAllPages(page => _contactsApi.GetCorporationsCorporationIdContactsWithHttpInfo(characterId, dataSource, page, accessToken)).ToList();
            var factionNames = GetFactionNames(dataSource);
            var names = GetNames(contacts.Where(x => x.ContactType != GetCorporationsCorporationIdContacts200Ok.ContactTypeEnum.Faction).Select(x => x.ContactId).ToList(), dataSource);

            var mapped = contacts.Select(x => new SerializableContactListItem
            {
                Standing = x.Standing.GetValueOrDefault(),
                ContactID = x.ContactId.GetValueOrDefault(),
                InWatchlist = x.IsWatched.GetValueOrDefault(),
                Group = ContactGroup.Corporate,
                //Yea gross because normal universe names api doesnt handle factions
                ContactName = x.ContactType == GetCorporationsCorporationIdContacts200Ok.ContactTypeEnum.Faction ? factionNames[x.ContactId.GetValueOrDefault()] : names[x.ContactId.GetValueOrDefault()],
                ContactTypeID = GetCorpContactTypeId(x.ContactType),
            }).ToList();

            return new Collection<SerializableContactListItem>(mapped);
        }

        private long GetCorpContactTypeId(GetCorporationsCorporationIdContacts200Ok.ContactTypeEnum contactType)
        {
            switch (contactType)
            {
                case GetCorporationsCorporationIdContacts200Ok.ContactTypeEnum.Character:
                    return DBConstants.CharacterAmarrID; //assume this one, theres really a range
                case GetCorporationsCorporationIdContacts200Ok.ContactTypeEnum.Corporation:
                    return DBConstants.CorporationID;
                case GetCorporationsCorporationIdContacts200Ok.ContactTypeEnum.Alliance:
                    return DBConstants.AllianceID;
                case GetCorporationsCorporationIdContacts200Ok.ContactTypeEnum.Faction:
                    return DBConstants.AllianceID; //also fudging this one
                default:
                    throw new ArgumentOutOfRangeException(nameof(contactType), contactType, null);
            }
        }

        private Collection<SerializableContactListItem> GetAllianceContacts(int characterId, string dataSource, string accessToken)
        {
            var contacts = GetAllPages(page => _contactsApi.GetAlliancesAllianceIdContactsWithHttpInfo(characterId, dataSource, page, accessToken)).ToList();
            var factionNames = GetFactionNames(dataSource);
            var names = GetNames(contacts.Where(x => x.ContactType != GetAlliancesAllianceIdContacts200Ok.ContactTypeEnum.Faction).Select(x => x.ContactId).ToList(), dataSource);

            var mapped = contacts.Select(x => new SerializableContactListItem
            {
                Standing = x.Standing.GetValueOrDefault(),
                ContactID = x.ContactId.GetValueOrDefault(),
                InWatchlist = false,
                Group = ContactGroup.Corporate,
                //Yea gross because normal universe names api doesnt handle factions
                ContactName = x.ContactType == GetAlliancesAllianceIdContacts200Ok.ContactTypeEnum.Faction ? factionNames[x.ContactId.GetValueOrDefault()] : names[x.ContactId.GetValueOrDefault()],
                ContactTypeID = GetAllianceContactTypeId(x.ContactType),
            }).ToList();

            return new Collection<SerializableContactListItem>(mapped);
        }

        private long GetAllianceContactTypeId(GetAlliancesAllianceIdContacts200Ok.ContactTypeEnum contactType)
        {
            switch (contactType)
            {
                case GetAlliancesAllianceIdContacts200Ok.ContactTypeEnum.Character:
                    return DBConstants.CharacterAmarrID; //assume this one, theres really a range
                case GetAlliancesAllianceIdContacts200Ok.ContactTypeEnum.Corporation:
                    return DBConstants.CorporationID;
                case GetAlliancesAllianceIdContacts200Ok.ContactTypeEnum.Alliance:
                    return DBConstants.AllianceID;
                case GetAlliancesAllianceIdContacts200Ok.ContactTypeEnum.Faction:
                    return DBConstants.AllianceID; //also fudging this one
                default:
                    throw new ArgumentOutOfRangeException(nameof(contactType), contactType, null);
            }
        }

        //Yea apparently the universe api doesnt handle alliances that are factions?
        private Dictionary<int, string> GetFactionNames(string dataSource)
        {
            var factions = _universeApi.GetUniverseFactions(dataSource);

            return factions
                .ToDictionary(x => x.FactionId.GetValueOrDefault(), x => x.Name);
        }

        private Dictionary<int, string> GetNames(List<int?> ids, string dataSource)
        {
            //Endpoint maxes out at 1k ids passed
            var chunkedIds = ids.ChunkBy(1000);

            //TODO: dont like using swaggger classes
            var names = new List<PostUniverseNames200Ok>();

            foreach (var chunk in chunkedIds)
            {
                var namesResult = _universeApi.PostUniverseNames(chunk, dataSource);

                names.AddRange(namesResult);
            }

            return names
                .Where(x => x.Category == PostUniverseNames200Ok.CategoryEnum.Corporation || x.Category == PostUniverseNames200Ok.CategoryEnum.Alliance || x.Category == PostUniverseNames200Ok.CategoryEnum.Character)
                .Where(x => x.Id.HasValue)
                .ToDictionary(x => x.Id.GetValueOrDefault(), x => x.Name);

        }

        private IEnumerable<T> GetAllPages<T>(Func<int, ApiResponse<List<T>>> apiCall)
        {
            var pages = 1;
            for (var i = 1; i <= pages; i++)
            {
                var call = apiCall(i);

                call.Headers.TryGetValue("X-Pages", out var pagesString);
                int.TryParse(pagesString, out pages);
                foreach (var item in call.Data)
                {
                    yield return item;
                }
            }
        }
    }
}
