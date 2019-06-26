using System.Collections;
using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// класс для отображения процесса постройки на экране
/// </summary>
public class Build_Panel : MonoBehaviour
{
    public event Action<AbstractBuild> _constractionCompeted;
    public Camera_Cursor coursorTarget;
    
    [HideInInspector]
    public bool IsBuilding = false;
    bool isReady = false;

    public Image slider;
    public Sprite defaultSprite;
    [HideInInspector]
    public Sprite current_icon;
    public Shop shop;//указатель на магазин
    AbstractBuild building_Under_Construction;//какое здание строится
    public GameObject Ghost;//кубик ,показывающий где строить
    int BuildingTime;

   
    void Start()
    {
        slider.fillAmount = 0;
        _constractionCompeted += PawnGhost;
        current_icon = defaultSprite;
        gameObject.GetComponent<Image>().sprite = current_icon;      
        shop.startBuild += BuildingProcess;
    }
    public void BuildingProcess(Image image, Text buildTime, AbstractBuild build)//подготовка к строительству
    {
        building_Under_Construction = build;      
        current_icon = image.sprite;
        GetComponent<Image>().sprite = current_icon;
        BuildingTime = int.Parse(buildTime.text);
        StartCoroutine("BuildCoroutine");//постройка
        
    }
    IEnumerator BuildCoroutine()
    {
        IsBuilding = true;        
        int currentTime = 0;
        slider.fillAmount = 0f;
        while (currentTime < BuildingTime)
        {
            yield return new WaitForSeconds(1);
            currentTime++;
            slider.fillAmount = (float)currentTime / (float)BuildingTime;           
        }
        if (currentTime >= BuildingTime)
        {
            StopCoroutine("BuildCoroutine");
            _constractionCompeted(building_Under_Construction);
        }
    }

    void PawnGhost(AbstractBuild build)//павн указки
    {
        GetComponent<Image>().color = Color.green;
        isReady = true;
    }

    void GhostDestroy()//при нажатии лкм гоуст пропадает,появляется здание
    {
        gameObject.GetComponent<Image>().sprite = defaultSprite;
        gameObject.GetComponent<Image>().color = Color.white;
        slider.fillAmount = 0f;
    }
   
    public void SelfClick()//после завершения строительсятва щелкаем по иконке на правой панели и выбираем место
    {
        if (isReady && !GameObject.Find("Ghost_build(Clone)"))
        {
            GameObject ghost = Instantiate(Ghost, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
            ghost.GetComponent<Ghost>().typeOfBuildForConstraction = building_Under_Construction;

            shop.isActive = false;
            shop.gameObject.SetActive(shop.isActive);

            ghost.GetComponent<Ghost>()._DestroyGhost += GhostDestroy;

            isReady = false;
            IsBuilding = false;
        }
    }


}
