//using Assets.Utils;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public enum DropZoneType
    {
        FieldZone,
        DiscardZone,
        FunctionZone,
        TileZone,
        HandZone,
        DeckZone,
        BoardZone
        
    }
    
    public DropZoneType zoneType = DropZoneType.FieldZone;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            

            if (zoneType == DropZoneType.FieldZone)
            {
                if (HasDraggableAlready())
                    return;
            }

            if (zoneType == DropZoneType.FieldZone || zoneType == DropZoneType.HandZone || zoneType == DropZoneType.FunctionZone)
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
            Debug.Log("Zone type = " + zoneType);
            if (zoneType == DropZoneType.FunctionZone)
            {
                //Sprite blankCard = Resources.Load<Sprite>("blank_card");
            }
            d.parentToReturnTo = this.transform;
            //d.enabled = false;
        }
    }

    private bool HasDraggableAlready()
    {
        return (this.GetComponentsInChildren(typeof(Draggable)).Length == 0) ? false : true;
    }
}