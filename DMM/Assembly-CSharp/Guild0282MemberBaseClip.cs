// Decompiled with JetBrains decompiler
// Type: Guild0282MemberBaseClip
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Guild0282MemberBaseClip : MonoBehaviour
{
  private System.Action onCountDownStar_;
  private System.Action<string> onSetNumberColor_;

  public void countDownStar()
  {
    if (this.onCountDownStar_ == null)
      return;
    this.onCountDownStar_();
  }

  public void setEventCountDownStar(System.Action onCountDown = null) => this.onCountDownStar_ = onCountDown;

  public void setNumberColor(string col)
  {
    if (this.onSetNumberColor_ == null)
      return;
    this.onSetNumberColor_(col);
  }

  public void setEventSetNumberColor(System.Action<string> onSetNumberColor = null) => this.onSetNumberColor_ = onSetNumberColor;
}
