using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Views.CameraView;
using Project.Scripts.Game.Areas.Views.Canvas;
using UnityEngine;

namespace Project.Scripts.Game.Base.GameViews
{
    public interface IGameViews
    {
        IViewCreate<ICameraView> CameraView { get; }
        IViewCreate<ICanvasView> CanvasView { get;}
    }
}