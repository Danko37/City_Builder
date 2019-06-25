﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gas : AbstractBuild
{  
    void Start()
    {
        Lvl = 1;
        Price = 125;
        Build_time = 3;
        Performance = 10;
        if (gameObject.GetComponent<MeshRenderer>())
        {
            Resourses = FindObjectOfType<Resourses>();
            StartCoroutine("ResourcesOperation");
        }
    }

    public override void OnMouseDown()//собираем ресурс
    {
        if (isReady && !(int.Parse(Resourses._gasValue.text) + accumulation > int.Parse(Resourses.gasLimit.text)))
        {
            Resourses.Set_Gas(accumulation);           
            GetComponent<Renderer>().material.color = Color.white;
            StartCoroutine("ResourcesOperation");
        }
        else
        {
            Debug.Log("GasLimit");
        }      
    }

    public override IEnumerator ResourcesOperation()//добыча ресурсов
    {
        Debug.Log("startGas");
        accumulation = 0;
        accumulationLimit = 10;
        while (accumulation < accumulationLimit)
        {
            yield return new WaitForSeconds(1);
            accumulation++;
            Debug.Log("Gas "+accumulation);
        }
        if (accumulation >= accumulationLimit)
        {
            isReady = true;
            GetComponent<Renderer>().material.color = Color.green;
        }       
    }

   
   
}
