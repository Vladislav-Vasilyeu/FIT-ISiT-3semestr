using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;

namespace Lab5Lib
{
    public interface IWriter
    {
        string? Save(string? message);
    }



    public class FileWriter : IWriter
    {
        string filename = Constant.FileName;
        public string FileName { get { return this.filename; } }
        public FileWriter(string? filename = null)
        {
            this.filename = filename ?? Constant.FileName;
        }
        public string? Save(string? message)
        {
            if (message == null) return null;
            File.WriteAllText(filename, message);
            return this.filename;
        }
    }



    public class StrWriter : IWriter
    {
        public string? Save(string? message)
        {
            return message;
        }
    }



    public class Decorator : IWriter
    {
        protected IWriter? writer;
        public Decorator(IWriter writer)
        {
            this.writer = writer;
        }
        public virtual string? Save(string? message) 
        {
            return writer?.Save(message);
        }
    }



    public class DecSHA512 : Decorator
    {
        public DecSHA512(IWriter writer) : base(writer) { }
        public override string Save(string message) 
        {
            
            if (message == null) return null;
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hash = sha512.ComputeHash(messageBytes);
                string hashString = Convert.ToBase64String(hash);
                string result = string.Join(Constant.Delimiter.ToString(), message, hashString);
                return writer?.Save(result);
            }
        }
    }



    public class DecMD5 : Decorator
    {
        public DecMD5(IWriter writer) : base(writer) { }
        public override string? Save(string? message)
        {
            if (message == null) return null;
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(messageBytes);
                string hashString = Convert.ToBase64String(hash);
                string result = string.Join(Constant.Delimiter.ToString(), message, hashString);
                return writer?.Save(result);
            }


            
        }
    }



    public class DecRSA : Decorator
    {
        public DecRSA(IWriter writer) : base(writer) { }
        public override string? Save(string? message)
        {
            if (message==null) return null;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string publicKey = rsa.ToXmlString(false);
                byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                byte[] encryptedHash = rsa.Encrypt(messageBytes, RSAEncryptionPadding.Pkcs1);
                string encryptedHashString = Convert.ToBase64String(encryptedHash);
                string result = string.Join(Constant.Delimiter.ToString(), message, encryptedHashString, publicKey);
                return writer?.Save(result);
            }
        }
    }



    public static class Constant
    {
        public const char Delimiter = '\uffff';
        public const string FileName = "DP.txt";
    }
}
