// Decompiled with JetBrains decompiler
// Type: AnimatedColor
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (UIWidget))]
[ExecuteInEditMode]
public class AnimatedColor : MonoBehaviour
{
  public Color color = Color.white;
  private UIWidget mWidget;

  private void OnEnable()
  {
    this.mWidget = ((Component) this).GetComponent<UIWidget>();
    this.LateUpdate();
  }

  private void LateUpdate() => this.mWidget.color = this.color;
}
