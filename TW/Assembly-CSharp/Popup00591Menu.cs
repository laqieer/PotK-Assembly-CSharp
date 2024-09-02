// Decompiled with JetBrains decompiler
// Type: Popup00591Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup00591Menu : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel m_Warning;
  [SerializeField]
  private UILabel m_Description;
  [SerializeField]
  private UIGrid m_Grid;
  private System.Action m_YesCallback;
  private static readonly string COLOR_TAG_GREEN = "[00ff00]{0}[-]";
  private static readonly string COLOR_TAG_RED = "[ff0000]{0}[-]";

  [DebuggerHidden]
  public IEnumerator Init(
    GameCore.ItemInfo before,
    GameCore.ItemInfo after,
    List<InventoryItem> materials,
    System.Action yesCallback,
    GameObject iconPrefab = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup00591Menu.\u003CInit\u003Ec__Iterator3F5()
    {
      iconPrefab = iconPrefab,
      yesCallback = yesCallback,
      materials = materials,
      after = after,
      before = before,
      \u003C\u0024\u003EiconPrefab = iconPrefab,
      \u003C\u0024\u003EyesCallback = yesCallback,
      \u003C\u0024\u003Ematerials = materials,
      \u003C\u0024\u003Eafter = after,
      \u003C\u0024\u003Ebefore = before,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnYes()
  {
    if (this.m_YesCallback == null)
      return;
    this.m_YesCallback();
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
