using UnityEngine;
using UnityEngine.UI;
public class Resourses : MonoBehaviour
{

    //текущее значение ресурсов и их лимит
    #region Resourses    
    public Text _gasValue;
    public Text _mineralsValue;
    public Text gasLimit;
    public Text mineralsLimit;
    #endregion   
    //начальное значение ресурсов
    void Start()
    {
        _gasValue.text = "150";
        _mineralsValue.text = "150";

        gasLimit.text = "150";
        mineralsLimit.text = "150";
    }
    //методы изменения показателей ресурсов
    public void Set_Gas(int v)
    {
        int valueInt = int.Parse(_gasValue.text);
        valueInt += v;
        _gasValue.text = valueInt.ToString();
    }
    public void Set_GasLimit(int v)
    {
        int valueInt = int.Parse(gasLimit.text);
        valueInt += v;
        gasLimit.text = valueInt.ToString();
    }
    public void Set_Minerals(int v)
    {
        int valueInt = int.Parse(_mineralsValue.text);
        valueInt += v;
        _mineralsValue.text = valueInt.ToString();
    }
    public void Set_MineralsLimit(int v)
    {
        int valueInt = int.Parse(mineralsLimit.text);
        valueInt += v;
        mineralsLimit.text = valueInt.ToString();
    }
}
