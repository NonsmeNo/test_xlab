using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{

    [CreateAssetMenu(fileName = "LevelSettings", menuName = "LevelSettings")]
    public class LevelSettings : ScriptableObject
    {
        public float stoneFallDelay = 2f;

        
        [SerializeField] private int level;
        
    }
}
