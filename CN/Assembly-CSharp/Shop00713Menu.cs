// Decompiled with JetBrains decompiler
// Type: Shop00713Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class Shop00713Menu : BackButtonMenuBase
{
  private System.Action btnAct;

  public void SetBtnAct(System.Action questChangeScene) => this.btnAct = questChangeScene;

  public virtual void IbtnPopupOK()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    if (this.btnAct == null)
      return;
    this.btnAct();
  }

  public override void onBackButton() => this.IbtnPopupOK();
}
