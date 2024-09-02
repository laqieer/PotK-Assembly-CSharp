// Decompiled with JetBrains decompiler
// Type: Bugu0053GearPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0053GearPopup : ItemDetailPopupBase
{
  private Bugu0053DirRecipePopup root;
  [SerializeField]
  private UIButton[] IbtnClose;

  [DebuggerHidden]
  public virtual IEnumerator Init(
    Bugu0053DirRecipePopup recipePopup,
    MasterDataTable.CommonRewardType type,
    int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053GearPopup.\u003CInit\u003Ec__Iterator31E()
    {
      recipePopup = recipePopup,
      type = type,
      id = id,
      \u003C\u0024\u003ErecipePopup = recipePopup,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  public override void IbtnNo()
  {
    if (Object.op_Inequality((Object) this.root, (Object) null))
      Singleton<CommonRoot>.GetInstance().StartCoroutine(this.root.BackKeyEnable());
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
