// Decompiled with JetBrains decompiler
// Type: ReviewMessagePopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ReviewMessagePopup : MonoBehaviour
{
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtDescription;
  private string review_id;

  public void Init(string title, string message, string id)
  {
    this.review_id = id;
    ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.TxtTitle.SetText(title);
    this.TxtDescription.SetText(message);
    ((Component) this).GetComponent<UIWidget>().alpha = 1f;
  }

  public void btnReview() => this.StartCoroutine(this.goReview());

  public void btnAfter() => Singleton<PopupManager>.GetInstance().onDismiss();

  public void btnRefuse() => this.StartCoroutine(this.goRefuse());

  [DebuggerHidden]
  private IEnumerator goReview()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ReviewMessagePopup.\u003CgoReview\u003Ec__Iterator1F1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator goRefuse()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ReviewMessagePopup.\u003CgoRefuse\u003Ec__Iterator1F2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
