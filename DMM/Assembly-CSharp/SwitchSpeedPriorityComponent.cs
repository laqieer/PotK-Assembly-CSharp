// Decompiled with JetBrains decompiler
// Type: SwitchSpeedPriorityComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public class SwitchSpeedPriorityComponent : MonoBehaviour
{
  public SwitchSpeedPriorityComponent.SwitchMode swtichMode;
  private bool isSpeedPriority;

  private void Awake()
  {
    this.isSpeedPriority = PerformanceConfig.GetInstance().IsSpeedPriority;
    switch (this.swtichMode)
    {
      case SwitchSpeedPriorityComponent.SwitchMode.SETENABLE:
        this.gameObject.SetActive(!this.isSpeedPriority);
        break;
      case SwitchSpeedPriorityComponent.SwitchMode.SETDESTROY:
        if (!this.isSpeedPriority)
          break;
        Object.Destroy((Object) this.gameObject);
        break;
    }
  }

  public enum SwitchMode
  {
    SETENABLE,
    SETDESTROY,
  }
}
