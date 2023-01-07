namespace Project.Scripts.Game.Areas.Bonus.Config
{
    public interface IBonusConfig
    {
        public  int StartBonusLevel { get; }
        public int StartUpgradeValue { get; }
        public int StartProvidingDamagePerTapBonus { get; }
        public string Id { get; }
    }
}