// Decompiled with JetBrains decompiler
// Type: PopupResultUnitBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupResultUnitBase : BackButtonPopupBase
{
  [Header("キャラクター")]
  [SerializeField]
  private GameObject lnkCharacter_;
  [SerializeField]
  private UILabel txtCharacterName_;
  [Header("他パーツ")]
  [SerializeField]
  private GameObject lnkSkill_;
  private IEnumerable<Func<PopupResultUnitBase, IEnumerator>> sequence_;
  private int? depth_;
  private PopupResultUnitBase.Mode mode_ = PopupResultUnitBase.Mode.Initialize;
  private float waitNext_;
  private bool forceNext_;

  public static Future<GameObject> createLoader() => new ResourceObject("Prefabs/battle/PopupResultUnitBase").Load<GameObject>();

  public GameObject lnkSkill => this.lnkSkill_;

  public PlayerUnit beforeUnit { get; private set; }

  public PlayerUnit afterUnit { get; private set; }

  public PlayerUnit playerUnit
  {
    get
    {
      PlayerUnit afterUnit = this.afterUnit;
      return (object) afterUnit != null ? afterUnit : this.beforeUnit;
    }
  }

  public UnitUnit masterUnit { get; private set; }

  public System.Action onNext { get; set; }

  private int forwardDepth
  {
    get
    {
      if (!this.depth_.HasValue)
        this.depth_ = new int?(this.gameObject.GetComponent<UIPanel>().depth);
      int num = this.depth_.Value + 10;
      this.depth_ = new int?(num);
      return num;
    }
  }

  public IEnumerator initialize(
    PlayerUnit beforeTarget,
    PlayerUnit afterTarget,
    IEnumerable<Func<PopupResultUnitBase, IEnumerator>> sequence)
  {
    this.beforeUnit = beforeTarget;
    this.afterUnit = afterTarget;
    this.masterUnit = this.playerUnit.unit;
    this.sequence_ = sequence;
    if ((UnityEngine.Object) this.lnkCharacter_ != (UnityEngine.Object) null)
      this.lnkCharacter_.GetComponent<UIWidget>().alpha = 0.0f;
    yield return (object) this.setCharacter();
    if (this.playerUnit != (PlayerUnit) null && (UnityEngine.Object) this.lnkCharacter_ != (UnityEngine.Object) null)
    {
      this.mode_ = PopupResultUnitBase.Mode.WaitStart;
    }
    else
    {
      this.onStartAnimationFinished();
      this.mode_ = PopupResultUnitBase.Mode.Wait;
    }
  }

  protected override void Update()
  {
    if (this.mode_ < PopupResultUnitBase.Mode.WaitStart)
      return;
    base.Update();
    switch (this.mode_)
    {
      case PopupResultUnitBase.Mode.WaitStart:
        this.mode_ = PopupResultUnitBase.Mode.Start;
        break;
      case PopupResultUnitBase.Mode.Start:
        if (this.playerUnit != (PlayerUnit) null && (UnityEngine.Object) this.lnkCharacter_ != (UnityEngine.Object) null)
        {
          TweenAlpha component = this.lnkCharacter_.GetComponent<TweenAlpha>();
          component.ResetToBeginning();
          component.enabled = true;
          this.onStartAnimationFinished();
        }
        this.mode_ = PopupResultUnitBase.Mode.Wait;
        break;
    }
  }

  private IEnumerator setCharacter()
  {
    if (!(this.playerUnit == (PlayerUnit) null) && !((UnityEngine.Object) this.lnkCharacter_ == (UnityEngine.Object) null))
    {
      if ((UnityEngine.Object) this.txtCharacterName_ != (UnityEngine.Object) null)
        this.txtCharacterName_.SetTextLocalize(this.masterUnit.name);
      MasterDataTable.UnitJob job = this.playerUnit.getJobData();
      Future<GameObject> future = this.masterUnit.LoadMypage();
      yield return (object) future.Wait();
      int depth = this.lnkCharacter_.GetComponent<UIWidget>().depth;
      GameObject go = future.Result.Clone(this.lnkCharacter_.transform);
      yield return (object) this.masterUnit.SetLargeSpriteSnap(job.ID, go, depth++);
      yield return (object) this.masterUnit.SetLargeSpriteWithMask(job.ID, go, Res.GUI._020_19_1_sozai.mask_Chara.Load<Texture2D>(), depth, -146, 36);
    }
  }

  private void onStartAnimationFinished() => Singleton<PopupManager>.GetInstance().monitorCoroutine(PopupResultUnitBase.doPlay(this));

  private static IEnumerator doPlay(PopupResultUnitBase popup)
  {
    if (popup.sequence_ != null)
    {
      foreach (Func<PopupResultUnitBase, IEnumerator> func in popup.sequence_)
      {
        if ((UnityEngine.Object) popup != (UnityEngine.Object) null)
        {
          popup.waitNext_ = Time.time + 3f;
          popup.forceNext_ = false;
          popup.onNext = new System.Action(popup.defaultClick);
        }
        IEnumerator e = func(popup);
        while (e.MoveNext() && (!((UnityEngine.Object) popup != (UnityEngine.Object) null) || !popup.forceNext_))
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
  }

  public override void onBackButton() => this.onClickedNext();

  private void defaultClick()
  {
    if ((double) Time.time <= (double) this.waitNext_)
      return;
    this.forceNext_ = true;
  }

  public void onClickedNext()
  {
    if (this.mode_ < PopupResultUnitBase.Mode.WaitStart)
      return;
    System.Action onNext = this.onNext;
    if (onNext == null)
      return;
    onNext();
  }

  public GameObject attach(GameObject prefab, bool forSkill = false)
  {
    GameObject gameObject = prefab.Clone(forSkill ? this.lnkSkill.transform : this.transform);
    UIPanel component = gameObject.GetComponent<UIPanel>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return gameObject;
    component.depth = this.forwardDepth;
    if (forSkill)
      return gameObject;
    component.SetAnchor(this.gameObject);
    return gameObject;
  }

  private enum Mode
  {
    Initialize = -1, // 0xFFFFFFFF
    WaitStart = 0,
    Start = 1,
    Wait = 2,
  }
}
