using UnityEngine;

namespace MapSystem
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private MapScroller _mapScroller;
        [SerializeField] private CoordinatesConvertor _coordinatesConvertor;
        [SerializeField] private Character _character;

        public void Initialize()
        {
            _mapScroller.Initialize();
        }

        public void ScrollMap(float scrollValue)
        {
            _mapScroller.Scroll(scrollValue);
        }

        public void MoveCharacter(Vector3 position)
        {
            Vector3 CharacterRealMapPos = _coordinatesConvertor.UICoordinatesToMapCoordinates(position);
            _character.Move(CharacterRealMapPos);
        }
    }
}
