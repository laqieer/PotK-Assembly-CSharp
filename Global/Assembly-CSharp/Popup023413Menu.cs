﻿// Decompiled with JetBrains decompiler
// Type: Popup023413Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
public class Popup023413Menu : NGMenuBase
{
  public virtual void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();
}
