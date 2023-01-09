namespace Project.Scripts.Game.BonusesId
{
    public class BonusesId : IBonusesId
    {
        public string Sword { get; set; }

        public BonusesId(string sword)
        {
            Sword = sword;
        }
    }
}