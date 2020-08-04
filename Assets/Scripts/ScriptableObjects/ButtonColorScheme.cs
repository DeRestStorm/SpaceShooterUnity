using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ButtonColorScheme", menuName = "ButtonColorScheme", order = 0)]
    public class ButtonColorScheme : ScriptableObject
    {
        public Color Passed = Color.green;
        public Color Сlosed = Color.gray;
        public Color Opened = Color.yellow;
    }
}