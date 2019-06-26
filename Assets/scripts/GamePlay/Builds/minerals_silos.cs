using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minerals_silos : AbstractBuild
{

    
    void Start()
    {
        Lvl = 1;
        Price = 150;
        Build_time = 120;
        Performance = 200;

        if (gameObject.GetComponent<MeshRenderer>())
        {
            Resourses = FindObjectOfType<Resourses>();
            StartCoroutine("ResourcesOperation");
        }
    }
    public override IEnumerator ResourcesOperation()
    {
        accumulation = 200;
        Resourses.Set_MineralsLimit(accumulation);
        yield return null;
    }
  
}
