//using Assets.Utils;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public enum DropZoneType
    {
        Field,
        Discard,
        FunctionZone,
        TileZone,
        Hand,
        Deck
        
    }
    public DropZoneType zoneType = DropZoneType.Field;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            

            if (zoneType == DropZoneType.Field)
            {
                if (HasDraggableAlready())
                    return;
            }

            if (zoneType == DropZoneType.Field || zoneType == DropZoneType.Hand || zoneType == DropZoneType.FunctionZone)
                d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
          //logic for drop conditions go into here


            d.parentToReturnTo = this.transform;
            
        }

    }

    private bool HasDraggableAlready()
    {
        return (this.GetComponentsInChildren(typeof(Draggable)).Length == 0) ? false : true;
    }
}