using System;
using System.Collections.Generic;
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

            //TODO: query skillqueue and look at the first item if there is a start and end date then its currently training

            var result = new CCPAPIResult<SerializableAPISkillInTraining>
            {
                Result = new SerializableAPISkillInTraining
                {
                    
                }
            };

            return result;
        }
    }
}
