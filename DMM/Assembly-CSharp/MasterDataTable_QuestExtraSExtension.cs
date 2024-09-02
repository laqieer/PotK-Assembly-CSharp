// Decompiled with JetBrains decompiler
// Type: MasterDataTable_QuestExtraSExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using System.Linq;

public static class MasterDataTable_QuestExtraSExtension
{
  public static QuestExtraS[] LL(this QuestExtraS[] self, int ll)
  {
    QuestExtraLL questLl;
    return ((IEnumerable<QuestExtraS>) self).Where<QuestExtraS>((Func<QuestExtraS, bool>) (x => (questLl = x.quest_ll) != null && questLl.ID == ll)).ToArray<QuestExtraS>();
  }

  public static bool EqualL(this QuestExtraS self, int Lid) => self.seek_type == QuestExtra.SeekType.L && self.quest_l_QuestExtraL == Lid;
}
