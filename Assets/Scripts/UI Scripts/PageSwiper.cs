using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int leftBorder= 2;
    public int rightBorder= -1;
    private int swipeCount;
    public bool canSwipe;
    public int currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
        canSwipe = true;
        swipeCount = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
     if (swipeCount <= rightBorder && SceneManager.GetActiveScene().name != "UI-Scanner")
        {
            Debug.Log("supposed to load scanner");
            SceneManager.LoadScene("UI-Scanner");
        }
     if( swipeCount> rightBorder && SceneManager.GetActiveScene().name != "UI")
        {
            Debug.Log("supposed to load UI");
            SceneManager.LoadScene("UI");
        }
    }

    public void OnDrag(PointerEventData data)
    { if(!canSwipe)
        {
            return;
        }

        float difference = data.pressPosition.x - data.position.x;
        if (swipeCount < leftBorder && swipeCount > rightBorder)
        {
            
            transform.position = panelLocation - new Vector3(difference, 0, 0);
        }
       
       
    }


    public void OnEndDrag(PointerEventData data)
    {
        if (!canSwipe) return;
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage)>= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && swipeCount < leftBorder) //swiping left, panel goes left, i see right
            {
                newLocation += new Vector3(-Screen.width, 0, 0);
                swipeCount++;
;            }
            else if (percentage <0 && swipeCount> rightBorder) // swiping right, panel goes right, i see left
            {
                newLocation += new Vector3(Screen.width, 0, 0);
                swipeCount--;
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
   
    }
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
    public void CanSwipe(bool value)
    {
        canSwipe = value;
    }
}
