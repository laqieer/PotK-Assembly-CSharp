// Decompiled with JetBrains decompiler
// Type: Shop00714SetText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Shop00714SetText : MonoBehaviour
{
  private SetPopupText spt;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void SetText(int prev, int next)
  {
    this.spt = ((Component) this).GetComponent<SetPopupText>();
    if (!Object.op_Implicit((Object) this.spt))
      return;
    this.spt.SetText(Consts.Format(Consts.GetInstance().SHOP_00714_SET_TEXT, (IDictionary) new Hashtable()
    {
      {
        (object) "item",
        (object) Consts.GetInstance().UNIQUE_ICON_KISEKI
      },
      {
        (object) "number",
        (object) "１"
      },
      {
        (object) "unit",
        (object) Consts.GetInstance().SHOP_00710_MENU
      }
    }), false);
  }
}
