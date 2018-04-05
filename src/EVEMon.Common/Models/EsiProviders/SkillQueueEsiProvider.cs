using System;
using System.Collections.Generic;
using System.Linq;
using EVEMon.Common.Collections;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;

namespace EVEMon.Common.Models.EsiProviders
{
    public class SkillQueueEsiProvider : IEsiProvider<SerializableAPISkillQueue>
    {
        private readonly ISkillsApi _skillsApi;

        public Enum Provides { get; } = CCPAPICharacterMethods.SkillQueue;

        public SkillQueueEsiProvider()
        {
            _skillsApi = new SkillsApi();
        }

        public CCPAPIResult<SerializableAPISkillQueue> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var characterId = int.Parse(legacyPostData["characterID"]);

            var result = new CCPAPIResult<SerializableAPISkillQueue>
            {
                Result = new SerializableAPISkillQueue()
            };

            result.Result.Queue.Clear();
            result.Result.Queue.AddRange(GetSkillQueue(characterId, dataSource, accessToken));

            return result;
        }

        private IEnumerable<SerializableQueuedSkill> GetSkillQueue(int characterId, string dataSource, string accessToken)
        {
            var queue = _skillsApi.GetCharactersCharacterIdSkillqueue(characterId, dataSource, accessToken).OrderBy(x => x.QueuePosition.GetValueOrDefault()).Select(x =>
                new SerializableQueuedSkill
                {
                    ID = x.SkillId.GetValueOrDefault(),
                    Level = x.FinishedLevel.GetValueOrDefault(),
                    StartTime = x.StartDate.GetValueOrDefault(),
                    EndTime = x.FinishDate.GetValueOrDefault(),
                    EndSP = x.LevelEndSp.GetValueOrDefault(),
                    //This is not trainingstartsp (I dont know what thats for, progress?)
                    StartSP = x.LevelStartSp.GetValueOrDefault()
                }).ToList();
            return queue;
        }

    }
}
