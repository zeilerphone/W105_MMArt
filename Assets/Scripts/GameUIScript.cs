using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    public TextMeshProUGUI cageCount;
    public TextMeshProUGUI catCount;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        cageCount.text = " 3/3";
    }

    // Update is called once per frame
    void Update()
    {
        int cageNum = player.GetComponent<PlayerController>().cageCount;
        cageCount.text = " " + cageNum + "/3";
        int catNum = player.GetComponent<PlayerController>().catCount;
        catCount.text = "" + catNum;
    }
}
