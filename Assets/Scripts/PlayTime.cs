using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour
{
    public Text time;
    int value;

    public void lessTime()
    {
        value = int.Parse(time.text) - 5;
        if (value > 0)
        {
            time.text = value.ToString();
        }

    }
    public void moreTime()
    {
        value = int.Parse(time.text) + 5;
        if (value > 0)
        {
             time.text = value.ToString();
        }
    }

}
