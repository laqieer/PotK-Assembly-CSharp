// Decompiled with JetBrains decompiler
// Type: StoryBG
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
