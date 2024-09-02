// Decompiled with JetBrains decompiler
// Type: SM.SlotModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class SlotModule : KeyCompare
  {
    public SlotModuleSlot[] slot;

    public SlotModule()
    {
    }

    public SlotModule(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<SlotModuleSlot> slotModuleSlotList = new List<SlotModuleSlot>();
      foreach (object json1 in (List<object>) json[nameof (slot)])
        slotModuleSlotList.Add(json1 != null ? new SlotModuleSlot((Dictionary<string, object>) json1) : (SlotModuleSlot) null);
      this.slot = slotModuleSlotList.ToArray();
    }
  }
}
