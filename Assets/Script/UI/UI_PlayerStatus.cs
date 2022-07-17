using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_PlayerStatus : MonoBehaviour
{
    public Image red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HeathChanged(int health){
        // Debug.Log(red.rectTransform.rect.width);
        red.rectTransform.sizeDelta = new Vector2(health*20, 30);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        // Debug.Log(red.rectTransform.rect.width);
    }
}
