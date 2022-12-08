using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Views.CameraView;
using UnityEngine;

namespace Project.Scripts.Game.Base.GameViews
{
    public interface IGameViews
    {
        IViewCreate<ICameraView> Camera { get; }
    }
}