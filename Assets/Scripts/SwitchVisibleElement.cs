using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchVisibleElement : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject oldElement;
    [SerializeField] GameObject newElement;
    [SerializeField] bool replace;
    [SerializeField] string application;
    [SerializeField] string key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        if (replace)
        {
            oldElement.SetActive(false);
            newElement.SetActive(true);
        }
        else
        {
            newElement.SetActive(true);
        }
    }
}
