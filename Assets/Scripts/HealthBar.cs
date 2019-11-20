using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private float startTweenFrom = 1.0f;
    private float tweeningTo = 1.0f;
    private float tweenStartTime = 0.0f;
    private float tweenFinishTime = 0.0f;

    private float easeOutCubic(float t, float b, float c, float d)
    {
        t /= d;
        t--;
        return c * (t * t * t + 1) + b;
    }

    public void ChangeValue(int newHP, int maxHP)
    {
        tweeningTo = (float) newHP / (float) maxHP;
        tweenStartTime = Time.time;
        tweenFinishTime = tweenStartTime + 0.3f;
    }

    public void Update()
    {
        if(Time.time < tweenFinishTime)
        {
            float coeff = easeOutCubic(Time.time - tweenStartTime, startTweenFrom, tweeningTo - startTweenFrom, 0.3f);
            transform.localScale = new Vector3(coeff, 1, 1);
            transform.localPosition = new Vector3(-(1.0f - coeff) / 2.0f, 0, 0);
        }
        else if(startTweenFrom != tweeningTo)
        {
            startTweenFrom = tweeningTo;
            transform.localScale = new Vector3(tweeningTo, 1, 1);
            transform.localPosition = new Vector3(-(1.0f - tweeningTo) / 2.0f, 0, 0);
        }
    }
}
