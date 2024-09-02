// Decompiled with JetBrains decompiler
// Type: Popup023413Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
public class Popup023413Menu : NGMenuBase
{
  public virtual void IbtnOk() => Singleton<PopupManager>.GetInstance().onDismiss();
}
