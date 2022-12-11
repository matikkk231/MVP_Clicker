using Project.Scripts.Game.Base.GameModels;
using Project.Scripts.Game.Base.GamePresenters;
using Project.Scripts.Game.Base.GameViews;
using UnityEngine;

namespace Project.Scripts.Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameViews _views;

        private GameModels _models;

        private GamePresenter _presenters;

        void Start()
        {
            _models = new GameModels();
            _presenters = new GamePresenter(_models, _views);
        }

        private void OnDestroy()
        {
            _presenters.Dispose();
        }
    }
}