﻿// Decompiled with JetBrains decompiler
// Type: Title0241TitleSetPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Title0241TitleSetPopup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel description;
  [SerializeField]
  private UI2DSprite spr;
  [SerializeField]
  private GameObject unknown;
  [SerializeField]
  private GameObject ibtnChange;
  [SerializeField]
  private GameObject ibtnRemove;
  [SerializeField]
  private GameObject ibtnClose;
  private int id;
  private System.Action act;

  public IEnumerator Init(
    int id,
    string txt,
    bool hasEmblem,
    bool isCur,
    System.Action act,
    bool isMyTitle)
  {
    Title0241TitleSetPopup title0241TitleSetPopup = this;
    title0241TitleSetPopup.GetComponent<UIWidget>().alpha = 0.0f;
    title0241TitleSetPopup.id = id;
    title0241TitleSetPopup.act = act;
    title0241TitleSetPopup.description.SetText(txt);
    title0241TitleSetPopup.spr.gameObject.SetActive(hasEmblem);
    title0241TitleSetPopup.unknown.SetActive(!hasEmblem);
    if (hasEmblem)
    {
      IEnumerator e = title0241TitleSetPopup.CreateSprite();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    float duration1 = title0241TitleSetPopup.ibtnChange.GetComponent<UIButton>().duration;
    float duration2 = title0241TitleSetPopup.ibtnRemove.GetComponent<UIButton>().duration;
    title0241TitleSetPopup.ibtnChange.GetComponent<UIButton>().duration = 0.0f;
    title0241TitleSetPopup.ibtnRemove.GetComponent<UIButton>().duration = 0.0f;
    title0241TitleSetPopup.ibtnChange.SetActive(!isCur);
    title0241TitleSetPopup.ibtnRemove.SetActive(isCur);
    bool flag = hasEmblem & isMyTitle;
    title0241TitleSetPopup.ibtnChange.GetComponent<UIButton>().isEnabled = flag;
    title0241TitleSetPopup.ibtnRemove.GetComponent<UIButton>().isEnabled = flag;
    title0241TitleSetPopup.ibtnChange.GetComponent<UIButton>().duration = duration1;
    title0241TitleSetPopup.ibtnRemove.GetComponent<UIButton>().duration = duration2;
    title0241TitleSetPopup.GetComponent<UIWidget>().alpha = 1f;
  }

  public void IbtnChange() => this.StartCoroutine(this.EmblemSetAPI(this.id));

  public void IbtnRemove() => this.StartCoroutine(this.EmblemSetAPI(0));

  private IEnumerator EmblemSetAPI(int ID)
  {
    CommonRoot common = Singleton<CommonRoot>.GetInstance();
    common.loadingMode = 1;
    this.ibtnChange.GetComponent<BoxCollider>().enabled = false;
    this.ibtnRemove.GetComponent<BoxCollider>().enabled = false;
    this.ibtnClose.GetComponent<BoxCollider>().enabled = false;
    Future<WebAPI.Response.EmblemSet> future = WebAPI.EmblemSet(ID, (System.Action<WebAPI.Response.UserError>) (e =>
    {
      common.isLoading = false;
      common.loadingMode = 0;
      Singleton<PopupManager>.GetInstance().onDismiss();
      WebAPI.DefaultUserErrorCallback(e);
      MypageScene.ChangeSceneOnError();
    }));
    IEnumerator e1 = future.Wait();
    while (e1.MoveNext())
      yield return e1.Current;
    e1 = (IEnumerator) null;
    if (future.Result != null)
    {
      common.loadingMode = 0;
      Singleton<PopupManager>.GetInstance().onDismiss();
      this.act();
    }
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  private IEnumerator CreateSprite()
  {
    Future<UnityEngine.Sprite> sprF = EmblemUtility.LoadEmblemSprite(this.id);
    IEnumerator e = sprF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.spr.sprite2D = sprF.Result;
  }
}
