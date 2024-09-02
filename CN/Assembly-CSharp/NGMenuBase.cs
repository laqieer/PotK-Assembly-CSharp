// Decompiled with JetBrains decompiler
// Type: NGMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class NGMenuBase : MonoBehaviour
{
  public bool IsPush { get; set; }

  public bool isActive
  {
    get => ((Component) this).gameObject.activeSelf;
    set => ((Component) this).gameObject.SetActive(value);
  }

  protected virtual void changeScene(string name, bool isStack = true, bool isClearStack = false)
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    if (isClearStack)
      instance.clearStack();
    instance.changeScene(name, isStack);
  }

  protected virtual void backScene()
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    if (instance.backScene())
      return;
    instance.changeScene(Singleton<CommonRoot>.GetInstance().startScene);
  }

  protected Coroutine StartCoroutine(IEnumerator e)
  {
    return Singleton<NGSceneManager>.GetInstance().StartCoroutine(e);
  }

  public bool IsPushAndSet()
  {
    if (this.IsPush)
      return true;
    this.IsPush = true;
    return false;
  }
}
