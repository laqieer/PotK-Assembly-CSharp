// Decompiled with JetBrains decompiler
// Type: Shop00714SetText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Shop00714SetText : MonoBehaviour
{
  private SetPopupText spt;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void SetText(int price)
  {
    if (!(bool) (Object) this.spt)
      this.spt = this.GetComponent<SetPopupText>();
    if (!(bool) (Object) this.spt)
      return;
    this.spt.SetText(Consts.Format(Consts.GetInstance().SHOP_00714_SET_TEXT, (IDictionary) new Hashtable()
    {
      {
        (object) "item",
        (object) Consts.GetInstance().UNIQUE_ICON_KISEKI
      },
      {
        (object) "number",
        (object) price.ToLocalizeNumberText()
      },
      {
        (object) "unit",
        (object) Consts.GetInstance().SHOP_00710_MENU
      }
    }), false);
  }
}
