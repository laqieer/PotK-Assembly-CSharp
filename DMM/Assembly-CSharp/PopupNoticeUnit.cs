// Decompiled with JetBrains decompiler
// Type: PopupNoticeUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupNoticeUnit : BackButtonMenuBase
{
  [SerializeField]
  private Transform mContentAnchor;
  [SerializeField]
  private UIScrollView mScrollView;
  [SerializeField]
  private GameObject mCheckBoxOn;
  [SerializeField]
  private GameObject mCheckBoxOff;
  private Animator mAnimator;
  private bool isUnitExist = true;

  public bool IsFinish { get; private set; }

  public bool IsNonDispToday => this.mCheckBoxOn.activeSelf;

  public IEnumerator Initialize(OfficialInfoUnitPopup[] contentsData)
  {
    PopupNoticeUnit popupNoticeUnit = this;
    popupNoticeUnit.mAnimator = popupNoticeUnit.GetComponent<Animator>();
    Future<GameObject> ft = new ResourceObject("Prefabs/dynamic_display/dir_hime_param").Load<GameObject>();
    IEnumerator e = ft.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    DetailUnitParameter detail = ft.Result.CloneAndGetComponent<DetailUnitParameter>(popupNoticeUnit.mContentAnchor);
    List<int> intList = new List<int>();
    foreach (OfficialInfoUnitPopup officialInfoUnitPopup in contentsData)
    {
      foreach (int popupUnitId in officialInfoUnitPopup.popup_unit_ids)
      {
        if (MasterData.UnitUnit.ContainsKey(popupUnitId))
          intList.Add(popupUnitId);
      }
    }
    if (intList.Count == 0)
    {
      popupNoticeUnit.isUnitExist = false;
    }
    else
    {
      e = detail.Init(intList[Random.Range(0, intList.Count)], 3);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      foreach (Collider componentsInChild in detail.GetComponentsInChildren<Collider>())
      {
        if ((Object) componentsInChild.GetComponent<UIDragScrollView>() == (Object) null)
          componentsInChild.gameObject.AddComponent<UIDragScrollView>().scrollView = popupNoticeUnit.mScrollView;
      }
      popupNoticeUnit.mScrollView.ResetPosition();
    }
  }

  public void OnCheckBox()
  {
    if (this.IsPushAndSet())
      return;
    this.mCheckBoxOn.SetActive(!this.mCheckBoxOn.activeSelf);
    this.mCheckBoxOff.SetActive(!this.mCheckBoxOff.activeSelf);
    this.StartCoroutine(this.IsPushOff());
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.Close());
  }

  private IEnumerator Close()
  {
    this.mAnimator.SetTrigger("close");
    do
    {
      yield return (object) null;
    }
    while ((double) this.mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0);
    this.IsFinish = true;
  }

  private void playSound(string var) => Singleton<NGSoundManager>.GetInstance().PlaySe(var);

  public bool IsUnitExist() => this.isUnitExist;
}
