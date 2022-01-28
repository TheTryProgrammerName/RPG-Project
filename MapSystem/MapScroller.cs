using UnityEngine;
using UnityEngine.UI;

namespace MapSystem
{
    public class MapScroller : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _mapGrid;
        [SerializeField] private Transform _characterTransform;

        private float _minMapSize = 1f;
        private float _maxMapSize = 2f;
        private float _curentMapSize = 1f;
        private Vector2 _mapGridCellSize;
        private Vector2 _characterTransformSize;

        public void Initialize()
        {
            _mapGridCellSize = _mapGrid.cellSize;
            _characterTransformSize = _characterTransform.localScale;
        }

        public void Scroll(float scrollValue)
        {
            _curentMapSize = _curentMapSize + scrollValue;

            if (_curentMapSize < _minMapSize)
            {
                _curentMapSize = _minMapSize;
            }

            if (_curentMapSize > _maxMapSize)
            {
                _curentMapSize = _maxMapSize;
            }

            _mapGrid.cellSize = _mapGridCellSize * _curentMapSize;
            _characterTransform.localScale = _characterTransformSize * _curentMapSize;
        }
    }
}