// Decompiled with JetBrains decompiler
// Type: Guide01142Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guide01142Menu : Unit00443Menu
{
  [SerializeField]
  private GearGear gear_;
  [SerializeField]
  protected UILabel TxtNumber;
  [SerializeField]
  protected GameObject dirNumber;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GearGear gear, bool isDispNumber)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01142Menu.\u003ConStartSceneAsync\u003Ec__Iterator5BA()
    {
      gear = gear,
      isDispNumber = isDispNumber,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003EisDispNumber = isDispNumber,
      \u003C\u003Ef__this = this
    };
  }

  public void SetNumber(GearGear gear)
  {
    this.TxtNumber.SetTextLocalize("NO." + (gear.history_group_number % 1000).ToString().PadLeft(3, '0'));
  }

  public override void IbtnZoom()
  {
    if (this.IsPushAndSet())
      return;
    Unit00446Scene.changeScene(true, this.gear_);
  }

  public override void EndScene()
  {
  }
}
