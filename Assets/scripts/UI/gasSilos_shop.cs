using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gasSilos_shop : AbstractShopBtn
{

    public override void SetBuild()
    {
        build = new GameObject("gasSilosAbstract").AddComponent<gas_silos>();
    }
}
