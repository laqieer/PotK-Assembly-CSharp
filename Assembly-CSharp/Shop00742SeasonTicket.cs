// Decompiled with JetBrains decompiler
// Type: Shop00742SeasonTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

public class Shop00742SeasonTicket : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtFlavor;
  [SerializeField]
  protected UILabel TxtName;
  [SerializeField]
  protected UI2DSprite SlcTarget;
  private float scale = 0.7f;

  public IEnumerator Init(int entity_id)
  {
    SeasonTicketSeasonTicket ticketSeasonTicket = MasterData.SeasonTicketSeasonTicket[entity_id];
    this.TxtFlavor.SetText(ticketSeasonTicket.description);
    this.TxtName.SetText(ticketSeasonTicket.name);
    Future<UnityEngine.Sprite> spriteF = ticketSeasonTicket.LoadLargeF();
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.SlcTarget.sprite2D = spriteF.Result;
    this.SlcTarget.width = Mathf.FloorToInt(spriteF.Result.textureRect.width);
    this.SlcTarget.height = Mathf.FloorToInt(spriteF.Result.textureRect.height);
    this.SlcTarget.transform.localScale = new Vector3(this.scale, this.scale);
    spriteF = (Future<UnityEngine.Sprite>) null;
  }
}
