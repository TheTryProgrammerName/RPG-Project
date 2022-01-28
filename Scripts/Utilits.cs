using UnityEngine;
using System.Collections.Generic;

public class Utilits
{
    public Queue<GameObject> GetChildren(Transform ParentTransform)
    {
        try
        {
            Queue<GameObject> Children = new Queue<GameObject>();

            foreach (Transform child in ParentTransform)
            {
                Children.Enqueue(child.gameObject);
            }

            return Children;
        }
        catch
        {
            if (ParentTransform == null)
            {
                Debug.LogError("Не присвоено значение ParentTransform");
            }
            else
            {
                Debug.LogError("Неизвестная ошибка");
            }
        }

        return null;
    }

    public Vector2 Vector3ToVector2(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.y);
    }
}
