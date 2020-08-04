using UnityEngine;

namespace Helpers
{
    public class CameraHelper
    {
        private Camera _camera;

        public CameraHelper(Camera camera)
        {
            _camera = camera;
        }

        public float GetWidth()
        {
            return GetHeight() * Screen.width / Screen.height;
        }

        public float GetHeight()
        {
            return _camera.orthographicSize * 2;
        }
    }
}