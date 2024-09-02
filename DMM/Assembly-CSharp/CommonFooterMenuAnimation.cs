// Decompiled with JetBrains decompiler
// Type: CommonFooterMenuAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class CommonFooterMenuAnimation : MonoBehaviour
{
  [SerializeField]
  private Animator[] menuAnimator;
  [SerializeField]
  private TweenAlpha menuTweenAlpha;
  [SerializeField]
  private TweenPosition menuTweenPosition;
  [Header("inアニメのTrigger名")]
  [SerializeField]
  private string inTrigger;
  [Header("outアニメのTrigger名")]
  [SerializeField]
  private string outTrigger;
  [Header("TweenAlphaの設定")]
  [SerializeField]
  private CommonFooterMenuAnimation.tweenAnimaParam TweenAlphaData;
  [Header("TweenPositionの設定")]
  [SerializeField]
  private CommonFooterMenuAnimation.tweenAnimaParam TweenPositionData;

  public void OpenMenu()
  {
    this.gameObject.SetActive(true);
    UIWidget component = this.gameObject.GetComponent<UIWidget>();
    if ((UnityEngine.Object) this.menuTweenAlpha != (UnityEngine.Object) null)
    {
      this.menuTweenAlpha.onFinished.Clear();
      this.menuTweenAlpha.tweenFactor = 0.0f;
      this.menuTweenAlpha.delay = this.TweenAlphaData.inDelayTime;
      this.menuTweenAlpha.duration = this.TweenAlphaData.inDurationTime;
      component.alpha = this.menuTweenAlpha.from;
      this.menuTweenAlpha.PlayForward();
    }
    if (!((UnityEngine.Object) this.menuTweenPosition != (UnityEngine.Object) null))
      return;
    this.menuTweenPosition.onFinished.Clear();
    this.menuTweenPosition.tweenFactor = 0.0f;
    this.menuTweenPosition.delay = this.TweenPositionData.inDelayTime;
    this.menuTweenPosition.duration = this.TweenPositionData.inDurationTime;
    this.gameObject.transform.localPosition = this.menuTweenPosition.from;
    this.menuTweenPosition.PlayForward();
  }

  public void CloseMenu()
  {
    if ((UnityEngine.Object) this.menuTweenAlpha != (UnityEngine.Object) null)
    {
      this.menuTweenAlpha.tweenFactor = 1f;
      this.menuTweenAlpha.delay = this.TweenAlphaData.outDelayTime;
      this.menuTweenAlpha.duration = this.TweenAlphaData.outDurationTime;
      this.menuTweenAlpha.PlayReverse();
      this.menuTweenAlpha.AddOnFinished(new EventDelegate.Callback(this.CloseAnimeFinished));
    }
    if ((UnityEngine.Object) this.menuTweenPosition != (UnityEngine.Object) null)
    {
      this.menuTweenPosition.tweenFactor = 1f;
      this.menuTweenPosition.delay = this.TweenPositionData.outDelayTime;
      this.menuTweenPosition.duration = this.TweenPositionData.outDurationTime;
      this.menuTweenPosition.PlayReverse();
      if ((UnityEngine.Object) this.menuTweenAlpha == (UnityEngine.Object) null)
        this.menuTweenPosition.AddOnFinished(new EventDelegate.Callback(this.CloseAnimeFinished));
    }
    for (int index = 0; index < this.menuAnimator.Length; ++index)
      this.menuAnimator[index].SetTrigger(this.outTrigger);
  }

  public void CloseAnimeFinished()
  {
    if ((UnityEngine.Object) this.menuTweenAlpha != (UnityEngine.Object) null)
    {
      this.menuTweenAlpha.tweenFactor = 0.0f;
      this.menuTweenAlpha.RemoveOnFinished(new EventDelegate(new EventDelegate.Callback(this.CloseAnimeFinished)));
      this.menuTweenAlpha.ResetToBeginning();
    }
    if ((UnityEngine.Object) this.menuTweenPosition != (UnityEngine.Object) null)
    {
      this.menuTweenPosition.tweenFactor = 0.0f;
      if ((UnityEngine.Object) this.menuTweenAlpha == (UnityEngine.Object) null)
        this.menuTweenPosition.RemoveOnFinished(new EventDelegate(new EventDelegate.Callback(this.CloseAnimeFinished)));
      this.menuTweenPosition.ResetToBeginning();
    }
    for (int index = 0; index < this.menuAnimator.Length; ++index)
    {
      this.menuAnimator[index].ResetTrigger(this.outTrigger);
      this.menuAnimator[index].SetTrigger(this.inTrigger);
    }
    this.gameObject.SetActive(false);
  }

  [Serializable]
  public class tweenAnimaParam
  {
    [Header("In時のStartDelay")]
    public float inDelayTime;
    [Header("Out時のStartDelay")]
    public float outDelayTime;
    [Header("In時のDuration")]
    public float inDurationTime;
    [Header("Out時のDuration")]
    public float outDurationTime;
  }
}
