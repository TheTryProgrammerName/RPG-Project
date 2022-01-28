using UnityEngine;

namespace MapSystem
{
    public class CoordinatesConvertor : MonoBehaviour
    {
        [SerializeField] private RectTransform _mapContent;

        public Vector3 UICoordinatesToMapCoordinates(Vector3 touchPosition)
        {
            return -_mapContent.position + touchPosition;
        }

        public Vector3 MapCoordinatesToUICoordinates()
        {
            return Vector3.zero;//-_mapContent.position + touchPosition;
        }
    }
}