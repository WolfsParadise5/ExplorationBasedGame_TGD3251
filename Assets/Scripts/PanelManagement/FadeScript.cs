using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using DG.Tweening;

public class FadeScript : Singleton<FadeScript>
{
    [SerializeField] private CanvasGroup canvasGroup;
    public float duration = 0.8f;
    

    protected override void AwakeSingleton()
    {
        canvasGroup.gameObject.SetActive(false);
    }

    public void triggerFadeIn(TweenCallback callback = null)
    {
        canvasGroup.gameObject.SetActive(true);
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, duration).OnComplete(callback); 
    }

    public void triggerFadeOut(TweenCallback callback = null)
    {
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, duration).OnComplete(() => { 
            canvasGroup.gameObject.SetActive(false);
            callback?.Invoke();
        });
    }
}
