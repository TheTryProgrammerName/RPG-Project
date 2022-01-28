using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Health _health = new Health();

    private void Start()
    {
        _health.Value = 130;

        StartCoroutine("Test2");
    }

    private IEnumerator Test2()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            _health.Value--;
            Debug.Log(_health.Value);
        }
    }
}
