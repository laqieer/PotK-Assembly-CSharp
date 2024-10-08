﻿// Decompiled with JetBrains decompiler
// Type: Help0153Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

public class Help0153Menu : BackButtonMenuBase
{
  private GameObject textPrefab;
  private GameObject spritePrefab;
  public GameObject dir_text;
  public GameObject dir_text_sprite;
  public UIScrollView text_scroll;
  public UIScrollView text_sprite_scroll;
  private int titleHeight;
  private int spriteHeight;
  private int panel_width;
  private float height;

  public virtual void IbtnPopupOk()
  {
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void InitHelpPopup(
    HelpHelp help,
    UnityEngine.Sprite image,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    this.spritePrefab = spritePrefab;
    this.textPrefab = textPrefab;
    if ((Object) image != (Object) null)
    {
      this.panel_width = (int) this.text_sprite_scroll.GetComponent<UIPanel>().width;
      this.dir_text_sprite.gameObject.SetActive(true);
      this.dir_text.gameObject.SetActive(false);
      this.SetTitleText(help, this.text_sprite_scroll.transform);
      this.addSprite(image);
      this.addText(help.description);
    }
    else
    {
      this.panel_width = (int) this.text_scroll.GetComponent<UIPanel>().width;
      Debug.LogWarning((object) this.panel_width);
      this.dir_text_sprite.gameObject.SetActive(false);
      this.dir_text.gameObject.SetActive(true);
      this.SetTitleText(help, this.text_scroll.transform);
      this.addText(help.description);
    }
  }

  private void SetTitleText(HelpHelp help, Transform parent)
  {
    UILabel componentInChildren = this.textPrefab.Clone(parent).GetComponentInChildren<UILabel>();
    componentInChildren.SetText(help.title);
    componentInChildren.fontSize = 30;
    componentInChildren.width = help.title.Length * componentInChildren.fontSize + help.title.Length;
    componentInChildren.height = componentInChildren.fontSize + componentInChildren.spacingY;
    componentInChildren.pivot = UIWidget.Pivot.Center;
    this.titleHeight = componentInChildren.fontSize + componentInChildren.spacingY;
  }

  private void addSprite(UnityEngine.Sprite image)
  {
    GameObject gameObject = this.spritePrefab.Clone(this.text_sprite_scroll.transform);
    UI2DSprite componentInChildren = gameObject.GetComponentInChildren<UI2DSprite>();
    UI2DSprite ui2Dsprite = componentInChildren;
    Rect textureRect = image.textureRect;
    int width = (int) textureRect.width;
    textureRect = image.textureRect;
    int height = (int) textureRect.height;
    ui2Dsprite.SetDimensions(width, height);
    componentInChildren.sprite2D = image;
    this.spriteHeight = componentInChildren.height;
    gameObject.transform.localPosition = new Vector3(0.0f, (float) (-this.titleHeight - componentInChildren.height / 2), 0.0f);
  }

  private void addText(string bodytext)
  {
    char[] chArray = new char[1]{ '\n' };
    foreach (string text in bodytext.Split(chArray))
      this.SetText(text);
    if (this.dir_text.activeSelf)
      this.text_scroll.ResetPosition();
    else
      this.text_sprite_scroll.ResetPosition();
  }

  private void SetText(string text)
  {
    GameObject gameObject = !this.dir_text.activeSelf ? this.textPrefab.Clone(this.text_sprite_scroll.transform) : this.textPrefab.Clone(this.text_scroll.transform);
    UILabel componentInChildren1 = gameObject.GetComponentInChildren<UILabel>();
    int crlf = this.GetCRLF(text, componentInChildren1.fontSize);
    componentInChildren1.SetText(text);
    int num1 = (componentInChildren1.fontSize + componentInChildren1.spacingY) * crlf;
    componentInChildren1.height = num1;
    componentInChildren1.width = this.panel_width;
    BoxCollider componentInChildren2 = gameObject.GetComponentInChildren<BoxCollider>();
    componentInChildren2.size = new Vector3((float) componentInChildren1.width, (float) num1);
    componentInChildren2.center = new Vector3(-8f, 0.0f);
    float num2 = this.height + (float) (num1 / 2);
    gameObject.transform.localPosition = new Vector3(0.0f, -num2 - (float) this.titleHeight - (float) this.spriteHeight, 0.0f);
    this.height += (float) num1;
  }

  private int GetCRLF(string s, int fontsize)
  {
    int num = Mathf.CeilToInt((float) s.Trim().Length / Mathf.Floor((float) (this.panel_width / fontsize)));
    if (num == 0)
      num = 1;
    return num;
  }
}
