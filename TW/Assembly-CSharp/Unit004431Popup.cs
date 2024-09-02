// Decompiled with JetBrains decompiler
// Type: Unit004431Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit004431Popup : BackButtonMenuBase
{
  private const float UnitIconScale = 0.8f;
  [SerializeField]
  private UILabel Direction1;
  [SerializeField]
  private UILabel Direction2;
  [SerializeField]
  private Transform TakeOffThum;
  private PlayerUnit[] pUnits;
  private PlayerUnit choiceUnit;
  private PlayerItem afterGear;
  private PlayerItem beforeGear;
  private PlayerUnit TakeOffUnit;
  private int index;
  private GameObject StatusChangePopupPrefab;
  private GameObject beforeGearIcon;
  private GameObject afterGearIcon;
  private List<GameObject> beforeSkillTypeIcons;
  private List<GameObject> afterSkillTypeIcons;
  private bool isEarthMode;

  public void Init(
    PlayerUnit[] pUnits,
    PlayerUnit choiceUnit,
    PlayerItem afterGear,
    int index,
    bool isEarthMode = false)
  {
    this.pUnits = pUnits;
    this.choiceUnit = choiceUnit;
    this.afterGear = afterGear;
    this.index = index;
    this.isEarthMode = isEarthMode;
    this.beforeGear = (PlayerItem) null;
    this.TakeOffUnit = (PlayerUnit) null;
    this.StartCoroutine(this.SelectIcon());
    this.StartCoroutine(this.createPopup());
  }

  [DebuggerHidden]
  private IEnumerator createPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004431Popup.\u003CcreatePopup\u003Ec__Iterator348()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SelectIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004431Popup.\u003CSelectIcon\u003Ec__Iterator349()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetSprite()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004431Popup.\u003CSetSprite\u003Ec__Iterator34A()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    if (Object.op_Inequality((Object) this.beforeGearIcon, (Object) null))
      Object.Destroy((Object) this.beforeGearIcon);
    if (Object.op_Inequality((Object) this.afterGearIcon, (Object) null))
      Object.Destroy((Object) this.afterGearIcon);
    if (this.beforeSkillTypeIcons != null)
    {
      foreach (Object beforeSkillTypeIcon in this.beforeSkillTypeIcons)
        Object.Destroy(beforeSkillTypeIcon);
    }
    if (this.afterSkillTypeIcons != null)
    {
      foreach (Object afterSkillTypeIcon in this.afterSkillTypeIcons)
        Object.Destroy(afterSkillTypeIcon);
    }
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void ibtnOK()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.StatusPopup());
  }

  [DebuggerHidden]
  private IEnumerator StatusPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004431Popup.\u003CStatusPopup\u003Ec__Iterator34B()
    {
      \u003C\u003Ef__this = this
    };
  }
}
