using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private PlayerController2 player;
    [SerializeField] private GameObject spriteParent;
    public GameObject moneySprite;
    public Camera cam;
    
    public int moneyCount = 0;
    public TMP_Text moneyCountText;

    private void Start()
    {
        player = FindObjectOfType<PlayerController2>();
    }

    public void AddMoneyCount(Transform money)
    {
        money.DOMove(moneyCountText.transform.position, .5f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            moneyCount += 50;
            moneyCountText.text = moneyCount.ToString();
            Destroy(money.gameObject);
        });
    }

    public void CreateMoneySpriteInUI(Vector3 moneyPos)
    {
        Vector3 screenPos = cam.WorldToScreenPoint(moneyPos);
        var temp = Instantiate(moneySprite, screenPos, Quaternion.identity,spriteParent.transform);
        AddMoneyCount(temp.transform);
    }
}
