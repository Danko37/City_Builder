using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractShopBtn : MonoBehaviour
{  //события показа информации и выбора постройки в магазине
    public event Action<AbstractBuild> ShowInfo;
    public event Action<AbstractBuild> Select;

    public AbstractBuild build { get; set; }//тип здания, хронящийся в ячейке магазина

    public virtual void SetBuild()
    {

    }
    void Start()
    {
        SetBuild();

    }
    public void OnClik()//обработчик события нажатия на ячейку в магазине
    {
        ShowInfo(build);
        Select(build);
    }

}
