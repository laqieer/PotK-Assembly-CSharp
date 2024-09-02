// Decompiled with JetBrains decompiler
// Type: SM.SlotModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
