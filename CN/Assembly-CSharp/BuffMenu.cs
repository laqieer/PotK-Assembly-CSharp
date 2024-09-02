// Decompiled with JetBrains decompiler
// Type: BuffMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class BuffMenu : MonoBehaviour
{
  private GameObject TextBuffPrefab;
  [SerializeField]
  public UISprite box;
  private bool isBirthDay;
  private bool isPvp;
  private int height;

  public void InitBuffPopup(
    List<Bonus> bonusList,
    GameObject TextBuffPrefab,
    bool isBirthDay = true,
    bool isPvp = false)
  {
    this.TextBuffPrefab = TextBuffPrefab;
    this.isBirthDay = isBirthDay;
    this.isPvp = isPvp;
    foreach (Bonus bonus in bonusList)
      this.SetText(bonus);
    this.height += 30;
    this.box.height = this.height;
    BoxCollider component = ((Component) this.box).GetComponent<BoxCollider>();
    component.size = new Vector3((float) this.box.width, (float) this.box.height);
    component.center = new Vector3(-8f, 0.0f);
  }

  private void SetText(Bonus data)
  {
    GameObject gameObject = this.TextBuffPrefab.Clone(((Component) this.box).transform);
    TextBuffBoxPrefab component1 = gameObject.GetComponent<TextBuffBoxPrefab>();
    UILabel component2 = component1.uiDescription.GetComponent<UILabel>();
    string str1 = data.DisplayName(this.isPvp);
    component2.SetText(str1);
    int crlf1 = this.GetCRLF(str1, component2.fontSize, component2.width);
    int num1 = (component2.fontSize + component2.spacingY) * crlf1;
    UILabel component3 = component1.uiTime.GetComponent<UILabel>();
    string str2 = data.RemainingTime();
    component3.SetText(str2);
    int crlf2 = this.GetCRLF(str2, component3.fontSize, component3.width);
    int num2 = (component3.fontSize + component3.spacingY) * crlf2;
    int num3 = num1 < num2 ? num2 : num1;
    float num4 = (float) this.height - (float) (num3 / 2);
    gameObject.transform.localPosition = new Vector3(0.0f, -num4, 0.0f);
    this.height += num3;
  }

  private int GetCRLF(string s, int fontsize, int panel_width)
  {
    int crlf = Mathf.CeilToInt((float) s.Trim().Length / Mathf.Floor((float) (panel_width / fontsize)));
    if (crlf == 0)
      crlf = 1;
    return crlf;
  }
}
