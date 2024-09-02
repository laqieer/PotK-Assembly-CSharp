// Decompiled with JetBrains decompiler
// Type: Quest002152Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest002152Menu : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtDescription;
  [SerializeField]
  protected UILabel TxtLiberation;
  public GameObject popupPrefab002152;
  public int Pop;

  public virtual void IbtnPopupClose()
  {
  }

  public void popupIntimacy()
  {
    Singleton<PopupManager>.GetInstance().openAlert(this.popupPrefab002152);
  }

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002152Menu.\u003CInit\u003Ec__Iterator19E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (this.Pop != 4)
      return;
    this.popupPrefab002152.GetComponent<Quest002152popup>().PopupSetiing();
    this.popupIntimacy();
    this.Pop = 0;
  }

  public void PopPlus() => ++this.Pop;
}
