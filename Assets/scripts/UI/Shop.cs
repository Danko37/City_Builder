using System.Collections;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject Alert;
    public Text AlertText;

    public event Action<AbstractBuild> pressBuild;
    public event Action<Image,Text,AbstractBuild> startBuild;//событие начала строительства<иконка,время строительства>

    public Build_Panel build_Panel;//панелька в интерфейсе где отображается прогресс постройки


    public Resourses resourses;
    public ShopInfo ShopInfo;

    
    [HideInInspector]
    public bool isActive;//видимость магазина

    private AbstractBuild selectedBuild;

    #region указатели кнопки из магазина
    public gas_shop Gas_;
    public minerals_shop minShop;
    public gasSilos_shop gasSilos_;
    public mineralsSilos_shop mineralsSilos_;
    #endregion
    //выбранное в магазине здание
    void Select_Build(AbstractBuild build)
    {
        selectedBuild = build;
    }

    void Resource_request(AbstractBuild build)
    {
        Type _buildType = build.GetType();
        //проверка ресурсов в зависимости от типа постройки
        switch (_buildType.ToString())
        {
          case "Gas":
                if (int.Parse(resourses._mineralsValue.text) >= int.Parse(ShopInfo.price.text) & !build_Panel.IsBuilding)//ресурсов достаточно
                {
                    resourses.Set_Minerals(-int.Parse(ShopInfo.price.text));
                    startBuild(Gas_.GetComponent<Image>(), ShopInfo.buildT, selectedBuild);
                }
                else if (!(int.Parse(resourses._mineralsValue.text) >= int.Parse(ShopInfo.price.text)))//если нет ресурсов
                {
                    AlertText.fontSize = 18;
                    AlertText.text = "Not enough resources!!!";
                    StartCoroutine("ShowAlert");
                }
                else if (build_Panel.IsBuilding)//если уже что то строится
                {
                    AlertText.fontSize = 20;
                    AlertText.text = "Building Process...";
                    StartCoroutine("ShowAlert");
                }
              break;

          case "gas_silos":
                if (int.Parse(resourses._mineralsValue.text) >= int.Parse(ShopInfo.price.text) & build_Panel.IsBuilding != true)
                {
                    resourses.Set_Minerals(-int.Parse(ShopInfo.price.text));
                    startBuild(gasSilos_.GetComponent<Image>(), ShopInfo.buildT, selectedBuild);
                }
                else if (!(int.Parse(resourses._mineralsValue.text) >= int.Parse(ShopInfo.price.text)))
                {
                    AlertText.fontSize = 18;
                    AlertText.text = "Not enough resources!!!";
                    StartCoroutine("ShowAlert");
                }
                else if (build_Panel.IsBuilding)
                {
                    AlertText.fontSize = 20;
                    AlertText.text = "Building Process...";
                    StartCoroutine("ShowAlert");
                }
                break;

            case "minerals":
                if (int.Parse(resourses._gasValue.text) >= int.Parse(ShopInfo.price.text) & build_Panel.IsBuilding != true)
                {
                    resourses.Set_Gas(-int.Parse(ShopInfo.price.text));
                    startBuild(minShop.GetComponent<Image>(), ShopInfo.buildT, selectedBuild);
                }
                else if(!(int.Parse(resourses._gasValue.text) >= int.Parse(ShopInfo.price.text)))
                {
                    AlertText.fontSize = 18;
                    AlertText.text = "Not enough resources!!!";
                    StartCoroutine("ShowAlert");
                }
                else if (build_Panel.IsBuilding)
                {
                    AlertText.fontSize = 20;
                    AlertText.text = "Building Process...";
                    StartCoroutine("ShowAlert");
                }
                break;
            case "minerals_silos":
                if (int.Parse(resourses._gasValue.text) >= int.Parse(ShopInfo.price.text) & !build_Panel.IsBuilding)
                {
                    resourses.Set_Gas(-int.Parse(ShopInfo.price.text));
                    startBuild(mineralsSilos_.GetComponent<Image>(), ShopInfo.buildT, selectedBuild);
                }
                else if (!(int.Parse(resourses._gasValue.text) >= int.Parse(ShopInfo.price.text)))
                {
                    AlertText.fontSize = 18;
                    AlertText.text = "Not enough resources!!!";
                    StartCoroutine("ShowAlert");
                }
                else if (build_Panel.IsBuilding)
                {
                    AlertText.fontSize = 20;
                    AlertText.text = "Building Process...";
                    StartCoroutine("ShowAlert");
                }
                break;
                
          
        }
    }

    void OnEnable()
    {
        if (Alert.activeSelf == true)
        {
            Alert.SetActive(false);
        }

    }
    void Start()
    {
        //назначаем обработчики события по нажатию ЛКМ по постройке в магазине
        Gas_.Select += Select_Build;
        minShop.Select += Select_Build;        
        gasSilos_.Select+= Select_Build;        
        mineralsSilos_.Select += Select_Build;

        //по нажатию "строить"
        pressBuild += Resource_request;       
        //"выключаем магазин"
        Alert.SetActive(false);
        isActive = false;
        gameObject.SetActive(isActive);
    }
    private bool IsMouseOverUI()//находится ли курсор над UI
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    IEnumerator ShowAlert()//куратин показа алерта
    {
       
        Alert.SetActive(true);
        yield return new WaitForSeconds(3);
        Alert.SetActive(false);
        StopCoroutine("ShowAlert");
    }
    public void OnClick()//нажатие купить
    {
        try
        {
            pressBuild(selectedBuild);
        }

        catch (NullReferenceException)
        {
           AlertText.text = "Choose a building!!!";
            StartCoroutine("ShowAlert"); 
        }
 
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())//
        {
            //магазин пропадает при клике по игровому полю
            isActive = false;
            gameObject.SetActive(isActive);
        }        
    }
}
