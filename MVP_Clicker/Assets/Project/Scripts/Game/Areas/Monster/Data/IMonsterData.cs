namespace Project.Scripts.Game.Areas.Monster.Data
{
    public interface IMonsterData
    {
        public int CurrentHp { get; set; }
        public int FullHp { get; set; }
        public int RewardForKilling { get; set; }
    }
}