// Decompiled with JetBrains decompiler
// Type: Startup000102Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup000102Menu : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtB;
  [SerializeField]
  protected UILabel TxtBirth;
  [SerializeField]
  protected UILabel TxtBlood;
  [SerializeField]
  protected UILabel TxtCV;
  [SerializeField]
  protected UILabel TxtDescription;
  [SerializeField]
  protected UILabel TxtH;
  [SerializeField]
  protected UILabel TxtHeight;
  [SerializeField]
  protected UILabel TxtName;
  [SerializeField]
  protected UILabel TxtNameShadow;
  [SerializeField]
  protected UILabel TxtPercentage;
  [SerializeField]
  protected UILabel TxtSeiza;
  [SerializeField]
  protected UILabel TxtW;
  [SerializeField]
  protected UILabel TxtWeight;
  [SerializeField]
  protected Transform dyn_Character;
  [SerializeField]
  protected Transform dyn_Character_shadow;
  [SerializeField]
  private UILabel TxtNavi;
  [SerializeField]
  private float interval = 5f;
  [SerializeField]
  private List<TweenAlpha> tweenList;
  [SerializeField]
  private NGTweenGaugeScale gaugeScale;
  [SerializeField]
  private TweenAlpha fade;
  [SerializeField]
  private UIRoot uiRoot;
  private List<GameObject> prefabList;
  private GameObject ImgObj;
  private GameObject ShadowImgObj;
  private bool showCharacter = true;
  private int naviSerihuNumber;
  public GameObject DownLoadVar;
  private StartupDownLoad.State state;

  private void Awake() => ModalWindow.setupRootPanel(this.uiRoot);

  public void Start()
  {
    this.fade.PlayForward();
    this.naviSerihuNumber = 0;
    this.gaugeScale.setValue(0, 100, false);
    this.TxtNavi.SetTextLocalize(Consts.Lookup("DL_NAVI1"));
  }

  [DebuggerHidden]
  public IEnumerator SetCharacterData(List<UnitUnit> dataList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup000102Menu.\u003CSetCharacterData\u003Ec__Iterator127()
    {
      dataList = dataList,
      \u003C\u0024\u003EdataList = dataList,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateImg(UnitUnit data, List<GameObject> addList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup000102Menu.\u003CCreateImg\u003Ec__Iterator128()
    {
      data = data,
      addList = addList,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003EaddList = addList,
      \u003C\u003Ef__this = this
    };
  }

  public void ChangeCharacter(List<UnitUnit> dataList, int drawNumver)
  {
    drawNumver %= dataList.Count;
    UnitUnit data = dataList[drawNumver];
    UnitCharacter character = data.character;
    this.TxtB.text = character.bust.ToConverter();
    this.TxtBirth.text = character.birthday.ToConverter();
    this.TxtBlood.text = (character.blood_type + "型").ToConverter();
    this.TxtCV.text = ("CV:" + data.cv_name).ToConverter();
    this.TxtH.text = character.hip.ToConverter();
    this.TxtHeight.text = character.height.ToConverter();
    this.TxtName.text = character.name.ToConverter();
    this.TxtNameShadow.text = character.name.ToConverter();
    this.TxtSeiza.text = character.zodiac_sign.ToConverter();
    this.TxtW.text = character.waist.ToConverter();
    this.TxtWeight.text = character.weight.ToConverter();
    this.prefabList.ForEachIndex<GameObject>((Action<GameObject, int>) ((x, n) => x.SetActive(n == drawNumver)));
  }

  public void Update()
  {
    float num = (float) StartupDownLoad.progressNum() / (float) StartupDownLoad.progressDem() * 100f;
    this.TxtPercentage.SetTextLocalize(((int) num).ToString() + "％");
    this.gaugeScale.setValue(StartupDownLoad.progressNum(), StartupDownLoad.progressDem(), false);
    switch (this.naviSerihuNumber)
    {
      case 0:
        if ((double) num > 20.0)
        {
          ++this.naviSerihuNumber;
          this.TxtNavi.SetTextLocalize(Consts.Lookup("DL_NAVI2"));
          break;
        }
        break;
      case 1:
        if ((double) num > 40.0)
        {
          ++this.naviSerihuNumber;
          this.TxtNavi.SetTextLocalize(Consts.Lookup("DL_NAVI3"));
          break;
        }
        break;
      case 2:
        if ((double) num > 60.0)
        {
          ++this.naviSerihuNumber;
          this.TxtNavi.SetTextLocalize(Consts.Lookup("DL_NAVI4"));
          break;
        }
        break;
      case 3:
        if ((double) num > 80.0)
        {
          ++this.naviSerihuNumber;
          this.TxtNavi.SetTextLocalize(Consts.Lookup("DL_NAVI5"));
          break;
        }
        break;
    }
    this.state = StartupDownLoad.state;
    switch (this.state)
    {
      case StartupDownLoad.State.Processing:
        if (StartupDownLoad.progressNum() == 0)
          break;
        this.DLStart();
        break;
      case StartupDownLoad.State.Completed:
        this.DLComplete();
        break;
    }
  }

  [DebuggerHidden]
  private IEnumerator StartShowCharacter(List<UnitUnit> dataList, int startIndex)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup000102Menu.\u003CStartShowCharacter\u003Ec__Iterator129()
    {
      dataList = dataList,
      startIndex = startIndex,
      \u003C\u0024\u003EdataList = dataList,
      \u003C\u0024\u003EstartIndex = startIndex,
      \u003C\u003Ef__this = this
    };
  }

  private float FadePlay(bool reverse = false)
  {
    float duration = 0.0f;
    if (reverse)
      this.tweenList.ForEach((Action<TweenAlpha>) (x =>
      {
        x.PlayReverse();
        if ((double) x.duration <= (double) duration)
          return;
        duration = x.duration;
      }));
    else
      this.tweenList.ForEach((Action<TweenAlpha>) (x =>
      {
        x.Play(true);
        if ((double) x.duration <= (double) duration)
          return;
        duration = x.duration;
      }));
    return duration;
  }

  private void DLStart() => this.DownLoadVar.SetActive(true);

  private void DLComplete() => this.StartCoroutine(this.SceneChange());

  [DebuggerHidden]
  private IEnumerator SceneChange()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Startup000102Menu.\u003CSceneChange\u003Ec__Iterator12A changeCIterator12A = new Startup000102Menu.\u003CSceneChange\u003Ec__Iterator12A();
    return (IEnumerator) changeCIterator12A;
  }
}
