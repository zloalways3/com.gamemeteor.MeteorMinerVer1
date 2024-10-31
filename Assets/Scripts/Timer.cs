using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI failTimerText;
    [SerializeField] private TextMeshProUGUI winTimerText;
    [SerializeField] private GameController gameController;

    [SerializeField] private RectTransform timerScaleTransform;
    [SerializeField] private RectTransform failTimerScaleTransform;
    [SerializeField] private RectTransform winTimerScaleTransform;

    private float _timerScaleDelta;
    public int TimeLimit { private get; set; }

    public bool IsEnabled { private get; set; } = true;

    private void Start()
    {
        if (PlayerPrefs.GetInt("OffTimer", 0) == 1)
        {
            timerText.text = "Timer: ∞ sec";
            return;
        }

        _timerScaleDelta = timerScaleTransform.rect.width / TimeLimit;
        timerText.text = "Timer: " + TimeLimit + " sec";
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => IsEnabled == true);
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => IsEnabled == true);

            TimeLimit -= 1;
            timerText.text = "Timer: " + TimeLimit + " sec" ;

            timerScaleTransform.sizeDelta = new Vector2(timerScaleTransform.sizeDelta.x - _timerScaleDelta, timerScaleTransform.sizeDelta.y);

            if (TimeLimit == 0)
            {
                gameController.Fail();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public void Disable()
    {
        failTimerText.text = winTimerText.text = timerText.text;

        failTimerScaleTransform.sizeDelta = timerScaleTransform.sizeDelta;
        winTimerScaleTransform.sizeDelta = timerScaleTransform.sizeDelta;

        StopAllCoroutines();
    }
}