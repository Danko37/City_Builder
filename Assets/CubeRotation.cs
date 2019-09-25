using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeRotation : MonoBehaviour, IDragHandler
{
  new private Transform transform;

  private void Start()
  {
    transform = GetComponent<Transform>();
  }

  public void OnDrag(PointerEventData eventData)
  {
    Debug.Log(eventData.delta.x);
    if (transform != null)
    {
      transform.Rotate(0, eventData.delta.x, 0, Space.Self);
    }
    else { Debug.LogWarning("transform is null"); }
  }
}
