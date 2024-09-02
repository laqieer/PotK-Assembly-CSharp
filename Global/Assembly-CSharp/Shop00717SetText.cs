// Decompiled with JetBrains decompiler
// Type: Shop00717SetText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Shop00717SetText : MonoBehaviour
{
  private SetPopupText spt;

  public void SetText(int next)
  {
    this.spt = ((Component) this).GetComponent<SetPopupText>();
    if (!Object.op_Implicit((Object) this.spt))
      return;
    this.spt.SetText(Consts.Lookup("SHOP_00717_SET_TEXT", (IDictionary) new Hashtable()
    {
      {
        (object) "item",
        (object) Consts.Lookup("UNIQUE_ICON_KISEKI")
      },
      {
        (object) "number",
        (object) "1"
      },
      {
        (object) "unit",
        (object) Consts.Lookup("SHOP_00710_MENU")
      },
      {
        (object) nameof (next),
        (object) next
      }
    }), false);
  }
}
