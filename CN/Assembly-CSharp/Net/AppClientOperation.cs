// Decompiled with JetBrains decompiler
// Type: Net.AppClientOperation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
namespace Net
{
  public enum AppClientOperation
  {
    StatRequest,
    JoinRoom,
    ReadyCompleted,
    LocateUnitsCompleted,
    TurnInitializeCompleted,
    MoveUnitTimeout,
    MoveUnit,
    MoveUnitWithAttack,
    MoveUnitWithSkill,
    ActionUnitCompleted,
    RecoveryRequest,
  }
}
