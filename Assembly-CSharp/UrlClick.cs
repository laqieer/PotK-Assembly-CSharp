// Decompiled with JetBrains decompiler
// Type: UrlClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using DeviceKit;
using UnityEngine;

public class UrlClick : MonoBehaviour
{
  [SerializeField]
  private UILabel label;

  private void OnClick()
  {
    string urlAtPosition = this.label.GetUrlAtPosition(UICamera.lastHit.point);
    if (urlAtPosition == null)
      return;
    Debug.Log((object) ("open url " + urlAtPosition));
    App.OpenUrl(urlAtPosition);
  }
}
