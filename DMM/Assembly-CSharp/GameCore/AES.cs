﻿// Decompiled with JetBrains decompiler
// Type: GameCore.AES
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GameCore
{
  public class AES
  {
    private const int PBKDF2_ITERATION = 5000;

    private static Rfc2898DeriveBytes GenerateKeyIV(string pwd, string salt)
    {
      UTF8Encoding utF8Encoding = new UTF8Encoding();
      return new Rfc2898DeriveBytes(pwd, utF8Encoding.GetBytes(salt), 5000);
    }

    public static string Encrypt(string pwd, string salt, string text)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(text);
      return Convert.ToBase64String(AES.Encrypt(pwd, salt, bytes));
    }

    public static byte[] Encrypt(string pwd, string salt, byte[] toEnctypt)
    {
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Padding = PaddingMode.Zeros;
      rijndaelManaged.Mode = CipherMode.CBC;
      rijndaelManaged.KeySize = 256;
      rijndaelManaged.BlockSize = 128;
      Rfc2898DeriveBytes keyIv = AES.GenerateKeyIV(pwd, salt);
      ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(keyIv.GetBytes(32), keyIv.GetBytes(16));
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write);
      cryptoStream.Write(toEnctypt, 0, toEnctypt.Length);
      cryptoStream.FlushFinalBlock();
      byte[] numArray = new byte[memoryStream.ToArray().Length];
      Array.Copy((Array) memoryStream.ToArray(), 0, (Array) numArray, 0, memoryStream.ToArray().Length);
      cryptoStream.Dispose();
      memoryStream.Dispose();
      encryptor.Dispose();
      rijndaelManaged.Clear();
      return numArray;
    }

    public static string Decrypt(string pwd, string salt, string encrypted) => Encoding.UTF8.GetString(AES.Decrypt(pwd, salt, Convert.FromBase64String(encrypted)));

    public static byte[] Decrypt(string pwd, string salt, byte[] base_byte)
    {
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Padding = PaddingMode.Zeros;
      rijndaelManaged.Mode = CipherMode.CBC;
      rijndaelManaged.KeySize = 256;
      rijndaelManaged.BlockSize = 128;
      Rfc2898DeriveBytes keyIv = AES.GenerateKeyIV(pwd, salt);
      ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(keyIv.GetBytes(32), keyIv.GetBytes(16));
      byte[] buffer1 = new byte[base_byte.Length];
      Array.Copy((Array) base_byte, 0, (Array) buffer1, 0, buffer1.Length);
      byte[] buffer2 = new byte[buffer1.Length];
      MemoryStream memoryStream = new MemoryStream(buffer1);
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read);
      cryptoStream.Read(buffer2, 0, buffer2.Length);
      cryptoStream.Dispose();
      memoryStream.Dispose();
      decryptor.Dispose();
      rijndaelManaged.Clear();
      return buffer2;
    }
  }
}
