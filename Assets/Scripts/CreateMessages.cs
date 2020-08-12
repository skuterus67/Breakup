using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateMessages : MonoBehaviour
{
    public string application;
    public string key;
    public TextAsset file;
    string[] lines;
    string[] author;
    string[] texts;
    GameObject[] textBubbles;
    public GameObject bubble;
    public GameObject parent;


    // Start is called before the first frame update
    void Start()
    {
        ReadFile();
        CreateBubble(author, texts);
    }

    public void ReadFile()
    {
        string[] temp = new string[2];
        lines = file.text.Split('\n');
        author = new string[lines.Length];
        texts = new string[lines.Length];
        for (int i=0; i<lines.Length; i++)
        {
            temp = lines[i].Split(';');            
            author[i] = temp[0];
            texts[i] = temp[1];
        }
    }

    public void CreateBubble(string[] author, string[] texts)
    {
        if (lines != null)
        {
            textBubbles = new GameObject[lines.Length];
            for (int i=0; i<lines.Length; i++)
            {
                textBubbles[i] = Instantiate(bubble, 
                                             parent.transform.GetChild(0).GetChild(0).GetComponent<Transform>().position,
                                             Quaternion.identity, 
                                             parent.transform.GetChild(0).GetChild(0).transform);
                RectTransform rt = (RectTransform)textBubbles[i].transform;
                textBubbles[i].transform.position = textBubbles[i].transform.position - new Vector3(0, i * rt.rect.height, 0);
                textBubbles[i].SetActive(true);
                textBubbles[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = texts[i];
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
                    textBubbles[i].transform.position = new Vector3(textBubbles[i].transform.GetComponent<Transform>().position.x - rt.rect.width/2, 
                                                        textBubbles[i].transform.GetComponent<Transform>().position.y, 0);
                }
                else
                {
                    textBubbles[i].transform.position = new Vector3(textBubbles[i].transform.GetComponent<Transform>().position.x + rt.rect.width / 2,
                                                        textBubbles[i].transform.GetComponent<Transform>().position.y, 0);
                }
            }
 
        }
    }

}
