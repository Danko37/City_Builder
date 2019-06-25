using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minerals : AbstractBuild
{   
    void Start()
    {
        Lvl = 1;
        Price = 100;
        Build_time = 3;
        Performance = 20;
        if (gameObject.GetComponent<MeshRenderer>())
        {
            Resourses = FindObjectOfType<Resourses>();
            StartCoroutine("ResourcesOperation");
        }
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
