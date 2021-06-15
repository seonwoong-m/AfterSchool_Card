using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private static List<DropArea> dropAreas;

    public delegate void ObjectLiftEvent(DropArea area, GameObject gameObject);
    public event ObjectLiftEvent onLifted;

    public delegate void ObjectDropEvent(DropArea area, GameObject gameObject);
    public event ObjectDropEvent onDropped;

    public delegate void ObjectHoverEnterEvent(DropArea area, GameObject gameObject);
    public event ObjectHoverEnterEvent onHoverEnter;

    public delegate void ObjectHoverExitEvent(DropArea area, GameObject gameObject);
    public event ObjectHoverExitEvent onHoverExit;

    void Awake()
    {
        dropAreas = dropAreas ?? new List<DropArea>();
        dropAreas.Add(this);
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        onLifted += ObjectLiftedTest;
        onDropped += ObjectDroppedTest;
        onHoverEnter += ObjectHoveredEnterTest;
        onHoverExit += ObjectHoveredExitTest;
    }

    void OnDisable()
    {
        onLifted -= ObjectLiftedTest;
        onDropped -= ObjectDroppedTest;
        onHoverEnter -= ObjectHoveredEnterTest;
        onHoverExit -= ObjectHoveredExitTest;
    }

    public void ObjectLiftedTest(DropArea area, GameObject gameObject)
    {
        Debug.Log(this.gameObject.name + " Object Lifted : " + gameObject.name);
    }

    public void ObjectDroppedTest(DropArea area, GameObject gameObject)
    {
        Debug.Log(this.gameObject.name + " Object Dropped : " + gameObject.name);
    }

    public void ObjectHoveredEnterTest(DropArea area, GameObject gameObject)
    {
        Debug.Log(this.gameObject.name + " Object Hovered Enter : " + gameObject.name);
    }

    public void ObjectHoveredExitTest(DropArea area, GameObject gameObject)
    {
        Debug.Log(this.gameObject.name + " Object Hovered Exit : " + gameObject.name);
    }

    public void TriggerOnLift(DropItem item)
    {
        onLifted(this, item.gameObject);
    }

    public void TriggerOnDrop(DropItem item)
    {
        item.SetDroppedArea(this);
        onDropped(this, item.gameObject);
    }

    public void TriggerOnHoverEnter(GameObject gameObject)
    {
        onHoverEnter(this, gameObject);
    }

    public void TriggerOnHoverExit(GameObject gameObject)
    {
        onHoverExit(this, gameObject);
    }

    //Interface Implementation
    public void OnPointerEnter(PointerEventData eventData)
    {
        var gameObject = eventData.pointerDrag;
        if(gameObject == null) return;

        TriggerOnHoverEnter(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var gameObject = eventData.pointerDrag;
        if(gameObject == null) return;

        TriggerOnHoverExit(gameObject);
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject gameObject = eventData.selectedObject;
        if(gameObject == null) return;

        var draggable = gameObject.GetComponent<DropItem>();
        if(draggable == null) return;

        Debug.Log("Item dropped : " + draggable.gameObject.name);
        TriggerOnDrop(draggable);
    }

    public static void SetDropArea(bool enable)
    {
        foreach(var area in dropAreas)
        {
            area.gameObject.SetActive(enable);
        }
    }
}
