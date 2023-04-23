using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public enum AnimState
    {
        Idel = 0,
        Run = 1,
        Jump = 2
    }

    [CreateAssetMenu(fileName ="SpriteAnimatorCfg", menuName ="Configs / Animation", order = 1)]
    public class AnimationConfig : ScriptableObject
    {
        [Serializable]
        public class SpiteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites= new List<Sprite>();
        }

        public List<SpiteSequence> Sequences = new List<SpiteSequence>();
    }
}