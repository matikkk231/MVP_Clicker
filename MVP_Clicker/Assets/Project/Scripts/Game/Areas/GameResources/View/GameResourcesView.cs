using Project.Scripts.Game.Areas.Resource.View;
using UnityEngine;

namespace Project.Scripts.Game.Areas.GameResources.View
{
    public class GameResourcesView : MonoBehaviour, IGameResourcesView
    {
        [SerializeField] private GameResourceView _money;
        [SerializeField] private GameResourceView _damagePerTap;

        public IGameResourceView Money => _money;
        public IGameResourceView DamagePerTap => _damagePerTap;
    }
}