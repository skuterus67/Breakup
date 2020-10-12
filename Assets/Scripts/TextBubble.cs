using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubble : MonoBehaviour
{
    float width;
    float height;

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log(string.Format("TEXTBUBBLE: {0} : FRAME {1}", this.GetInstanceID(), Time.frameCount), this);
        Canvas.ForceUpdateCanvases();
        width = GetComponent<RectTransform>().rect.width;
        height = GetComponent<RectTransform>().rect.height;

        Debug.Log("textbubble width: " + width);
        Debug.Log("textbubble height: " + height);
    }

    public float GetWidth()
    {
        return width;
    }

    public float GetHeight()
    {
        return height;
    }

}
