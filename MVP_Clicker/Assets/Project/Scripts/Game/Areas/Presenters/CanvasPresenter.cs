using System;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Models.Canvas;
using Project.Scripts.Game.Areas.Views.Canvas;

namespace Project.Scripts.Game.Areas.Presenters
{
    public class CanvasPresenter: IDisposable

    {
    private readonly ICanvasModel _canvasModel;
    private readonly IViewBox<ICanvasView> _canvasViewBox;

    public CanvasPresenter(IViewCreate<ICanvasView> canvasView, ICanvasModel canvasModel)
    {
        _canvasModel = canvasModel;
        _canvasViewBox = canvasView.CreateObject();
    }


    public void Dispose()
    {
    }
    }
}