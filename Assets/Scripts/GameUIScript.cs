using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        text.text = " 3/3";
    }

    // Update is called once per frame
    void Update()
    {
        int count = player.GetComponent<PlayerController>().cageCount;
        text.text = " " + count + "/3";
    }
}
