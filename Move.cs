using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        move(gameObject, Vector3.zero, Vector3.one, 1f, false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StopAllCoroutines();
            move(gameObject, Vector3.zero, Vector3.one, 1f, false);
        }else if (Input.GetKeyDown(KeyCode.B))
        {
            StopAllCoroutines();
            EaseIn(gameObject, Vector3.zero, Vector3.one, 1f, false);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            StopAllCoroutines();
            EaseOut(gameObject, Vector3.zero, Vector3.one, 1f, true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            StopAllCoroutines();
            EaseInOut(gameObject, Vector3.zero, Vector3.one, 1f, true);
        }
    }
    void move(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        StartCoroutine(moveIEnumerator(gameObject, Vector3.zero, Vector3.one, time, pingpong));
    }
    IEnumerator moveIEnumerator(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        gameObject.transform.position = begin;
        if (pingpong)
        {
            while (true)
            {
                gameObject.transform.DOMove(end, time).OnComplete(() =>
                {
                    gameObject.transform.DOMove(begin, time);
                    
                });
                yield return new WaitForSeconds(time * 2);
            }
        }
        else
        {
            gameObject.transform.DOMove(end, time);
        }
    }
    void EaseIn(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        StartCoroutine(EaseInIEnumerator(gameObject, Vector3.zero, Vector3.one, time, pingpong));

    }
    IEnumerator EaseInIEnumerator(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        gameObject.transform.position = begin;
        if (pingpong)
        {
            while (true)
            {
                gameObject.transform.DOMove(end, time).SetEase(Ease.InSine).OnComplete(() =>
                {
                    gameObject.transform.DOMove(begin, time).SetEase(Ease.InSine);

                });
                yield return new WaitForSeconds(time * 2);
            }
        }
        else
        {
            gameObject.transform.DOMove(end, time).SetEase(Ease.InSine);
        }
    }
    void EaseOut(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        StartCoroutine(EaseOutIEnumerator(gameObject, Vector3.zero, Vector3.one, time, pingpong));

    }
    IEnumerator EaseOutIEnumerator(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        gameObject.transform.position = begin;
        if (pingpong)
        {
            while (true)
            {
                gameObject.transform.DOMove(end, time).SetEase(Ease.OutSine).OnComplete(() =>
                {
                    gameObject.transform.DOMove(begin, time).SetEase(Ease.OutSine);

                });
                yield return new WaitForSeconds(time * 2);
            }
        }
        else
        {
            gameObject.transform.DOMove(end, time).SetEase(Ease.OutSine);
        }
    }
    void EaseInOut(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        StartCoroutine(EaseInOutIEnumerator(gameObject, Vector3.zero, Vector3.one, time, pingpong));

    }
    IEnumerator EaseInOutIEnumerator(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        gameObject.transform.position = begin;
        if (pingpong)
        {
            while (true)
            {
                gameObject.transform.DOMove(end, time).SetEase(Ease.InOutSine).OnComplete(() =>
                {
                    gameObject.transform.DOMove(begin, time).SetEase(Ease.InOutSine);

                });
                yield return new WaitForSeconds(time * 2);
            }
        }
        else
        {
            gameObject.transform.DOMove(end, time).SetEase(Ease.InOutSine);
        }
    }
}
