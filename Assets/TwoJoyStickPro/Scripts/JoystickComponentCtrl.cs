using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class JoystickComponentCtrl : JoystickCtrl {

    /* component refs */
    public RectTransform Container;

    /* private vars */
    private Vector2 _joystickCenter = Vector2.zero;
    private Vector3 _containerDefaultPosition;

    public UnityEvent OnTap;

    void Start()
    {
        this._containerDefaultPosition = this.Container.position;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - _joystickCenter;
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Container.position = eventData.position;
        handle.anchoredPosition = Vector2.zero;
        _joystickCenter = eventData.position;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Container.position = this._containerDefaultPosition;
        handle.anchoredPosition = Vector2.zero;
        inputVector = Vector2.zero;
        this.OnTap.Invoke();
    }

    #region 当Canvas的RenderMode使用ScreenSpace-Camera时，启用下面代码
    // void Start()
    // {
    //     this._containerDefaultPosition = this.Container.anchoredPosition;
    // }

    // public override void OnDrag(PointerEventData eventData)
    // {        
    //     Vector2 pos = ScreenPointToUGUIPosition(transform as RectTransform, eventData.position);
    //     Vector2 direction = pos - _joystickCenter;
    //     inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
    //     handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
    // }

    // public override void OnPointerDown(PointerEventData eventData)
    // {
    //     Vector2 pos = ScreenPointToUGUIPosition(transform as RectTransform, eventData.position);
    //     Container.anchoredPosition = pos;
    //     handle.anchoredPosition = Vector2.zero;
    //     _joystickCenter = pos;
    // }

    // public override void OnPointerUp(PointerEventData eventData)
    // {
    //     Container.anchoredPosition = this._containerDefaultPosition;
    //     handle.anchoredPosition = Vector2.zero;
    //     inputVector = Vector2.zero;
    //     this.OnTap.Invoke();
    // }
    
    // /// <summary>
    // /// 视口坐标转ugui坐标
    // /// </summary>
    // /// <param name="canvasRectTransform"></param>
    // /// <param name="screenPos"></param>
    // /// <returns></returns>
    // private Vector2 ScreenPointToUGUIPosition(RectTransform canvasRectTransform, Vector3 screenPos)
    // {
    //     Vector2 uiPos = new Vector2();
    //     RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPos, UIGlobal.Instance.uiCamera, out uiPos);
    //     return uiPos;
    // }
    #endregion
}
