using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class CreateMessages : MonoBehaviour
{
    [SerializeField] string application;
    [SerializeField] string key;
    [SerializeField] TextAsset[] files;
    string[] lines;
    string[] author;
    string[] texts;
    Dictionary<string, TextBubble[]> conversations = new Dictionary<string, TextBubble[]>();
    [SerializeField] TextBubble bubble;
    [SerializeField] GameObject parent;

    
    // Start is called before the first frame update
    private void Start()
    {
        foreach (TextAsset file in files)
        {
            CreateMessageBubbles(file);
        }      
    }
    /*
    void Start()
    {
        //Thread.Sleep(1000);
        Debug.Log(string.Format("START CREATEMESSAGES: {0} : FRAME {1}", this.GetInstanceID(), Time.frameCount), this);
        
    }*/

    public void ShowBubbles(string author)
    {
        TextBubble[] bubbles;
        if (conversations.TryGetValue(author, out bubbles))
        {
            foreach (TextBubble bubble in bubbles)
            {
                bubble.enabled = true;
            }
        }
    }


    private void CreateMessageBubbles(TextAsset textFile)
    {
        ReadFile(textFile);
        CreateBubble(author, texts);
    }
    
    private void ReadFile(TextAsset textFile)
    {
        string[] temp = new string[2];
        lines = textFile.text.Split('\n');
        author = new string[lines.Length];
        texts = new string[lines.Length];
        for (int i=0; i<lines.Length; i++)
        {
            temp = lines[i].Split(';');            
            author[i] = temp[0];
            texts[i] = temp[1];
        }
    }

    private void CreateBubble(string[] author, string[] texts)
    {
        if (lines != null)
        {
            string conversationAuthor = "";
            TextBubble[] textBubbles = new TextBubble[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                
                textBubbles[i] = Instantiate(bubble,
                                             parent.transform.position,
                                             Quaternion.identity,
                                             parent.transform);
                textBubbles[i].transform. = false;
                textBubbles[i].GetComponentInChildren<TextMeshProUGUI>().text = texts[i];
                Debug.Log(textBubbles[i].GetComponentInChildren<TextMeshProUGUI>().text);
                if (texts[i].Length >= 22)
                {
                    textBubbles[i].name = texts[i].Remove(22);
                }
                else
                {
                    textBubbles[i].name = texts[i];
                }
                if (author[i] != "Me")
                {
                    conversationAuthor = author[i];
                    Debug.Log(conversationAuthor);
                }
                
            }
            MoveBubbles(textBubbles);
            conversations.Add(conversationAuthor, textBubbles);
        }
    }

    private void MoveBubbles(TextBubble[] textBubbles)
    {
        int index = 0;
        foreach (TextBubble textBubble in textBubbles)
        {

            Canvas.ForceUpdateCanvases();
            Debug.Log("cm " + textBubbles[index].GetWidth());
            Debug.Log("cm " + textBubbles[index].GetHeight());

            if (author[index] != "Me")
            {

                textBubbles[index].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 0);
                textBubbles[index].GetComponentInChildren<TextMeshProUGUI>().alignment = TMPro.TextAlignmentOptions.MidlineLeft;
            }
            else
            {
                textBubbles[index].GetComponent<RectTransform>().anchoredPosition += new Vector2(textBubbles[index].GetWidth(), 0);
                textBubbles[index].GetComponentInChildren<TextMeshProUGUI>().alignment = TMPro.TextAlignmentOptions.MidlineRight;
            }
            index++;
        }
    }

}
