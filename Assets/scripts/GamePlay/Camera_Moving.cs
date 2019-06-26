using UnityEngine.EventSystems;
using UnityEngine;
/// <summary>
/// двигаем камеру
/// </summary>
public class Camera_Moving : MonoBehaviour
{  //смещение камеры в следующем кадре
    float Xmoving;
    float Zmoving;

    public float sensitivity;

    void Start()
    {
        sensitivity = 0.4f;
    }
    private bool IsMouseOverUI()//курсор над ui?
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && !IsMouseOverUI())
        {   //узнаем на сколько сместилась мышка за кадр 
            Zmoving -= Input.GetAxis("Mouse Y") * sensitivity;
            Xmoving -= Input.GetAxis("Mouse X") * sensitivity;

            transform.position += new Vector3(Xmoving, 0, Zmoving);
            Xmoving = 0;
            Zmoving = 0;
        }
        //ограничение передвижения камеры над игровым полем
        if (gameObject.transform.position.x > 32f)
        {
            gameObject.transform.position = new Vector3(32f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.x < 11f)
        {
            gameObject.transform.position = new Vector3(11f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.z > -26f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -26f);
        }
        if (gameObject.transform.position.z < -56f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -56f);
        }
    }
}
