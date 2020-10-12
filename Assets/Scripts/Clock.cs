using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Clock : MonoBehaviour
{
    string clockString;
    string sClockH;
    string sClockM;
    int iClockH;
    int iClockM;
    System.Diagnostics.Stopwatch watch;
    TextMeshProUGUI TMProUGUI;
    [SerializeField] float timeSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        watch = System.Diagnostics.Stopwatch.StartNew();
        TMProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(CountTime());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpeed);

            clockString = TMProUGUI.text;
            string[] strlist = clockString.Split(':');
            iClockH = int.Parse(strlist[0]);
            iClockM = int.Parse(strlist[1]);

            if (iClockM != 59)
            {
                iClockM++;
            }
            else
            {
                iClockM = 0;
                if (iClockH != 23)
                {
                    iClockH++;
                }
                else
                {
                    iClockH = 0;
                }
            }

            sClockH = iClockH.ToString();
            sClockM = iClockM.ToString();
            if (sClockH.Length == 1)
            {
                sClockH = AppendAtPosition(sClockH, 0, "0");
            }
            if (sClockM.Length == 1)
            {
                sClockM = AppendAtPosition(sClockM, 0, "0");
            }

            clockString = sClockH + ":" + sClockM;
            TMProUGUI.text = clockString;
        }
    }

    private string AppendAtPosition(string baseString, int position, string character)
    {
        var sb = new StringBuilder(baseString);
        sb.Insert(position, character);
        return sb.ToString();
    }

}
