﻿// Decompiled with JetBrains decompiler
// Type: Unit0043Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0043Menu : BackButtonMenuBase
{
  private UnitUnit targetUnit;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel TxtCvName;
  [SerializeField]
  protected UILabel TxtIllustratorname;
  [SerializeField]
  protected GameObject DynCharacter;
  [SerializeField]
  protected Transform weaponTypeIconParent;
  [SerializeField]
  protected GameObject weaponTypeIconPrefab;
  private GameObject goWeaponType;
  [SerializeField]
  private UI2DSprite rarityStarsTypeIconParent;
  [SerializeField]
  private GameObject containerR;
  [SerializeField]
  private GameObject containerL;

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  public IEnumerator Init(UnitUnit unit, bool isSame, CommonElement element = CommonElement.none)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0043Menu.\u003CInit\u003Ec__Iterator2C3()
    {
      unit = unit,
      element = element,
      isSame = isSame,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003Eelement = element,
      \u003C\u0024\u003EisSame = isSame,
      \u003C\u003Ef__this = this
    };
  }

  private GameObject createIcon(GameObject prefab, Transform trans)
  {
    GameObject icon = prefab.Clone(trans);
    UI2DSprite componentInChildren1 = icon.GetComponentInChildren<UI2DSprite>();
    UI2DSprite componentInChildren2 = ((Component) trans).GetComponentInChildren<UI2DSprite>();
    componentInChildren1.SetDimensions(componentInChildren2.width, componentInChildren2.height);
    componentInChildren1.depth += 1000;
    ((Component) componentInChildren1).transform.localPosition = Vector3.zero;
    return icon;
  }

  [DebuggerHidden]
  public IEnumerator SetCharacterLargeImage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0043Menu.\u003CSetCharacterLargeImage\u003Ec__Iterator2C4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onEndScene()
  {
    NGSoundManager instanceOrNull = Singleton<NGSoundManager>.GetInstanceOrNull();
    if (!Object.op_Inequality((Object) instanceOrNull, (Object) null))
      return;
    instanceOrNull.stopVoice();
  }
}
