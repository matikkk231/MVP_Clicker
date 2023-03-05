using System.Collections.Generic;
using Project.Scripts.Game.Areas.Achievement;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Achievements.Config
{
    [CreateAssetMenu(fileName = "CollectionOfAchievements", menuName = "ScriptableObjects/CollectionOfAchievements")]
    public class AchievementsConfig : ScriptableObject, IAchievementsConfig
    {
        [SerializeField] private List<AchievementConfig> _collection;

        public List<IAchievementConfig> Collection
        {
            get
            {
                var listOfInterfaces = new List<IAchievementConfig>();
                foreach (var config in _collection)
                {
                    listOfInterfaces.Add(config);
                }

                return listOfInterfaces;
            }
        }
    }
}