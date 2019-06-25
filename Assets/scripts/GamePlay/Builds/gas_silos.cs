using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gas_silos : AbstractBuild
{
    void Start()
    {
        Lvl = 1;
        Price = 150;
        Build_time = 3;
        Performance = 300;

        if (gameObject.GetComponent<MeshRenderer>())
        {
            Resourses = FindObjectOfType<Resourses>();
            StartCoroutine("ResourcesOperation");
        }
    }
    public override IEnumerator ResourcesOperation()
    {
        accumulation = 300;
        Resourses.Set_GasLimit(accumulation);
        yield return null;
    }
    
}

