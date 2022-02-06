using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopAnimation : MonoBehaviour
{
    public IEnumerator Pop_in(GameObject gameObject, float duration, Action end)
    {

        float journey = 0f;

        Vector3 big_vec = new Vector3(gameObject.transform.localScale.x + 0.25f, gameObject.transform.localScale.y + 0.25f, gameObject.transform.localScale.z);
        Vector3 real_size = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;

            float percent = Mathf.Clamp01(journey / duration);
            gameObject.transform.localScale = Vector3.Lerp(Vector3.zero, big_vec, percent);
            yield return null;
        }
        journey = 0f;
        while (journey <= (duration / 8))
        {
            journey = journey + Time.deltaTime;

            float percent = Mathf.Clamp01(journey / (duration / 8));
            gameObject.transform.localScale = Vector3.Lerp(big_vec, real_size, percent);
            yield return null;
        }
        if (end != null)
        {
            end();
        }
    }
    public IEnumerator Pop_out(GameObject gameObject, float duration, Action end)
    {
        float journey = 0f;
        Vector3 big_vec = new Vector3(gameObject.transform.localScale.x + 0.25f, gameObject.transform.localScale.y + 0.25f, gameObject.transform.localScale.z);
        while (journey <= duration / 16)
        {
            journey = journey + Time.deltaTime;

            float percent = Mathf.Clamp01(journey / (duration / 16));
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, big_vec, percent);
            yield return null;

        }

        journey = 0f;
        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;

            float percent = Mathf.Clamp01(journey / duration);
            gameObject.transform.localScale = Vector3.Lerp(big_vec, Vector3.zero, percent);
            yield return null;
        }
        if (end != null)
        {
            end();
        }
    }
}
