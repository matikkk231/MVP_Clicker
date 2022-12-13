using Project.Scripts.Game.Areas.Resource.View;
using UnityEngine;

namespace Project.Scripts.Game.Areas.GameResources.View
{
    public class GameResourcesView : MonoBehaviour, IGameResourcesView
    {
        [SerializeField] private GameResourceView _money;
        
        public IGameResourceView Money => _money;
    }
}