// Decompiled with JetBrains decompiler
// Type: AnimatedAlpha
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[ExecuteInEditMode]
public class AnimatedAlpha : MonoBehaviour
{
  [Range(0.0f, 1f)]
  public float alpha = 1f;
  private UIWidget mWidget;
  private UIPanel mPanel;

  private void OnEnable()
  {
    this.mWidget = ((Component) this).GetComponent<UIWidget>();
    this.mPanel = ((Component) this).GetComponent<UIPanel>();
    this.LateUpdate();
  }

  private void LateUpdate()
  {
    if (Object.op_Inequality((Object) this.mWidget, (Object) null))
      this.mWidget.alpha = this.alpha;
    if (!Object.op_Inequality((Object) this.mPanel, (Object) null))
      return;
    this.mPanel.alpha = this.alpha;
  }
}
