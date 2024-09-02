// Decompiled with JetBrains decompiler
// Type: Shop999101SetText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Shop999101SetText : MonoBehaviour
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
    this.spt.SetText(Consts.GetInstance().SHOP_999101_SET_TEXT, false);
  }
}
