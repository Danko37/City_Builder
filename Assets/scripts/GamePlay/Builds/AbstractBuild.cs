using System.Collections;
using UnityEngine;

public abstract class AbstractBuild : MonoBehaviour
{    
    public bool isReady;//добыча завершена
    //лимит накопления здания
    public int accumulationLimit;
    public int accumulation;

    public Resourses Resourses;//указатель на панель ресурсов

    public int Lvl { get; set; }
    public int Price { get; set; }
    public int Build_time { get; set; }
    public float Performance { get; set; }
    
    public void ProductionStart()
    {
        StartCoroutine("ResourcesOperation");
    }
    public abstract IEnumerator ResourcesOperation();//коротин добычи ресурсов

    public virtual void OnMouseDown()
    {
        
    }

 
}
