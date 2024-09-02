// Decompiled with JetBrains decompiler
// Type: ItemDetailPopupBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ItemDetailPopupBase : BackButtonMenuBase
{
  [SerializeField]
  protected Shop00742Unit unitPop;
  [SerializeField]
  protected Shop00742Item itemPop;
  [SerializeField]
  protected Shop00742Bugu buguPop;
  [SerializeField]
  protected Shop00742Key keyPop;
  [SerializeField]
  protected Shop00742BuguOther buguOtherPop;
  [SerializeField]
  protected Shop00742UnitOther unitOtherPop;
  [SerializeField]
  protected Shop00742SeasonTicket seasonTicketPop;
  private System.Action noAction;

  public void SetAction(System.Action act) => this.noAction = act;

  [DebuggerHidden]
  public IEnumerator SetInfo(MasterDataTable.CommonRewardType type, int entity_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ItemDetailPopupBase.\u003CSetInfo\u003Ec__Iterator382()
    {
      type = type,
      entity_id = entity_id,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Eentity_id = entity_id,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnNo()
  {
    if (this.noAction == null)
    {
      if (this.IsPushAndSet())
        return;
      Singleton<PopupManager>.GetInstance().onDismiss();
    }
    else
      this.noAction();
  }

  public override void onBackButton() => this.IbtnNo();
}
