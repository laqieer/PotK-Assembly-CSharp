﻿// Decompiled with JetBrains decompiler
// Type: NGMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class NGMenuBase : MonoBehaviour
{
  public bool IsPush { get; set; }

  public bool isActive
  {
    get => this.gameObject.activeSelf;
    set => this.gameObject.SetActive(value);
  }

  protected virtual void changeScene(string name, bool isStack = true, bool isClearStack = false)
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    if (isClearStack)
      instance.clearStack();
    instance.changeScene(name, isStack);
  }

  public static void backSceneBase()
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    if (instance.backScene())
      return;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = -1;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex = -1;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGSceneManager>.GetInstance().clearStack();
    instance.changeScene(Singleton<CommonRoot>.GetInstance().startScene, false, Singleton<CommonRoot>.GetInstance().startSceneArgs);
  }

  protected virtual void backScene() => NGMenuBase.backSceneBase();

  protected new Coroutine StartCoroutine(IEnumerator e) => Singleton<NGSceneManager>.GetInstance().StartCoroutine(e);

  public bool IsPushAndSet()
  {
    if (this.IsPush)
      return true;
    this.IsPush = true;
    return false;
  }

  protected IEnumerator IsPushOff()
  {
    yield return (object) new WaitForSeconds(0.1f);
    this.IsPush = false;
  }
}
