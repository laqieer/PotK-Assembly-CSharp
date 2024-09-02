// Decompiled with JetBrains decompiler
// Type: MovieInputController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
[RequireComponent(typeof (RawImage), typeof (CriManaMovieControllerForUI))]
public class MovieInputController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
  [SerializeField]
  private WindowsMovieController movieController;

  public void OnPointerClick(PointerEventData ped) => this.movieController.StopMovie();
}
