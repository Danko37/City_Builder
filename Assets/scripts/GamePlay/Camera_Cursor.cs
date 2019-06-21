using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// здесь узнаем на что направлен курсор
/// </summary>
public class Camera_Cursor : MonoBehaviour 
{   
    public Camera _Camera;

    public RaycastHit _hit;
    public Ray ray;

    public Transform _transform { get; set; }
   
   
    void Update()
    {
        ray = _Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hit))
        {
            if(_hit.point != null)
           _transform = _hit.collider.transform;//получаем трансформ позиции где строить
        }
      
    }
}
