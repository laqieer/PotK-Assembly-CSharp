// Decompiled with JetBrains decompiler
// Type: Popup9992Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class Popup9992Menu : NGMenuBase
{
  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup9992Menu.\u003CInit\u003Ec__Iterator810 initCIterator810 = new Popup9992Menu.\u003CInit\u003Ec__Iterator810();
    return (IEnumerator) initCIterator810;
  }

  public virtual void IbtnOk()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    if (Object.op_Inequality((Object) instance, (Object) null))
      StartScript.Restart();
    else
      SceneManager.LoadScene("startup000_6");
  }
}
