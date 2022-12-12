using Project.Scripts.Game.Areas.Models.Monster;
using Project.Scripts.Game.Areas.Views.Monster;

namespace Project.Scripts.Game.Areas.Presenters
{
    public interface IMonsterPresenter
    {
        public IMonsterModel GetMonsterModel { get; }
        public IMonsterView GetMonsterView { get; }
    }
}