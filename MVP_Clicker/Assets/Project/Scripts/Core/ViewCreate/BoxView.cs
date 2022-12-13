using UnityEngine;

namespace Project.Scripts.Core.ViewCreate
{
    public class BoxView<T> : IBoxView<T> where T : MonoBehaviour
    {
        public T View { get; }

        public BoxView(T view)
        {
            View = view;
        }

        public void Destroy()
        {
            GameObject.Destroy(View);
        }
    }
}