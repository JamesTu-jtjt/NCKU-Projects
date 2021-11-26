using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_1_Substitution_Cipher
{
    class SubstitutionCipher
    {
        public string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public string key = "";

        public void Generate()
        {
            this.key = "";
            char[] plaintxtAry = this.alphabet.ToCharArray();
            char[] newKeyArray = plaintxtAry.OrderBy(x => Guid.NewGuid()).ToArray();
            foreach(char c in newKeyArray)
            {
                this.key += c;
            }
        }

        public bool IsValid(string key)
        {
            if (key.Length != 52)
            {
                return false;
            }
            else
            {
                foreach(char c in this.alphabet)
                {
                    if (!key.Contains(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private string Encrypt(string plaintxt)
        {
            char[] keyArray = this.key.ToCharArray();
            string ciphertxt = "";

            foreach(char c in plaintxt)
            {
                if (this.alphabet.Contains(c))
                {
                    ciphertxt += keyArray[this.alphabet.IndexOf(c)];
                }
                else
                {
                    ciphertxt += c;
                }
            }

            return ciphertxt;
        }

        private string Decrypt(string ciphertxt)
        {
            char[] cipherArray = ciphertxt.ToCharArray();
            char[] alphabetArray = this.alphabet.ToCharArray();
            string plaintxt = "";

            foreach (char c in ciphertxt)
            {
                if (this.key.Contains(c))
                {
                    plaintxt += alphabetArray[this.key.IndexOf(c)];
                }
                else
                {
                    plaintxt += c;
                }
            }

            return plaintxt;
        }

        public string GetEncryption(string plaintxt)
        {
            return Encrypt(plaintxt);
        }

        public string GetDecryption(string ciphertxt)
        {
            return Decrypt(ciphertxt);
        }
    }
}
