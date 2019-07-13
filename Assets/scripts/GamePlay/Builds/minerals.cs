using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class minerals : AbstractBuild
{
    
    void Start()
    {
        Lvl = 1;
        Price = 100;
        Build_time = 60;
        Performance = 20;

        if (gameObject.GetComponent<MeshRenderer>())
        {
            Resourses = FindObjectOfType<Resourses>();
            StartCoroutine("ResourcesOperation");
        }
    }
    public override IEnumerator ResourcesOperation()
    {
        accumulation = 0;
        accumulationLimit = (int)Performance;

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
    public override void OnMouseDown()
    {
        if (isReady && !(int.Parse(Resourses._mineralsValue.text) + accumulation > int.Parse(Resourses.mineralsLimit.text)))
        {
            Resourses.Set_Minerals(accumulation);
            GetComponent<Renderer>().material.color = Color.white;
            isReady = false;
            StartCoroutine("ResourcesOperation");
        }
        else
        {
            Debug.Log("MineralsLimit");
        }
    }
    
}
