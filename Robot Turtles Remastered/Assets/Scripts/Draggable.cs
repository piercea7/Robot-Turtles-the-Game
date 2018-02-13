﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

	GameObject placeholder = null;
    GameObject originParent = null;

	public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
		placeholder = new GameObject();
        originParent = new GameObject();
        originParent = this.transform.parent.gameObject;
		placeholder.transform.SetParent( this.transform.parent );
		LayoutElement le = placeholder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex( this.transform.GetSiblingIndex() );
		
		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent( this.transform.parent.parent );
		
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        this.transform.position = eventData.position;

        if(placeholder.transform.parent != placeholderParent)
			placeholder.transform.SetParent(placeholderParent);

		int newSiblingIndex = placeholderParent.childCount;

		for(int i=0; i < placeholderParent.childCount; i++) {
			if(this.transform.position.x < placeholderParent.GetChild(i).position.x) {

				newSiblingIndex = i;

				if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
					newSiblingIndex--;

				break;
			}
		}

		placeholder.transform.SetSiblingIndex(newSiblingIndex);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DropZone.DropZoneType zone = DropZone.zone;
        Debug.Log("OnEndDrag");
        Debug.Log(zone);
        if (zone == DropZone.DropZoneType.BoardZone)
        {
            if (this.transform.tag != "SolidWall" && this.transform.tag != "IceWall")
            {
                this.transform.SetParent(originParent.transform);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                Destroy(placeholder);
                //Destroy(originParent);
            }
            else
            {
                this.transform.SetParent(parentToReturnTo);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                this.GetComponent<Draggable>().enabled = false;
                Destroy(placeholder);
                //Destroy(originParent);
            }
        } else if (zone == DropZone.DropZoneType.FunctionZone)
        {
            if (this.tag != "Forward" && this.tag != "Left" && this.tag != "Right" && this.tag != "Laser")
            {
                this.transform.SetParent(originParent.transform);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                Destroy(placeholder);
            } else
            {
                this.transform.SetParent(parentToReturnTo);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                this.GetComponent<Draggable>().enabled = false;
                Sprite blankCard = Resources.Load<Sprite>("blank_card");
                this.GetComponent<Image>().sprite = blankCard;
                Destroy(placeholder);
                //Destroy(originParent);
            }
        } else if (zone == DropZone.DropZoneType.HandZone)
        {
            this.transform.SetParent(originParent.transform);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
            //Destroy(originParent);
        }
        else if (zone == DropZone.DropZoneType.DeckZone)
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
            //Destroy(originParent);
        } else if (zone == DropZone.DropZoneType.DiscardZone)
        {

        } else if (zone == DropZone.DropZoneType.FieldZone)
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
            //Destroy(originParent);
        } else if (zone == DropZone.DropZoneType.TileZone)
        {
            if (this.transform.tag != "SolidWall" && this.transform.tag != "IceWall")
            {
                this.transform.SetParent(originParent.transform);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                Destroy(placeholder);
                //Destroy(originParent);
            }
            else
            {
                this.transform.SetParent(parentToReturnTo);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                Destroy(placeholder);
                //Destroy(originParent);
            }
        } else
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
        }
        DropZone.zone = DropZone.DropZoneType.empty;
    }	
}