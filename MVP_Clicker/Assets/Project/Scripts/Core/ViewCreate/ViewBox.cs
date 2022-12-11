using UnityEngine;

namespace Project.Scripts.Core.ViewCreate
{
    public class ViewBox<T> : IViewBox<T> where T : MonoBehaviour
    {
        public T GetView { get; }

        public ViewBox(T view)
        {
            GetView = view;
        }
    }
}