using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    void Start()
    {
        transform.DOMove(new Vector3(transform.position.x, .7f, transform.position.z), 2f).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);
    }
    
}
