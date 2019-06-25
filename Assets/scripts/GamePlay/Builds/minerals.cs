using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minerals : AbstractBuild
{
    public minerals(int l = 1, int p = 100, int bT = 3 , float per = 20) 
    {
        Lvl = l;
        Price = p;
        Build_time = bT;
        Performance = per;
    }
    public override void OnMouseDown()
    {
        if (isReady && !(int.Parse(Resourses._mineralsValue.text) + accumulation > int.Parse(Resourses.mineralsLimit.text)))
        {
            Resourses.Set_Minerals(accumulation);
            GetComponent<Renderer>().material.color = Color.white;
            StartCoroutine("ResourcesOperation");
        }
        else
        {
            Debug.Log("MineralsLimit");
        }
    }
    
    public override IEnumerator ResourcesOperation()
    {
        accumulation = 0;
        accumulationLimit = 20;
        while (accumulation < accumulationLimit)
        {
            yield return new WaitForSeconds(1.5f);
            accumulation++;
            Debug.Log("Minerals" + accumulation);
        }
        if (accumulation >= accumulationLimit)
        {
            isReady = true;
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
