// Decompiled with JetBrains decompiler
// Type: StoryBG
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
