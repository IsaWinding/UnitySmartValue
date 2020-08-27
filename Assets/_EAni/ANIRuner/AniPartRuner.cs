using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EAni
{
    public enum AniType
    { 
        Once = 1,
        Loop = 2,
        PingPong = 3,
    }
    public class AniPartRuner
    {
        public AniValue StartPos;
        public AniValue EndPos;
        public AniValue StartRot;
        public AniValue EndRot;

        private float curProgress;

        
    }
}

