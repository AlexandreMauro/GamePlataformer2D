using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singelton;
public class VFXManager : Singelton<VFXManager>
{
    public enum VFXType
    {
        Jump,
        VFX2
    }

    public List<VFXManagerSetup> VFXListManagerSetup;

    public void PlayFVXByType(VFXType vfxType, Vector3 position)
    {
        foreach(var i in VFXListManagerSetup)
        {
            if(i.Type == vfxType )
            {
                var item = Instantiate(i.pfefab);
                item.transform.position = position;
                break;

            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType Type;
    public GameObject pfefab;
    

         
}

