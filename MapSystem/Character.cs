using System.Collections;
using UnityEngine;

namespace MapSystem
{
    public class Character : MonoBehaviour, IMovevable
    {
        private float _moveSpeed = 2.0f;

        public void Move(Vector3 position)
        {
            StopAllCoroutines();
            StartCoroutine(MoveCoroutine(position));
        }

        private IEnumerator MoveCoroutine(Vector3 MovePoint)
        {
            while (transform.localPosition != MovePoint)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, MovePoint, _moveSpeed);

                yield return new WaitForFixedUpdate();
            }

            yield break;
        }
    }
}