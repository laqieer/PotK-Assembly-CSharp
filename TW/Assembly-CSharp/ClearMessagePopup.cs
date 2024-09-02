// Decompiled with JetBrains decompiler
// Type: ClearMessagePopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ClearMessagePopup : MonoBehaviour
{
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UIButton ibtnOK;

  public void Init(string title, string description, EventDelegate del)
  {
    ((Component) this).gameObject.GetComponent<UIWidget>().alpha = 0.0f;
    this.TxtTitle.SetText(title);
    this.TxtDescription.SetText(description);
    if (del != null)
      EventDelegate.Set(this.ibtnOK.onClick, del);
    ((Component) this).gameObject.GetComponent<UIWidget>().alpha = 1f;
  }

  public void btnOK() => Singleton<PopupManager>.GetInstance().onDismiss();
}
