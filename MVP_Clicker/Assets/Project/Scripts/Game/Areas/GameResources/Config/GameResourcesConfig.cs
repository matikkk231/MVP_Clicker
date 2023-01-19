using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResource.Config;
using UnityEngine;

namespace Project.Scripts.Game.Areas.GameResources.Config
{
    [CreateAssetMenu(fileName = "NewGameResourcesCollection",
        menuName = "ScriptableObjects/GameResources/GameResourcesCollection")]
    public class GameResourcesConfig : ScriptableObject, IGameResourcesConfig
    {
        [SerializeField] private List<GameResourceConfig> _collectionOfGameResourcesConfigs;

        private IDictionary<string, IGameResourceConfig> _dictionaryWithConfigs;

        public IDictionary<string, IGameResourceConfig> CollectionOfGameResources
        {
            get
            {
                ConvertListToDictionary(_collectionOfGameResourcesConfigs);
                return _dictionaryWithConfigs;
            }
        }

        private void ConvertListToDictionary(List<GameResourceConfig> list)
        {
            _dictionaryWithConfigs = new Dictionary<string, IGameResourceConfig>();
            foreach (var resource in list)
            {
                _dictionaryWithConfigs.Add(resource.Id, resource);
            }
        }
    }
}