using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandle : UI_Base, IPointerClickHandler
{
    public Action clickAction = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        clickAction?.Invoke();
    }

  
}
