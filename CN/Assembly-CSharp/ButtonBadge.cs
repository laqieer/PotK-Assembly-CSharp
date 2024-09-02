// Decompiled with JetBrains decompiler
// Type: ButtonBadge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class ButtonBadge : MonoBehaviour
{
  private const string MAX_NUM_STRING = "９９";
  private int number;
  [SerializeField]
  private UILabel label;
  [SerializeField]
  private UI2DSprite badge2dSprite01;
  [SerializeField]
  private UI2DSprite badge2dSprite02;
  [SerializeField]
  private UI2DSprite badge2dSprite03;

  public int get() => this.number;

  public void set(int num)
  {
    this.number = num;
    if (this.number > 99)
    {
      this.label.SetTextLocalize("９９");
      ((Component) this.label).gameObject.SetActive(true);
      ((Component) this.badge2dSprite01).gameObject.SetActive(false);
      ((Component) this.badge2dSprite02).gameObject.SetActive(false);
      ((Component) this.badge2dSprite03).gameObject.SetActive(true);
    }
    else if (this.number > 9)
    {
      this.label.SetTextLocalize(this.number.ToString().ToConverter());
      ((Component) this.label).gameObject.SetActive(true);
      ((Component) this.badge2dSprite01).gameObject.SetActive(false);
      ((Component) this.badge2dSprite02).gameObject.SetActive(true);
      ((Component) this.badge2dSprite03).gameObject.SetActive(false);
    }
    else if (this.number > 0)
    {
      this.label.SetTextLocalize(this.number.ToString().ToConverter());
      ((Component) this.label).gameObject.SetActive(true);
      ((Component) this.badge2dSprite01).gameObject.SetActive(true);
      ((Component) this.badge2dSprite02).gameObject.SetActive(false);
      ((Component) this.badge2dSprite03).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.label).gameObject.SetActive(false);
      ((Component) this.badge2dSprite01).gameObject.SetActive(false);
      ((Component) this.badge2dSprite02).gameObject.SetActive(false);
      ((Component) this.badge2dSprite03).gameObject.SetActive(false);
    }
  }
}
