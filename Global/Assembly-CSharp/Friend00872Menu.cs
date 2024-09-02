// Decompiled with JetBrains decompiler
// Type: Friend00872Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Friend00872Menu : NGMenuBase
{
  [SerializeField]
  private UILabel TxtDescription1Left;

  public void SetTxtDescription1Left(string str) => this.TxtDescription1Left.SetTextLocalize(str);

  public virtual void IbtnOk()
  {
  }
}
