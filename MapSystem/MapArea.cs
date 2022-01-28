using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem
{
    public class MapArea : MonoBehaviour
    {
        [SerializeField] private string _zoneName;

        private LtxReader ltxReader;

        public void Initialize()
        {
            ltxReader = new LtxReader();
            //Подгружать параметры зоны
        }
    }
}
