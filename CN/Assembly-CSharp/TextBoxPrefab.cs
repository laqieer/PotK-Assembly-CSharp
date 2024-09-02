// Decompiled with JetBrains decompiler
// Type: TextBoxPrefab
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TextBoxPrefab : MonoBehaviour
{
  [SerializeField]
  public GameObject uiDescription;
  private int panel_width;
  private int height;

  public void SetTextBox(GameObject instance, string text, int panel_width)
  {
    UILabel component1 = this.uiDescription.GetComponent<UILabel>();
    component1.SetText(text);
    this.panel_width = panel_width;
    int crlf = this.GetCRLF(text, component1.fontSize);
    int num1 = (component1.fontSize + component1.spacingY) * crlf;
    BoxCollider component2 = this.uiDescription.GetComponent<BoxCollider>();
    component2.size = new Vector3((float) component1.width, (float) num1);
    component2.center = new Vector3(-8f, 0.0f);
    float num2 = (float) this.height + (float) (num1 / 2);
    instance.transform.localPosition = new Vector3(0.0f, -num2, 0.0f);
    this.height += num1;
  }

  private int GetCRLF(string s, int fontsize)
  {
    int crlf = Mathf.CeilToInt((float) s.Trim().Length / Mathf.Floor((float) (this.panel_width / fontsize)));
    if (crlf == 0)
      crlf = 1;
    return crlf;
  }
}
