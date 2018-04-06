using System;
using System.Collections.Generic;
using System.Linq;
using EVEMon.Common.Enumerations.CCPAPI;
using EVEMon.Common.Serialization.Eve;

using IO.Swagger.Api;

namespace EVEMon.Common.Models.EsiProviders
{
    public class SkillInTrainingEsiProvider : IEsiProvider<SerializableAPISkillInTraining>
    {
        private readonly ISkillsApi _skillsApi;

        public Enum Provides { get; } = CCPAPICharacterMethods.SkillInTraining;

        public SkillInTrainingEsiProvider()
        {
            _skillsApi = new SkillsApi();
        }

        public CCPAPIResult<SerializableAPISkillInTraining> Invoke(Dictionary<string, string> legacyPostData, string dataSource, string accessToken)
        {
            var characterId = int.Parse(legacyPostData["characterID"]);

            //TODO: handle empty skill queue

            var firstQueueSkill = _skillsApi.GetCharactersCharacterIdSkillqueue(characterId, dataSource, accessToken)
                .OrderBy(x => x.QueuePosition.GetValueOrDefault()).First();

            var result = new CCPAPIResult<SerializableAPISkillInTraining>
            {
                Result = new SerializableAPISkillInTraining
                {
                    SkillInTraining = (byte) (firstQueueSkill.StartDate.HasValue ? 1 : 0),
                    StartTime = firstQueueSkill.StartDate.GetValueOrDefault(),
                    EndTime = firstQueueSkill.FinishDate.GetValueOrDefault(),
                    TrainingTypeID = firstQueueSkill.SkillId.GetValueOrDefault(),
                    //I think this is the right value?
                    TrainingStartSP = firstQueueSkill.LevelStartSp.GetValueOrDefault(),
                    TrainingDestinationSP = firstQueueSkill.LevelEndSp.GetValueOrDefault(), 
                    TrainingToLevel = (byte) firstQueueSkill.FinishedLevel.GetValueOrDefault(),
                    //Dont bother with tqtime, or trainingtime
                }
            };

            return result;
        }
    }
}
