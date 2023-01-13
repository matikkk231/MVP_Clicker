namespace Project.Scripts.Game.Areas.Bonus.Data
{
    public interface IBonusData
    {
        public int BonusLevel { get; set; }
        public int UpgradeValue { get; set; }
        public int ProvidingBonus { get; set; }
        public string Id { get; set; }
    }
}