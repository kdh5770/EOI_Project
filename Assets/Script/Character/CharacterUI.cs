using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;



public class CharacterUI : MonoBehaviour
{
    private readonly WaitForSeconds outputTextDeley = new WaitForSeconds(2f);

    [SerializeField]
    private Slider HpSlider;
    [SerializeField]
    private TMP_Text HpText;
    [SerializeField]
    private Slider costSlider;
    [SerializeField]
    private TMP_Text costText;
    [SerializeField]
    private TMP_Text BulletText;
    [SerializeField]
    private TMP_Text systemMsgText;


    public Slider potionGauge;
    public TMP_Text potionText;
    public TMP_Text missionText;
    public TMP_Text dialogueText;
    public GameObject E_btn;


    private Queue<string> dialogues = new Queue<string>();
    private Queue<string> missions = new Queue<string>(); //미션 txt 
    private Queue<string> systemmsg= new Queue<string>(); //시스템 메세지 txt


    private IEnumerator dialogueCor;

    public Image effectImage;
    public Image bloodFrame;
    public Image bloodEffect;

    bool isDanger;

    IEnumerator effectCor;

    public void HandleHP(float _curHP, float _maxHP, bool _isAttack)
    {
        float hpPercentage = _curHP / _maxHP;
        HpSlider.value = hpPercentage;
        HpText.text = $"{hpPercentage * 100:0}%";

        Color frame = bloodFrame.color;
        frame.a = 1 - hpPercentage;
        bloodFrame.color = frame;

        if (hpPercentage <= .3f)
        {
            if (effectCor == null)
            {
                isDanger = true;
                effectCor = SinFadeImage();
                StartCoroutine(effectCor);
            }
        }

        else
        {
            isDanger = false;
            if (effectCor != null)
            {
                effectCor = null;
            }
        }
    }

    public void HandleCost(float _curCost, float _maxCost)
    {
        float costPercentage = _curCost / _maxCost;
        costSlider.value = costPercentage;
        costText.text = $"{costPercentage * 100:0}%";
    }

    public void HandlePotion(float _curPotion, float _maxPotion)
    {
        float costPercentage = _curPotion / _maxPotion;
        potionGauge.value = costPercentage;
        potionText.text = $"{costPercentage * 100:0}%";
    }

    public void TakeEffect(Sprite _image)
    {
        if (effectImage.sprite == null)
        {
            effectImage.sprite = _image;
            StartCoroutine(FadeOutImage());
        }
    }

    public void SetDialogue(string _masseage)
    {
        dialogues.Enqueue(_masseage);

        if (dialogueCor == null)
        {
            dialogueCor = OutputTextGradually();
            StartCoroutine(dialogueCor);
        }
    }

    public void SetSystemMsgtxt(string _message)
    {
        systemmsg.Enqueue(_message);

    }

    public void SetMissiontxt(string _masseage)
    {
        missions.Enqueue(_masseage);
        missionText.text = _masseage.ToString();
        
/*        // 만약 임무를 성공 했을 때
        if (성공조건)
        {
            missions.Dequeue();
        }*/
    }

    IEnumerator triggercor;

    public void OnInputTrigger(bool _enter)
    {
        if (_enter)
        {
            if (triggercor == null)
            {
                triggercor = Blink();
                StartCoroutine(triggercor);
            }
        }



        else
        {
            StopCoroutine(triggercor);
            triggercor = null;
            E_btn.SetActive(false);
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            E_btn.SetActive(!E_btn.activeSelf);
            yield return new WaitForSeconds(.5f);
        }
    }

    public void HandleBullet()
    {

    }

    IEnumerator SinFadeImage()
    {
        Color effect = bloodEffect.color;

        while (isDanger) // Continuous loop
        {
            float t = Time.time % 1; // Repeat every second
            float alpha = (Mathf.Sin(2 * Mathf.PI * t) + 1) / 3; // Oscillate alpha between 0 and 1
            effect.a = alpha;
            bloodEffect.color = effect;
            yield return null; // Wait for the next frame
        }

        effect.a = 0f;
        bloodEffect.color = effect;
        effectCor = null;
    }

    IEnumerator FadeOutImage()
    {
        float duration = 1f;
        Color newColor = effectImage.color;

        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            newColor.a = Mathf.Lerp(1, 0, t / duration);
            effectImage.color = newColor;
            yield return null;
        }

        newColor.a = 0f;
        effectImage.color = newColor;
        effectImage.sprite = null;
    }

    IEnumerator OutputTextGradually()
    {
        dialogueText.enabled = true;

        while (dialogues.TryDequeue(out var dialogue))
        {
            dialogueText.text = dialogue;
            yield return outputTextDeley;
        }

        dialogueText.enabled = false;
        dialogueCor = null;
    }
}