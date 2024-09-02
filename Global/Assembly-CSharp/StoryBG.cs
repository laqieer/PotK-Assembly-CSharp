// Decompiled with JetBrains decompiler
// Type: StoryBG
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class StoryBG : MonoBehaviour
{
  public string namePrefab;
  private UIWidget widget;

  private void Start()
  {
    this.widget = ((Component) this).gameObject.GetComponent<UIWidget>();
    this.setWidget();
  }

  private void setWidget() => this.widget.depth = 0;
}
