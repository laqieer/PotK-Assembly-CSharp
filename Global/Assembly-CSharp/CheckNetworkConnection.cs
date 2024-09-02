// Decompiled with JetBrains decompiler
// Type: CheckNetworkConnection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CheckNetworkConnection : MonoBehaviour
{
  private static CheckNetworkConnection instance;
  private UILabel title;
  public string errorMessage_;
  private UIButton uiButton;
  public DownloadManager.WWWRequest DMRequest;
  [HideInInspector]
  public GameObject messageLabel;
  public bool enablePopUp;

  public static CheckNetworkConnection Instance => CheckNetworkConnection.instance;

  private void Awake()
  {
    if (Object.op_Implicit((Object) CheckNetworkConnection.instance))
      Object.Destroy((Object) this);
    else
      CheckNetworkConnection.instance = this;
    ((Component) this).transform.parent = ((Component) LocalizationPreset.Instance).transform;
  }

  public bool ShowPopUp(
    string title,
    string message,
    MonoBehaviour mb,
    System.Action methodName,
    DownloadManager.WWWRequest request = null)
  {
    if (this.enablePopUp)
      return false;
    ModalWindow.Show(title, message, methodName);
    this.errorMessage_ = message;
    this.DMRequest = request;
    return this.enablePopUp = true;
  }
}
