using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CharacterUI : MonoBehaviour
{
    [SerializeField]
    private Character character;
    [SerializeField]
    private Slider HpSlider;
    [SerializeField]
    private TMP_Text HpText;
    [SerializeField]
    private Slider ArmorSlider;
    [SerializeField]
    private TMP_Text ArmorText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleHP();
    }

    void HandleHP()
    {
        float hpPercentage= (float)(character.Cur_P_Hp) / (float)(character.Max_P_Hp);
        HpSlider.value = hpPercentage;
        HpText.text = $"{hpPercentage*100:0}%";
    }

/*    void HandleArmor()
    {
        float ArmorPercentage = (float)(character.Cur_P_Hp) / (float)(character.Max_P_Hp);
        ArmorSlider.value = ArmorPercentage;
        ArmorText.text = $"{ArmorPercentage * 100:0}%";
    }*/
}
