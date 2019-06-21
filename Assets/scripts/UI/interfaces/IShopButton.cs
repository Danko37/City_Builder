using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopButton
{
    event Action<AbstractBuild, bool> ShowInfo;
    void OnClik();
    bool isPurchased { get; set; }
}
