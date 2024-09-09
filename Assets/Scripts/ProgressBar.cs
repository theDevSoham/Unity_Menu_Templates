using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image progressImage;
    [SerializeField]
    private float Speed = 1f;
    [SerializeField]
    private UnityEvent<float> OnProgress;
    [SerializeField]
    private UnityEvent OnProgressCompleted;

    private Coroutine AnimationCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        if (progressImage.type != Image.Type.Filled)
        {
            Debug.LogError($"{name}'s progressImage type is not \"Filled\" so it cannot be used. Disabling the progress");
            this.enabled = false;
        }
    }

    private void OnGUI()
    {
        StartCoroutine(ProgressStarter(Speed));
    }

    public void SetProgress(float progress, float speed)
    {
        if (progress < 0 ||  progress > 1)
        {
            Debug.LogWarning($"Invalid progress passed. Accepted value should be between 0 and 1. Got {progress}. Clamping");
            progress = Mathf.Clamp01(progress);
        }

        if (progress != progressImage.fillAmount)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            AnimationCoroutine = StartCoroutine(AnimationProgress(progress, speed));
        }
    }

    private IEnumerator ProgressStarter(float Speed)
    {
        yield return null;
        SetProgress(1, Speed);
    }

    private IEnumerator AnimationProgress (float progress, float speed)
    {
        float time = 0;
        float initialProgress = progressImage.fillAmount;

        while(time < 1)
        {
            progressImage.fillAmount = Mathf.Lerp(initialProgress, progress, time);
            time += Time.deltaTime * speed;

            OnProgress?.Invoke(progressImage.fillAmount);
            yield return null;
        }

        progressImage.fillAmount = progress;
        OnProgress?.Invoke(progress);
        OnProgressCompleted?.Invoke();
    }
}
