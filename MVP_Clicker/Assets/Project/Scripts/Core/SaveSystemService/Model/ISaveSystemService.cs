namespace Project.Scripts.Game.Areas.SaveSystem
{
    public interface ISaveSystemService
    {
        public void SaveData<T>(T data);
        public T LoadData<T>();
    }
}