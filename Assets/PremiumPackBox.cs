using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PremiumPackBox : BaseBox
{
    public static PremiumPackBox _instance;
    public static PremiumPackBox Setup()
    {
        if (_instance == null)
        {
            _instance = Instantiate(Resources.Load<PremiumPackBox>(PathPrefabs.PREMIUM_PACK_BOX));
            _instance.Init();
        }
        _instance.InitState();
        return _instance;
    }

    public Button btnClose;

    public PackInShop iapPack;


    public void Init()
    {
        btnClose.onClick.AddListener(Close);
        iapPack.Init();
        Invoke(nameof(ShowButtonClose), 2);
        EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.SHOP_CHECK, HandleOff);
    }
    public void InitState()
    {

    }
    private void ShowButtonClose()
    {
        btnClose.transform.DOScale(new Vector3(1,1,1),0.5f);
    }

    private void HandleOff(object param)
    {
        Close();
    }

    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.SHOP_CHECK, HandleOff);
    }
}