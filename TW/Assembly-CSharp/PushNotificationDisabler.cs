// Decompiled with JetBrains decompiler
// Type: PushNotificationDisabler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class PushNotificationDisabler : MonoBehaviour
{
  [SerializeField]
  private GameObject m_pushNotificationConfig;
  [SerializeField]
  private GameObject m_masterNameChange;
  [SerializeField]
  private GameObject m_userCommentEdit;

  private void Start()
  {
    if (!((Enum) (object) Application.platform).Equals((object) (RuntimePlatform) 2) && !((Enum) (object) Application.platform).Equals((object) (RuntimePlatform) 1))
      return;
    this.SortObjects();
    this.DisablePushNotification();
  }

  private void SortObjects()
  {
    this.m_masterNameChange.transform.position = this.m_pushNotificationConfig.transform.position;
    this.m_userCommentEdit.transform.position = this.m_masterNameChange.transform.position;
  }

  private void DisablePushNotification() => this.m_pushNotificationConfig.SetActive(false);
}
