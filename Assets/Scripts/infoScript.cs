using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class infoScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    public GameObject Panel;


    void Start()
    {
        toggle = GetComponent<Toggle>();

    }

    public void showPanel()
    {
        if (toggle.isOn)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);

        }
    }
  

}
