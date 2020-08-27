using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAni
{
    [System.Serializable]
    public struct AniValue
    {
        public float x;
        public float y;
        public float z;

        public AniValue(float x,float y,float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public AniValue Add(AniValue aniValue) 
        { 
            return new AniValue(this.x + aniValue.x, this.y + aniValue.y, this.z + aniValue.z);
        }
    }

    [System.Serializable]
    public class EAniPart
    {
        public int GroupId;
        public int PartId;
        public AniValue Pos;
        public AniValue Rot;
        public EAniPart Parent;

        public GameObject BindGO;

        public void Show()
        {
            if (BindGO != null)
            {
                BindGO.transform.localPosition = new Vector3(Pos.x, Pos.y, Pos.z);
                BindGO.transform.eulerAngles = new Vector3(Rot.x, Rot.y, Rot.z);
            }
        }
        
        public AniValue GetPos()
        {
            //if (Parent != null)
            //{
            //    return Pos.Add(Parent.GetPos());
            //}
            return Pos;
        }

        public AniValue GetRot()
        {
            //if (Parent != null)
            //{
            //    return Pos.Add(Parent.GetRot());
            //}
            return Pos;
        }
    }
}

