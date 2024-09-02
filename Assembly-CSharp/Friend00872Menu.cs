// Decompiled with JetBrains decompiler
// Type: Friend00872Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Friend00872Menu : NGMenuBase
{
  [SerializeField]
  private UILabel TxtDescription1Left;

  public void SetTxtDescription1Left(string str) => this.TxtDescription1Left.SetTextLocalize(str);

  public virtual void IbtnOk()
  {
  }
}
