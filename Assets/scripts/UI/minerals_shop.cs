using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class minerals_shop : AbstractShopBtn
{ 
    public override void SetBuild()
    {
        build = new GameObject("MineralsAbstract").AddComponent<minerals>() as minerals;
    }
}
