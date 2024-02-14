using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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

    public Slider potionGauge;
    public TMP_Text potionText;

    public TMP_Text dialogueText;
    private Queue<string> dialogues = new Queue<string>();
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

        if(dialogueCor == null)
        {
            dialogueCor = OutputTextGradually();
            StartCoroutine(dialogueCor);
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
            float alpha = (Mathf.Sin(2 * Mathf.PI * t) + 1) / 2; // Oscillate alpha between 0 and 1
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

        while(dialogues.TryDequeue(out var dialogue))
        {
            dialogueText.text = dialogue;
            yield return outputTextDeley;
        }

        dialogueText.enabled = false;
        dialogueCor = null;
    }
}
