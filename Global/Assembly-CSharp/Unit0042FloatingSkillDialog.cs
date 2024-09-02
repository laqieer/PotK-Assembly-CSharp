// Decompiled with JetBrains decompiler
// Type: Unit0042FloatingSkillDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Unit0042FloatingSkillDialog : MonoBehaviour
{
  public UILabel txt_Name;
  public UILabel txt_Description;
  public UI2DSprite dyn_Type;
  public UI2DSprite dyn_Property01;
  public UI2DSprite dyn_Property02;
  private TweenAlpha tweenAlpha;

  protected void Awake()
  {
    this.tweenAlpha = ((Component) this).gameObject.GetComponent<TweenAlpha>();
    ((Component) this.tweenAlpha).gameObject.SetActive(false);
  }

  public void Show()
  {
    this.txt_Name.SetTextLocalize("スキル名が入るよ");
    this.txt_Description.SetTextLocalize("スキル説明が入るよ");
    ((Component) this.dyn_Type).gameObject.SetActive(false);
    ((Component) this.dyn_Property01).gameObject.SetActive(false);
    ((Component) this.dyn_Property02).gameObject.SetActive(false);
    ((Component) this.tweenAlpha).gameObject.SetActive(true);
    this.tweenAlpha.onFinished.Clear();
    this.tweenAlpha.PlayForward();
  }

  public void Hide()
  {
    ((Component) this.tweenAlpha).gameObject.SetActive(true);
    EventDelegate.Add(this.tweenAlpha.onFinished, (EventDelegate.Callback) (() => ((Component) this.tweenAlpha).gameObject.SetActive(false)));
    this.tweenAlpha.PlayReverse();
  }
}
