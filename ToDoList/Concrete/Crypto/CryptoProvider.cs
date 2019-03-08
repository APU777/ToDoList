namespace ToDoList.Concrete.Crypto
{
    public class CryptoProvider
    {
        public static string GetMD5Hash(string SomeData)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider mD5Crypto = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] HashCode = mD5Crypto.ComputeHash(System.Text.Encoding.Default.GetBytes(SomeData));
            return System.BitConverter.ToString(HashCode).ToLower().Replace("-", "");
        }
    }
}