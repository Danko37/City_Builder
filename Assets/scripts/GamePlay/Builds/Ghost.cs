using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    
    public event Action _DestroyGhost;
    public GameObject[] buildings;

    [HideInInspector]
    public AbstractBuild typeOfBuildForConstraction;
    [HideInInspector]
    public Renderer GhostRenderer;
    private Camera_Cursor Cursor;

   
    void Start()
    {       
        GhostRenderer = GameObject.Find("Ghost_build(Clone)").GetComponent<MeshRenderer>();
        Cursor = GameObject.Find("Camera").GetComponent<Camera_Cursor>();
        
    }
    public void Update()
    {
        gameObject.transform.position = Cursor._transform.position;

        if (Cursor._hit.collider != null && Cursor._hit.collider.gameObject.layer != 8)
        {
            GhostRenderer.enabled = true;          
            if (Input.GetMouseButtonDown(0))
            {
                Gas gas = typeOfBuildForConstraction as Gas;
                minerals minerals = typeOfBuildForConstraction as minerals;
                gas_silos gas_Silos = typeOfBuildForConstraction as gas_silos;
                minerals_silos minerals_Silos = typeOfBuildForConstraction as minerals_silos;

                if (gas)
                {
                    Instantiate(buildings[0], gameObject.transform.position, Quaternion.identity);
                    _DestroyGhost();
                    Destroy(gameObject);
                }
                if (minerals)
                {
                    Instantiate(buildings[1], gameObject.transform.position, Quaternion.identity);
                    _DestroyGhost();
                    Destroy(gameObject);
                }

                if (gas_Silos)
                {
                    Instantiate(buildings[2], gameObject.transform.position, Quaternion.identity);
                    _DestroyGhost();
                    Destroy(gameObject);
                }

                if (minerals_Silos)
                {
                    Instantiate(buildings[3], gameObject.transform.position, Quaternion.identity);
                    _DestroyGhost();
                    Destroy(gameObject);
                }

                
            }
        }
        else
        {
            GhostRenderer.enabled = false;
        }

    }

}
