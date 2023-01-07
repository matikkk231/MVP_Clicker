using Project.Scripts.Game.Areas.GameResource.Config;
using UnityEngine;

namespace Project.Scripts.Game.Areas.GameResources.Config
{
    [CreateAssetMenu(fileName = "NewGameResourcesCollection", menuName = "ScriptableObjects/GameResources/GameResourcesCollection")]
    public class GameResourcesConfig : ScriptableObject, IGameResourcesConfig
    {
        [SerializeField] private GameResourceConfig _money;
        [SerializeField] private GameResourceConfig _damagePerTap;

        public IGameResourceConfig Money => _money;
        public IGameResourceConfig DamagePerTap => _damagePerTap;
    }
}