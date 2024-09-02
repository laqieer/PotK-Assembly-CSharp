// Decompiled with JetBrains decompiler
// Type: Serial0141Error
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
