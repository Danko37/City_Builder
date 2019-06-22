﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minerals_silos : AbstractBuild
{

   
    public minerals_silos(int l = 1, int p = 150, int bT = 120, float per = 200):base(l,p,bT,per)
    {
       
    }
    public override IEnumerator ResourcesOperation()
    {
        accumulation = 200;
        Resourses.Set_MineralsLimit(accumulation);
        yield return null;
    }
  
}