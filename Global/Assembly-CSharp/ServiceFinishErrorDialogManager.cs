// Decompiled with JetBrains decompiler
// Type: ServiceFinishErrorDialogManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class ServiceFinishErrorDialogManager : MonoBehaviour
{
  public const string appClosedMessage = "Unfortunately, Phantom of the Kill closed down on June 30, 2018. Thank you very much for playing.\nTo request a refund, please tap the button on the Home screen.\n\nThe Phantom of the Kill Team";
  public const string appClosedTitle = "Thank You for Playing";
  private static DateTime appCloseTime = new DateTime(2018, 7, 1, 0, 0, 0);

  public static bool IsAppClosed
  {
    get
    {
      DateTime t2 = DateTime.UtcNow - new TimeSpan(7, 0, 0);
      return DateTime.Compare(ServiceFinishErrorDialogManager.appCloseTime, t2) <= 0;
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
  }

  public static void ShowErrorDialog()
  {
    ModalWindow.Show("Thank You for Playing", "Unfortunately, Phantom of the Kill closed down on June 30, 2018. Thank you very much for playing.\nTo request a refund, please tap the button on the Home screen.\n\nThe Phantom of the Kill Team", (System.Action) (() => Application.Quit()));
  }
}
