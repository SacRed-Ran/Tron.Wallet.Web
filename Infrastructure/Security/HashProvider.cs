using System.Text;
using System.Security.Cryptography;

namespace Tron.Wallet.Web {
    /// <summary>
    /// ������HashProvider
    /// ���ã��Դ�����ַ�������Hash���㣬����ͨ��Hash�㷨���ܹ����ִ���
    /// ���ԣ����ޣ�
    /// ���캯���������
    /// IsReturnNum:�Ƿ񷵻�Ϊ���ܺ��ַ���Byte����
    /// �����������ṩMD5��SHA1��SHA256��SHA512�������㷨�������ִ��ĳ�����������
    /// </summary>
    public static class HashProvider {
        #region //-----MD5-----//
        public static string MD5Encrypt16(string md5) {
            if (string.IsNullOrEmpty(md5)) return md5;

            return md5.Length == 32 ? md5.Substring(9, 25) : md5;
        }

        public static string MD5Encrypt(string str, bool isReturnNum) {
            var b = GetKeyByteArray(str);
            var md5 = new MD5CryptoServiceProvider();
            b = md5.ComputeHash(b);
            md5.Clear();
            return GetStringValue(b, isReturnNum);
        }

        public static string MD5Encrypt(string str) {
            return MD5Encrypt(str, true);
        }
        #endregion

        #region //-----SHA1-----//
        public static string SHA1Encrypt(string str, bool isReturnNum) {
            var b = GetKeyByteArray(str);
            var sha1 = new SHA1CryptoServiceProvider();
            b = sha1.ComputeHash(b);
            sha1.Clear();
            return GetStringValue(b, isReturnNum);

        }

        public static string SHA1Encrypt(string str) {
            return SHA1Encrypt(str, true);
        }
        #endregion

        #region //-----SHA256-----//
        public static string SHA256Encrypt(string str, bool isReturnNum) {
            var b = GetKeyByteArray(str);
            var sha256 = new SHA256Managed();
            b = sha256.ComputeHash(b);
            sha256.Clear();
            return GetStringValue(b, isReturnNum);

        }

        public static string SHA256Encrypt(string str) {
            return SHA256Encrypt(str, true);
        }
        #endregion

        #region //-----SHA512-----//
        public static string SHA512Encrypt(string str, bool isReturnNum) {
            var b = GetKeyByteArray(str);
            var sha512 = new SHA512Managed();
            b = sha512.ComputeHash(b);
            sha512.Clear();
            return GetStringValue(b, isReturnNum);
        }

        public static string SHA512Encrypt(string str) {
            return SHA512Encrypt(str, true);
        }
        #endregion

        #region //-----Private Methods-----//
        private static string GetStringValue(byte[] b, bool isReturnNum) {
            var ren = string.Empty;
            if (!isReturnNum) {
                ren = Encoding.ASCII.GetString(b);
            } else {
                for (var i = 0; i < b.Length; i++) {
                    ren += b[i].ToString("x").PadLeft(2, '0');
                }
            }
            return ren;
        }

        private static byte[] GetKeyByteArray(string strKey) {
            return Encoding.UTF8.GetBytes(strKey);
        }
        #endregion
    }
}
