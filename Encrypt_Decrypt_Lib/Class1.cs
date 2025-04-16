/*
 * DLL library for Encrytion/Decryption using ASCII Encoding / bytes.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Encrypt_Decrypt_Lib
{
    public class Encrypt_Decrypt
    {

        /*
         * Uses byte[] array to store an encrypted string. We use ASCII Encoding
         * to get the bytes of our string (used to encrypt our pw).
         */
        public static string Encrypt(string encryptString)
        {
            byte[] encryptedBytes = Encoding.ASCII.GetBytes(encryptString);
            string encryptionResult = "";

            // for each byte in our encryptedBytes array, append it to the end of our
            // encryptionResult string (string of 1's and 0's).
            foreach (byte digit in encryptedBytes)
            {
                encryptionResult += digit;
            }

            return encryptionResult;
        }


        /*
         * Unsuccessful implementation - Not Needed
         */
        public static string Decrypt(string decryptString)
        {
            string decryptedString = " ";


            List<byte> byteList = new List<byte>();

            int[] intArray = new int[decryptedString.Length];

            for (int i = 0; i < decryptedString.Length; i++)
            {
                intArray[i] = decryptedString[i];
            }


            // for each int in our intArray above add
            // the byte value of that number into our byteList
            foreach (int num in intArray)
            {
                byteList.Add((byte)num);
            }

            // decrypt our byteList into a string.
            decryptedString = Encoding.Default.GetString(byteList.ToArray<byte>());

            return decryptedString;
        }
    }
}
