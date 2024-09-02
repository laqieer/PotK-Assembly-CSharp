// Decompiled with JetBrains decompiler
// Type: Startup00010ScoreDraw
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Startup00010ScoreDraw : MonoBehaviour
{
  public List<Startup00010Score> score_sprite_list;
  public bool zero_draw = true;

  public void Draw(int score)
  {
    foreach (Startup00010Score scoreSprite in this.score_sprite_list)
    {
      if (score == 0)
      {
        if (!this.zero_draw)
          ((Component) scoreSprite).gameObject.SetActive(false);
      }
      else
        ((Component) scoreSprite).gameObject.SetActive(true);
      scoreSprite.SetActive(score % 10);
      score /= 10;
    }
  }
}
