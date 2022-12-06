using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SigilTextUpdate : MonoBehaviour
{

    public TextMeshProUGUI sigilText;

    private int count;

    public GameObject mainSigilText;

    // Start is called before the first frame update
    void Start() {
        SetCountText(); 
    }

    void Update()
    {
        SetCountText();
    }

    void SetCountText()
    {
        sigilText.text = Player.sigilCount.ToString() + "/4 Sigils Left";

        if(Player.sigilCount <= 0)
        {
            sigilText.text = "Destroy the Last Sigil";
        }
    }
}
