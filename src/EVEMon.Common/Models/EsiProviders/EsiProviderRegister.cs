using System;
using System.Collections.Generic;
using System.Linq;

namespace EVEMon.Common.Models.EsiProviders
{
    public class EsiProviderRegister
    {
        private readonly ICollection<IEsiProvider> _apiProviders;

        public EsiProviderRegister()
        {
            _apiProviders = new List<IEsiProvider>
            {
                //CCPAPICharacterMethods
                new CharacterInfoEsiProvider(),
                new StandingsEsiProvider(),
                new SkillQueueEsiProvider(),
                new SkillInTrainingEsiProvider(),
                //CCPAPIGenericMethods
                new ServerStatusEsiProvider(),
                new ConquerableStationListEsiProvider(),
                new CharacterNameEsiProvider()
            };
        }

        public IEsiProvider<T> GetProviderFor<T>(Enum method)
        {
            var result = _apiProviders.SingleOrDefault(x => Equals(method, x.Provides));
            return result as IEsiProvider<T>;
        }
    }
}