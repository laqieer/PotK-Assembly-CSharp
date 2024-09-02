// Decompiled with JetBrains decompiler
// Type: Popup0228999Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
public class Popup0228999Menu : BackButtonMonoBehaiviour
{
  public void IbtnYes() => this.StartCoroutine(PopupUtility.BuyKiseki());

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().dismiss();

  public override void onBackButton() => this.IbtnNo();
}
