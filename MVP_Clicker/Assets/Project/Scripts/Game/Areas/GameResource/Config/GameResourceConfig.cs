using UnityEngine;

namespace Project.Scripts.Game.Areas.GameResource.Config
{
    [CreateAssetMenu(fileName = "NewGameResource", menuName = "ScriptableObjects/GameResources/GameResource")]
    public class GameResourceConfig : ScriptableObject, IGameResourceConfig
    {
        [SerializeField] private int _startAmount;
        [SerializeField] private string _id;

        public int StartAmount => _startAmount;
        public string Id => _id;
    }
}