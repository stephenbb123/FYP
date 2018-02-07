using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelScroll : MonoBehaviour ,IBeginDragHandler,IEndDragHandler {

    private ScrollRect scrollRect;
    public float smoothing = 5;
    private float[] pageArray = new float[] { 0,0.12f,0.212f,0.0333f, 0.41f,0.46f,0.52f,0.6f, 0.67f, 1 };
    private float targetHorizontalPosition;
    private bool isDraging = false;

    // Use this for initialization
    void Start () {
        scrollRect = GetComponent<ScrollRect>();
	}

    // Update is called once per frame
    void Update() {
        if (isDraging == false)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetHorizontalPosition, Time.deltaTime * smoothing);
        }
    }

       public void OnBeginDrag(PointerEventData eventData)
        {
        isDraging = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            isDraging = false;
            float posx= scrollRect.horizontalNormalizedPosition; //EndDrag的點
            int index = 0;
            float offset = Mathf.Abs(pageArray[index] - posx); //差值運算
            for(int i =1; i < pageArray.Length; i++)
        {
            float offsetTemp = Mathf.Abs(pageArray[i] - posx);
            if(offsetTemp < offset)
            {
                index = i;
                offset = offsetTemp; //實現跳頁
            }
        }
        targetHorizontalPosition = pageArray[index];
        scrollRect.horizontalNormalizedPosition = pageArray[index];
        }

    }


