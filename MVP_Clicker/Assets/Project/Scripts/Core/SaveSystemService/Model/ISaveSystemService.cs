using Project.Scripts.Game.Base.GameData;

namespace Project.Scripts.Game.Areas.SaveSystem
{
    public interface ISaveSystemService
    {
        public void SaveData(IGameData data);
        public IGameData LoadData();
    }
}