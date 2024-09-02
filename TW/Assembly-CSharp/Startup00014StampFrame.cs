// Decompiled with JetBrains decompiler
// Type: Startup00014StampFrame
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Startup00014StampFrame : MonoBehaviour
{
  [SerializeField]
  private List<float> position_x = new List<float>();
  [SerializeField]
  private UITexture frame;
  [SerializeField]
  private UITexture arrow;

  public void ArrowPosition(int num)
  {
    ((Component) this.arrow).transform.localPosition = new Vector3(this.position_x[num], 0.0f, 0.0f);
  }

  public void ChangeFrame(Texture texture)
  {
    this.frame.mainTexture = texture;
    this.frame.SetDimensions(this.frame.mainTexture.width, this.frame.mainTexture.height);
  }

  public void ArrowEnable(bool flag) => ((Behaviour) this.arrow).enabled = flag;
}
