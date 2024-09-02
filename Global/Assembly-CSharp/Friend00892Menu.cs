// Decompiled with JetBrains decompiler
// Type: Friend00892Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Friend00892Menu : BackButtonMenuBase
{
  private bool is_back = true;

  public void SetBack(bool back) => this.is_back = back;

  [DebuggerHidden]
  private IEnumerator BackSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00892Menu.\u003CBackSceneAsync\u003Ec__Iterator441()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    this.StartCoroutine(this.BackSceneAsync());
  }

  public override void onBackButton() => this.IbtnOk();
}
