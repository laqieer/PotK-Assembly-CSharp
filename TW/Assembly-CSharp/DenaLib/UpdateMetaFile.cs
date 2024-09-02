// Decompiled with JetBrains decompiler
// Type: DenaLib.UpdateMetaFile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace DenaLib
{
  public class UpdateMetaFile
  {
    public int Version = 1;
    public List<UpdatePackageInfo> PackageList = new List<UpdatePackageInfo>();
    public long TotalSize;
    public static string MetaFileName = "/UpdateMeta.data";
    public static string LocMetaFileName = "/LocUpdateMeta.data";

    public void Load(string filename)
    {
      this.Version = 0;
      this.PackageList.Clear();
      this.TotalSize = 0L;
      try
      {
        if (!File.Exists(filename))
          return;
        using (BinaryReader binaryReader = new BinaryReader((Stream) File.Open(filename, FileMode.Open)))
        {
          this.Version = binaryReader.ReadInt32();
          int num = binaryReader.ReadInt32();
          for (int index = 0; index < num; ++index)
          {
            UpdatePackageInfo updatePackageInfo = new UpdatePackageInfo();
            updatePackageInfo.name = binaryReader.ReadString();
            updatePackageInfo.md5 = binaryReader.ReadString();
            updatePackageInfo.size = binaryReader.ReadInt64();
            this.PackageList.Add(updatePackageInfo);
            this.TotalSize += updatePackageInfo.size;
          }
        }
      }
      catch (Exception ex)
      {
        Singleton<Utlity>.Instance.LogMsg(EMessageCode.ELoadUpdateMetaFileFail, ex.Message);
      }
    }

    public void Save(string filename)
    {
      if (File.Exists(filename))
        File.Delete(filename);
      try
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Open(filename, FileMode.Create)))
        {
          binaryWriter.Write(this.Version);
          int count = this.PackageList.Count;
          binaryWriter.Write(count);
          for (int index = 0; index < count; ++index)
          {
            UpdatePackageInfo package = this.PackageList[index];
            binaryWriter.Write(package.name);
            binaryWriter.Write(package.md5);
            binaryWriter.Write(package.size);
          }
        }
      }
      catch (Exception ex)
      {
        Singleton<Utlity>.Instance.LogMsg(EMessageCode.ESaveUpdateMetaFileFail, ex.Message);
      }
    }

    public bool FindPackage(UpdatePackageInfo upi)
    {
      for (int index = 0; index < this.PackageList.Count; ++index)
      {
        UpdatePackageInfo package = this.PackageList[index];
        if (package.name == upi.name && package.md5 == upi.md5 && package.size == upi.size)
          return true;
      }
      return false;
    }

    public void UpdatePackage(UpdatePackageInfo upi)
    {
      for (int index = 0; index < this.PackageList.Count; ++index)
      {
        UpdatePackageInfo package = this.PackageList[index];
        if (package.name == upi.name)
        {
          package.md5 = upi.md5;
          package.size = upi.size;
          return;
        }
      }
      this.PackageList.Add(new UpdatePackageInfo()
      {
        name = upi.name,
        md5 = upi.md5,
        size = upi.size
      });
    }
  }
}
