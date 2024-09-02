// Decompiled with JetBrains decompiler
// Type: Popup05021Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

public class Popup05021Menu : BackButtonMenuBase
{
  private System.Action onBackCallback;

  public void Init(System.Action onBackCallback) => this.onBackCallback = onBackCallback;

  public override void onBackButton() => this.IbtnNo();

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    System.Action onBackCallback = this.onBackCallback;
    if (onBackCallback == null)
      return;
    onBackCallback();
  }

  public void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Persist.earthBattleEnvironment.Delete();
  }
}
