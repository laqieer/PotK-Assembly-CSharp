// Decompiled with JetBrains decompiler
// Type: UrlClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using gu3.Device;
using UnityEngine;

#nullable disable
public class UrlClick : MonoBehaviour
{
  private bool paused;

  private void OnClick()
  {
    string urlAtPosition = ((Component) this).gameObject.GetComponent<UILabel>().GetUrlAtPosition(((RaycastHit) ref UICamera.lastHit).point);
    if (urlAtPosition == null || this.paused)
      return;
    this.paused = true;
    DeviceManager.OpenUrl(urlAtPosition);
  }

  private void OnApplicationPause(bool pauseStatus) => this.paused = pauseStatus;
}
