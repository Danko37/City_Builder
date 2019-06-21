using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// инфопанель в магазине
/// </summary>
public class ShopInfo : MonoBehaviour
{
    //указатели на кнопки в шопе
    public gas_shop Gas_;
    public minerals_shop minShop;
    public gasSilos_shop gasSilos_;
    public mineralsSilos_shop mineralsSilos_;
    //переменные текста
    public Text Level;
    public Text price;
    public Text buildT;
    public Text perform;


    void Start()
    {
        //подписываю на событие в кнопке
        Gas_.ShowInfo += ShowInfo;

        minShop.ShowInfo += ShowInfo;
 
        gasSilos_.ShowInfo += ShowInfo;

        mineralsSilos_.ShowInfo += ShowInfo;
    
        //значение полей по умолчанию
        Level.text = "---";
        price.text = "---";
        buildT.text = "---";
        perform.text = "---";
    }

    public void ShowInfo(AbstractBuild build)
    {

        //при нажатие на иконку здания в магазине показываются его характеристики
        Level.text = build.Lvl.ToString();
        price.text = build.Price.ToString();
        buildT.text = build.Build_time.ToString();
        perform.text = build.Performance.ToString();
    }



}
