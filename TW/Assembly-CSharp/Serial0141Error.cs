// Decompiled with JetBrains decompiler
// Type: Serial0141Error
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Serial0141Error : MonoBehaviour
{
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtConcent;

  public void onClickOk() => Singleton<PopupManager>.GetInstance().onDismiss();

  public void ResetWords(string title, string concent)
  {
    this.TxtTitle.SetText(title);
    this.TxtConcent.SetText(concent);
  }
}
