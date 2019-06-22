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

    public Material[] GhostBoolMat;
   
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
            if (!Cursor._hit.collider.gameObject.GetComponent<NotForBuild>())
            {
                GhostRenderer.materials[0] = GhostBoolMat[0];
            }
            else { GhostRenderer.materials[0] = GhostBoolMat[1]; }
            if (Input.GetMouseButtonDown(0))
            {
                
                Type buildType = typeOfBuildForConstraction.GetType();
                switch (buildType.ToString())
                {
                    case "Gas":
                        Instantiate(buildings[0], gameObject.transform.position,Quaternion.identity);
                        _DestroyGhost();
                        Destroy(gameObject);
                    break;

                    case "minerals":
                        Instantiate(buildings[1], gameObject.transform.position, Quaternion.identity);
                        _DestroyGhost();
                        Destroy(gameObject);
                        break;

                    case "gas_silos":
                        Instantiate(buildings[2], gameObject.transform.position, Quaternion.identity);
                        _DestroyGhost();
                        Destroy(gameObject);
                        break;

                    case "minerals_silos":
                        Instantiate(buildings[3], gameObject.transform.position, Quaternion.identity);
                        _DestroyGhost();
                        Destroy(gameObject);
                        break;

                }
            }
        }
        else
        {
            GhostRenderer.enabled = false;
        }

    }

}
