using System.Collections.Generic;
using Project.Scripts.Game.Areas.Resource.View;
using UnityEngine;

namespace Project.Scripts.Game.Areas.GameResources.View
{
    public class GameResourcesView : MonoBehaviour, IGameResourcesView
    {
        [SerializeField] private GameResourceView _prefab;
        [SerializeField] private GameObject _resourcesParent;

        public IDictionary<string, IGameResourceView> CollectionOfGameResources { get; set; }

        public IGameResourceView CreateView()
        {
            var view = Instantiate(_prefab, _resourcesParent.transform, true);
            return view;
        }
    }
}