// Decompiled with JetBrains decompiler
// Type: NGTweenParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGTweenParts : MonoBehaviour
{
  public bool includeTweenChildren = true;
  public bool autoSetOnTweenFinished;
  public int findTweensTimeOutFrame = 5;
  private UITweener[] tweens;
  [SerializeField]
  protected bool mIsActive;
  public float timeOutTime = 0.5f;
  private bool isRunning;
  private Queue<bool> runQueue = new Queue<bool>();
  private bool isDestroy;

  private void Awake() => this.resetActive(this.gameObject.activeSelf);

  public bool isActive
  {
    get => this.mIsActive;
    set
    {
      if (this.mIsActive == value)
        return;
      this.forceActive(value);
    }
  }

  public void resetActive(bool v)
  {
    if (this.gameObject.activeSelf != v)
      this.gameObject.SetActive(v);
    this.mIsActive = v;
  }

  public void forceActive(bool v)
  {
    this.mIsActive = v;
    if (this.runQueue.Count > 0 || this.isRunning)
    {
      this.runQueue.Enqueue(v);
    }
    else
    {
      this.isRunning = true;
      this.gameObject.SetActive(true);
      this.playTweensDelay(v);
    }
  }

  private IEnumerator doPlayTweens(bool v)
  {
    NGTweenParts ngTweenParts = this;
    int count = ngTweenParts.findTweensTimeOutFrame;
    while (ngTweenParts.tweens == null || ngTweenParts.tweens.Length == 0)
    {
      if (ngTweenParts.isDestroy)
      {
        yield break;
      }
      else
      {
        try
        {
          ngTweenParts.tweens = NGTween.findTweeners(ngTweenParts.gameObject, ngTweenParts.includeTweenChildren);
        }
        catch (Exception ex)
        {
          ngTweenParts.onTweenFinished();
          yield break;
        }
        if (ngTweenParts.autoSetOnTweenFinished)
          NGTween.setOnTweenFinished(ngTweenParts.tweens, (MonoBehaviour) ngTweenParts);
        if (--count >= 0)
          yield return (object) 0;
        else
          break;
      }
    }
    ngTweenParts.playTweens(v);
    int nbQ = ngTweenParts.runQueue.Count;
    yield return (object) new WaitForSeconds(ngTweenParts.timeOutTime);
    if (ngTweenParts.runQueue.Count >= nbQ)
      ngTweenParts.onTweenFinished();
  }

  private void playTweensDelay(bool v)
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    if (!(bool) (UnityEngine.Object) instance)
      return;
    instance.StartCoroutine(this.doPlayTweens(v));
  }

  private void playTweens(bool v)
  {
    if (this.tweens == null)
    {
      this.tweens = NGTween.findTweeners(this.gameObject, this.includeTweenChildren);
      if (this.autoSetOnTweenFinished)
        NGTween.setOnTweenFinished(this.tweens, (MonoBehaviour) this);
    }
    bool flag1 = NGTween.playTweens(this.tweens, NGTween.Kind.START_END, !v);
    bool isTweensError = NGTween.isTweensError;
    bool flag2;
    bool flag3;
    if (v)
    {
      flag2 = NGTween.playTweens(this.tweens, NGTween.Kind.START) | flag1;
      flag3 = NGTween.isTweensError | isTweensError;
    }
    else
    {
      flag2 = NGTween.playTweens(this.tweens, NGTween.Kind.END) | flag1;
      flag3 = NGTween.isTweensError | isTweensError;
    }
    if (!flag2 && !this.mIsActive)
      this.gameObject.SetActive(this.mIsActive);
    if (!flag3)
      return;
    this.tweens = (UITweener[]) null;
  }

  public void onTweenFinished()
  {
    if (this.isDestroy)
      return;
    if (this.runQueue.Count > 0)
    {
      this.playTweensDelay(this.runQueue.Dequeue());
    }
    else
    {
      BattleMonoBehaviour[] componentsInChildren1 = this.GetComponentsInChildren<BattleMonoBehaviour>();
      NGBattleMenuBase[] componentsInChildren2 = this.GetComponentsInChildren<NGBattleMenuBase>();
      if (this.mIsActive || this.checkBattleMonoBehaviour(componentsInChildren1, componentsInChildren2))
      {
        this.gameObject.SetActive(this.mIsActive);
        this.isRunning = false;
      }
      else
        this.StartCoroutine(this.waitBattleMonoBehaviour(componentsInChildren1, componentsInChildren2));
    }
  }

  private void OnDestroy() => this.isDestroy = true;

  private IEnumerator waitBattleMonoBehaviour(
    BattleMonoBehaviour[] bml,
    NGBattleMenuBase[] mbl)
  {
    do
    {
      yield return (object) null;
    }
    while (!this.checkBattleMonoBehaviour(bml, mbl));
    this.onTweenFinished();
  }

  private bool checkBattleMonoBehaviour(BattleMonoBehaviour[] bml, NGBattleMenuBase[] mbl)
  {
    foreach (BattleMonoBehaviour battleMonoBehaviour in bml)
    {
      if (!battleMonoBehaviour.isStartInitialized())
        return false;
    }
    foreach (NGBattleMenuBase ngBattleMenuBase in mbl)
    {
      if (!ngBattleMenuBase.isStartInitialized())
        return false;
    }
    return true;
  }
}
