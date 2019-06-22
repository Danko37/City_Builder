using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gas : AbstractBuild
{
    public Gas(int l = 1, int p = 125, int bT = 120, float per = 10) : base(l, p, bT, per)
    {       
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
