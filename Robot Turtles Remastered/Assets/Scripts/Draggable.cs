using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

    int handChildCount;
    int tileChildCount;

	GameObject placeholder = null;
    GameObject originParent = null;

	public void OnBeginDrag(PointerEventData eventData) {
        handChildCount = GameObject.Find("Hand").transform.childCount;
        tileChildCount = GameObject.Find("TileZone").transform.childCount;
        //Debug.Log("OnBeginDrag");
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
        //Debug.Log("OnDrag");
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
        //Debug.Log("OnEndDrag");
        Debug.Log(zone);
        if (zone == DropZone.DropZoneType.BoardZone)
        {
            if (this.transform.tag != "SolidWall" && this.transform.tag != "IceWall") { this.transform.SetParent(originParent.transform); }
            else
            {
                if (parentToReturnTo.transform.childCount == 0)
                {
                    if (this.transform.tag == "SolidWall")
                    {
                        //Debug.Log("Solid wall placed");
                        this.transform.SetParent(parentToReturnTo);
                        tileChildCount++;
                        if (WallPlacement.validPlacement(Convert.ToInt32(parentToReturnTo.transform.name)))
                        {
                            //Debug.Log("Solid wall placed");
                            this.transform.SetParent(parentToReturnTo);
                            tileChildCount++;
                        }
                        else { this.transform.SetParent(originParent.transform); }//*/ //not vallid placement
                    }
                    else
                    {
                        Debug.Log("Ice wall placed");
                        this.transform.SetParent(parentToReturnTo);
                        tileChildCount++;
                    }
                } else { this.transform.SetParent(originParent.transform); } //space occupied cant place wall there

            }
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
        } else if (zone == DropZone.DropZoneType.FunctionZone)
        {
            if (this.tag != "Forward" && this.tag != "Left" && this.tag != "Right" && this.tag != "Laser" && this.tag != "FCard")
            {
                this.transform.SetParent(originParent.transform);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                Destroy(placeholder);
            } else
            {
                Scene scene = SceneManager.GetActiveScene();
                if (scene.name == "spGameBoard")
                {
                    Debug.Log(scene.name);
                    this.transform.SetParent(parentToReturnTo);
                    this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    this.GetComponent<Draggable>().enabled = false;
                    Sprite blankCard = Resources.Load<Sprite>("blank_card");
                    this.GetComponent<Image>().sprite = blankCard;
                    Destroy(placeholder);
                }
                else
                {
                    this.transform.SetParent(parentToReturnTo);
                    this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    this.GetComponent<Draggable>().enabled = false;
                    Sprite blankCard = Resources.Load<Sprite>("blank_card");
                    this.GetComponent<Image>().sprite = blankCard;
                    Destroy(placeholder);
                }
            }
        } else if (zone == DropZone.DropZoneType.HandZone)
        {
            this.transform.SetParent(originParent.transform);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
        }
        else if (zone == DropZone.DropZoneType.DeckZone)
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
        } else if (zone == DropZone.DropZoneType.FieldZone)
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
        } else if (zone == DropZone.DropZoneType.TileZone)
        {
            if (this.transform.tag != "SolidWall" && this.transform.tag != "IceWall")
            {
                this.transform.SetParent(originParent.transform);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                Destroy(placeholder);
            }
            else
            {
                this.transform.SetParent(parentToReturnTo);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                Destroy(placeholder);
            }
        } else if (zone == DropZone.DropZoneType.DiscardZone)
        {
            if (this.tag != "Forward" && this.tag != "Left" && this.tag != "Right" && this.tag != "Laser")
            {
                this.transform.SetParent(originParent.transform);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                Destroy(placeholder);
            }
            else
            {
                this.transform.SetParent(parentToReturnTo);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                this.GetComponent<Draggable>().enabled = false;
                Sprite blankCard = Resources.Load<Sprite>("blank_card");
                this.GetComponent<Image>().sprite = blankCard;
                Destroy(this.gameObject);
                Destroy(placeholder);
            }
        } else if (zone == DropZone.DropZoneType.FCardZone)
        {
            if (this.tag != "Forward" && this.tag != "Left" && this.tag != "Right" && this.tag != "Laser")
            {
                this.transform.SetParent(originParent.transform);
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                Destroy(placeholder);
            }
            else
            {
                if (GameObject.Find("FCard").transform.childCount < 5)
                {
                    this.transform.SetParent(parentToReturnTo);
                    this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    this.GetComponent<Draggable>().enabled = false;
                    Destroy(placeholder);
                }
                else
                {
                    this.transform.SetParent(originParent.transform);
                    this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    Destroy(placeholder);
                }
            }
        } else
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
        }
        DropZone.zone = DropZone.DropZoneType.empty;
        //Debug.Log("handChildCount = " + handChildCount);
        //Debug.Log("GameObject.Find('Hand').transform.childCount = " + GameObject.Find("Hand").transform.childCount);
        //Debug.Log("tileChildCount = " + tileChildCount);
        //Debug.Log("GameObject.Find('TileZone').transform.childCount = " + GameObject.Find("TileZone").transform.childCount);
        if (tileChildCount > GameObject.Find("TileZone").transform.childCount)
        {
            //Debug.Log("Disabling Hand");
            GameObject.Find("Function").transform.GetComponent<DropZone>().enabled = false;
            //Debug.Log("Disabling TileZone");
            foreach (Transform child in GameObject.Find("TileZone").transform)
            {
                child.GetComponent<Draggable>().enabled = false;
            }
            //Debug.Log("Disabling Run Function");
            GameObject.Find("runFunctionBUtton").transform.GetComponent<Button>().enabled = false;
        }
        if (handChildCount > GameObject.Find("Hand").transform.childCount)
        {
            //Debug.Log("Disabling TileZone");
            foreach (Transform child in GameObject.Find("TileZone").transform)
            {
                child.GetComponent<Draggable>().enabled = false;
            }
            GameObject.Find("runFunctionBUtton").transform.GetComponent<Button>().enabled = false;
        }
    }	
}
