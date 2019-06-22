using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gas_silos : AbstractBuild
{
    public gas_silos(int l = 1, int p = 150, int bT = 180, float per = 300):base(l,p,bT,per)
    {
       
    }
    public override IEnumerator ResourcesOperation()
    {
        accumulation = 300;
        Resourses.Set_GasLimit(accumulation);
        yield return null;
    }
    
}

