using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{
    public Shop Shop;

    public GameObject GhostObject;
    public GameObject[] BuildsForConstraction;
    GameObject ghost;

    public Camera_Cursor _camera;


    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    public void _Building(AbstractBuild build)
    {
        
    }


    void Update()
    {

        if (ghost != null && _camera._hit.point != null)
        {
            try
            {
                if (_camera._hit.collider.gameObject.layer == 9)
                {
                    ghost.gameObject.SetActive(true);
                    ghost.transform.position = _camera._transform.position + new Vector3(-0.4f, 0, -0.4f);
                }
                else if (ghost != null)
                {
                    ghost.gameObject.SetActive(false);
                }
            }
            catch (NullReferenceException)
            {

            }
        }
       
        if (ghost != null && !IsMouseOverUI() && Input.GetMouseButtonDown(0))
        {
            Instantiate(BuildsForConstraction[0], ghost.transform.position,Quaternion.identity);
           
        }
    }


}
