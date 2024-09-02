// Decompiled with JetBrains decompiler
// Type: ButtonBadge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public class ButtonBadge : MonoBehaviour
{
  private int number;
  [SerializeField]
  private UILabel label;
  [SerializeField]
  private UI2DSprite badge2dSprite01;
  [SerializeField]
  private UI2DSprite badge2dSprite02;
  [SerializeField]
  private UI2DSprite badge2dSprite03;
  private const string MAX_NUM_STRING = "９９";

  public int get() => this.number;

  public void set(int num)
  {
    this.number = num;
    if (this.number > 99)
    {
      this.label.SetTextLocalize("９９");
      this.label.gameObject.SetActive(true);
      this.badge2dSprite01.gameObject.SetActive(false);
      this.badge2dSprite02.gameObject.SetActive(false);
      this.badge2dSprite03.gameObject.SetActive(true);
    }
    else if (this.number > 9)
    {
      this.label.SetTextLocalize(this.number.ToString().ToConverter());
      this.label.gameObject.SetActive(true);
      this.badge2dSprite01.gameObject.SetActive(false);
      this.badge2dSprite02.gameObject.SetActive(true);
      this.badge2dSprite03.gameObject.SetActive(false);
    }
    else if (this.number > 0)
    {
      this.label.SetTextLocalize(this.number.ToString().ToConverter());
      this.label.gameObject.SetActive(true);
      this.badge2dSprite01.gameObject.SetActive(true);
      this.badge2dSprite02.gameObject.SetActive(false);
      this.badge2dSprite03.gameObject.SetActive(false);
    }
    else
    {
      this.label.gameObject.SetActive(false);
      this.badge2dSprite01.gameObject.SetActive(false);
      this.badge2dSprite02.gameObject.SetActive(false);
      this.badge2dSprite03.gameObject.SetActive(false);
    }
  }
}
