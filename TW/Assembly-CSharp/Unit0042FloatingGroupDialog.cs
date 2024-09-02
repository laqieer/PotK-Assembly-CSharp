// Decompiled with JetBrains decompiler
// Type: Unit0042FloatingGroupDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Unit0042FloatingGroupDialog : MonoBehaviour
{
  [SerializeField]
  private UILabel txtGroupName;
  [SerializeField]
  private UILabel txtDescription;
  [SerializeField]
  private UISprite slcGroupType;
  [SerializeField]
  private SpriteSelectDirect spriteSelectDirect;
  private TweenAlpha tweenAlpha;
  private bool show;

  protected void Awake()
  {
    this.tweenAlpha = ((Component) this).gameObject.GetComponent<TweenAlpha>();
    ((Component) this.tweenAlpha).gameObject.SetActive(false);
  }

  private void Update()
  {
    if (!Input.GetMouseButtonDown(0) || !this.show)
      return;
    this.Hide();
  }

  public void Init(string name, string descript, string spriteName)
  {
    this.txtGroupName.SetTextLocalize(name);
    this.txtDescription.SetTextLocalize(descript);
    this.spriteSelectDirect.SetSpriteName<string>(spriteName);
  }

  public void Show()
  {
    ((Component) this).gameObject.SetActive(true);
    ((IEnumerable<UITweener>) ((Component) this).gameObject.GetComponentsInChildren<UITweener>()).ForEach<UITweener>((Action<UITweener>) (c =>
    {
      ((Behaviour) c).enabled = true;
      c.onFinished.Clear();
      c.PlayForward();
    }));
    this.show = true;
  }

  public void Hide()
  {
    this.show = false;
    UITweener[] tweens = ((Component) this).gameObject.GetComponentsInChildren<UITweener>();
    if (tweens.Length <= 0)
      return;
    int finishCount = 0;
    EventDelegate.Callback onFinish = (EventDelegate.Callback) (() =>
    {
      if (++finishCount < tweens.Length)
        return;
      ((Component) this).gameObject.SetActive(false);
    });
    ((IEnumerable<UITweener>) tweens).ForEach<UITweener>((Action<UITweener>) (c =>
    {
      c.onFinished.Clear();
      c.AddOnFinished(onFinish);
      c.PlayReverse();
    }));
  }
}
