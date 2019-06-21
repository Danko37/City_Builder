using System.Collections;
using UnityEngine;

public abstract class AbstractBuild : MonoBehaviour
{
    public bool isReady;//добыча завершена

    //лимит накопления здания
    public int accumulationLimit;
    public int accumulation;

    public Resourses Resourses;

    public int Lvl { get; set; }
    public int Price { get; set; }
    public int Build_time { get; set; }
    public float Performance { get; set; }
    public AbstractBuild(int l, int p, int bT, float per)
    {  
        Lvl = l;
        Price = p;
        Build_time = bT;
        Performance = per;
    }
 
    public void ProductionStart()
    {
        StartCoroutine("ResourcesOperation");
    }
    public virtual IEnumerator ResourcesOperation()//коротин добычи ресурсов
   {
    yield return null;
   }
    public virtual void OnMouseDown()
    {
        
    }
    void Start()
    {
        Resourses = FindObjectOfType<Resourses>();   
        StartCoroutine("ResourcesOperation");
    }

}
