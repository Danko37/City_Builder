using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gas_shop : AbstractShopBtn
{
    public override void SetBuild()
    {
        build = new GameObject("GasAbstract").AddComponent<Gas>();
    }
}
