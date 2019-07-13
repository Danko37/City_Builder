using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gas : AbstractBuild
{
    void Start()
    {
        Lvl = 1;
        Price = 125;
        Build_time = 120;
        Performance = 10;

        if (gameObject.GetComponent<MeshRenderer>())//если строится именно здание
        {
            isReady = false;
            Resourses = FindObjectOfType<Resourses>();
            StartCoroutine("ResourcesOperation");
        }
    }


    public override IEnumerator ResourcesOperation()//добыча ресурсов
    {
        accumulation = 0;
        accumulationLimit = (int)Performance;

        while (accumulation < accumulationLimit)
        {
            yield return new WaitForSeconds(1);
            accumulation++;
            Debug.Log("Gas "+accumulation);
        }
            isReady = true;
            GetComponent<Renderer>().material.color = Color.green;             
    }

    public override void OnMouseDown()//собираем ресурс
    {
        if (isReady && !(int.Parse(Resourses._gasValue.text) + accumulation > int.Parse(Resourses.gasLimit.text)))
        {
            Resourses.Set_Gas(accumulation);           
            GetComponent<Renderer>().material.color = Color.white;
            isReady = false;
            StartCoroutine("ResourcesOperation");
        }
        else 
        {         
            Debug.Log("GasLimit");         
        }      
    }
   
   
}
