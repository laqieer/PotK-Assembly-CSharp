// Decompiled with JetBrains decompiler
// Type: Unit0042FloatingSkillDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    this.txt_Name.SetTextLocalize("加入技能名");
    this.txt_Description.SetTextLocalize("加入技能说明");
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
