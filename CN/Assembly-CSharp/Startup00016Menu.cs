// Decompiled with JetBrains decompiler
// Type: Startup00016Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup00016Menu : NGMenuBase
{
  [SerializeField]
  private UITextList textList;
  private string text;
  private bool flag;

  public void IbtnPopupClose()
  {
  }

  public void InitScene()
  {
    this.text = Consts.GetInstance().PRIVACY_POLICY;
    this.textList.Add(this.text);
    this.textList.scrollValue = 0.0f;
    this.flag = true;
  }

  [DebuggerHidden]
  public IEnumerator InitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00016Menu.\u003CInitSceneAsync\u003Ec__Iterator185()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (!this.flag || (double) this.textList.scrollValue == 0.0)
      return;
    this.flag = false;
    this.textList.scrollValue = 0.0f;
  }
}
