using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsMover : MonoBehaviour
{
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private Transform _characterUITransform;

    //Не апдлейтить это каждый кадр, а только когда ГГ движется
    private void Update()
    {
        
    }
}
