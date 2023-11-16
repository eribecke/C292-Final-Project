using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private bool notFaded = true;
    [SerializeField] float duration;
    // Start is called before the first frame update
    void Start()
    {
        var cGroup = GetComponent<CanvasGroup>();
        StartCoroutine(Fade(cGroup, cGroup.alpha, notFaded ? 1:0));
        notFaded = !notFaded;
    }

   IEnumerator Fade(CanvasGroup cGroup, float start, float end)
    {
        float counter = -2f;
        if(counter < 0) { counter += Time.captureDeltaTime; }
        while(counter<duration)
        {
            counter += Time.deltaTime;
            cGroup.alpha = Mathf.Lerp(start, end, counter/duration);

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
