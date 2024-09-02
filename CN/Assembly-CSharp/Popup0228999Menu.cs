// Decompiled with JetBrains decompiler
// Type: Popup0228999Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class Popup0228999Menu : BackButtonMonoBehaiviour
{
  public void IbtnYes() => this.StartCoroutine(PopupUtility.BuyKiseki());

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().dismiss();

  public override void onBackButton() => this.IbtnNo();
}
