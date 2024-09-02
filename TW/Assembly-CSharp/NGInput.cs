// Decompiled with JetBrains decompiler
// Type: NGInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class NGInput : Singleton<NGInput>
{
  [SerializeField]
  private bool disable;
  private float timer;

  public bool Disable
  {
    get => this.disable;
    set
    {
      if (value)
      {
        this.timer = 0.5f;
        if (!this.disable)
          this.OpenDisable();
        this.disable = true;
      }
      else
      {
        if ((double) this.timer >= 0.0)
          return;
        this.disable = false;
      }
    }
  }

  private void OpenDisable()
  {
    Singleton<CommonRoot>.GetInstance().isTouchBlockAutoClose = true;
    this.StartCoroutine(this.CloseDisable());
  }

  [DebuggerHidden]
  private IEnumerator CloseDisable()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGInput.\u003CCloseDisable\u003Ec__IteratorB54()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Initialize() => this.disable = false;

  public bool GetKeyUp(string code) => !this.Disable && Input.GetKeyUp(code);

  public bool GetKeyUp(KeyCode code) => !this.Disable && Input.GetKeyUp(code);
}
