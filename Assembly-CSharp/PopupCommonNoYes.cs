// Decompiled with JetBrains decompiler
// Type: PopupCommonNoYes
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Linq;
using UnityEngine;

public class PopupCommonNoYes : BackButtonMonoBehaiviour
{
  [SerializeField]
  protected UILabel title;
  [SerializeField]
  protected UILabel message;
  [SerializeField]
  private UILabel message02;
  private bool callbackAfterClose;
  private System.Action yes;
  private System.Action no;

  public void OnYes()
  {
    if (!this.callbackAfterClose)
      this.yes();
    Singleton<PopupManager>.GetInstance().dismiss();
    if (!this.callbackAfterClose)
      return;
    this.yes();
  }

  public void IbtnNo()
  {
    if (!this.callbackAfterClose)
      this.no();
    Singleton<PopupManager>.GetInstance().dismiss();
    if (!this.callbackAfterClose)
      return;
    this.no();
  }

  public override void onBackButton() => this.IbtnNo();

  public void SetMessageAligment(NGUIText.Alignment alignment) => this.message.alignment = alignment;

  public void SetDelegate(System.Action yes = null, System.Action no = null)
  {
    this.yes = yes ?? new System.Action(PopupCommonNoYes.defaultCallback);
    this.no = no ?? new System.Action(PopupCommonNoYes.defaultCallback);
  }

  public static void Show(
    string title,
    string message,
    System.Action yes = null,
    System.Action no = null,
    NGUIText.Alignment alignment = NGUIText.Alignment.Center,
    string messageB = null,
    NGUIText.Alignment alignmentB = NGUIText.Alignment.Left,
    bool callbackAfterClose = false,
    bool isNonSe = false)
  {
    GameObject prefab = Resources.Load<GameObject>("Prefabs/popup_common_no_yes");
    PopupCommonNoYes component = Singleton<PopupManager>.GetInstance().open(prefab, isNonSe: isNonSe).GetComponent<PopupCommonNoYes>();
    if ((UnityEngine.Object) component.GetComponent<UIWidget>() != (UnityEngine.Object) null)
      component.GetComponent<UIWidget>().alpha = 0.0f;
    component.title.SetText(title);
    component.message.SetText(message);
    component.SetMessageAligment(alignment);
    int count1 = !string.IsNullOrEmpty(component.message.text) ? component.message.text.Count<char>((Func<char, bool>) (c => c == '\n')) + 1 : 0;
    if (!string.IsNullOrEmpty(messageB) && (UnityEngine.Object) component.message02 != (UnityEngine.Object) null)
    {
      component.message02.gameObject.SetActive(true);
      component.message02.SetText(messageB);
      component.message02.alignment = alignmentB;
      int count2 = component.message02.text.Count<char>((Func<char, bool>) (c => c == '\n')) + 1;
      component.message.SetText(component.message.text + new string('\n', count2));
      component.message02.SetText(new string('\n', count1) + component.message02.text);
    }
    else if (count1 > 0 && count1 < 5)
      component.message.SetText(component.message.text + new string('\n', 5 - count1));
    component.callbackAfterClose = callbackAfterClose;
    component.SetDelegate(yes, no);
  }

  public static void defaultCallback()
  {
  }
}
