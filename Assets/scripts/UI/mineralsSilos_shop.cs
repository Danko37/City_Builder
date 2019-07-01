using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mineralsSilos_shop : AbstractShopBtn
{

    public override void SetBuild()
    {
        build = new GameObject("mineralsSilosAbstract").AddComponent<minerals_silos>();
    }

}
