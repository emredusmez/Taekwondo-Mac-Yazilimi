using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaekwondoSkor.Classes
{
    public static class Kripto
    {
        public static string RsaSifrele(string strText)
        {
            var publicKey = "<RSAKeyValue><Modulus>qhirpDtQ3u84WY+vh9KrY05FccEwqbynuHgmdBT6q4tHG9iWX1yfw4GEher1KcJiRvMFUGSo3hnIwzi+VJbLrrBZ3As1gUO0SjVEnrJkETEhpFW9f94/rJGelLVvubtPZRzbI+rUOdbNUj6wgZHnWzX9E6dBmzCQ8keHvU9OGWc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                //textBox1.Text = rsa.GetHashCode.ToString();
                try
                {

                    // client encrypting data with public key issued by server                    
                    rsa.FromXmlString(publicKey.ToString());

                    var encryptedData = rsa.Encrypt(testData, false);

                    var base64Encrypted = Convert.ToBase64String(encryptedData);

                    return base64Encrypted;
                }
                finally
                {
                    //   rsa.PersistKeyInCsp = false;
                }
            }
        }

        public static string RsaSifreCoz(string strText)
        {
            var privateKey = "<RSAKeyValue><Modulus>qhirpDtQ3u84WY+vh9KrY05FccEwqbynuHgmdBT6q4tHG9iWX1yfw4GEher1KcJiRvMFUGSo3hnIwzi+VJbLrrBZ3As1gUO0SjVEnrJkETEhpFW9f94/rJGelLVvubtPZRzbI+rUOdbNUj6wgZHnWzX9E6dBmzCQ8keHvU9OGWc=</Modulus><Exponent>AQAB</Exponent><P>3gMOn4iEFxrpASOHjGWbeJ7HMtqNdismJ3q91aaHhPjadqvmd6bwDHf2jc0P1vVmiPjUX3MVCa5nz8CBput4pQ==</P><Q>xCL5HQb2bQr4ByorcMWm/hEP2MZzROV73yF41hPsRC9m66KrheO9HPTJuo3/9s5p+sqGxOlFL0NDt4SkosjgGw==</Q><DP>FklyR1uZ/wPJjj611cdBcztlPdqoxssQGnh85BzCj/u3WqBpE2vjvyyvyI5kX6zk7S0ljKtt2jny2+00VsBerQ==</DP><DQ>kYLUyDk7J2jk3APoGJE6s/EajZulNu79+GtPx5seRPPZ6mVT1VBBJDNjWhkxVfyLWblZRMs/PbIskgFBV1eqEw==</DQ><InverseQ>EaiK5KhKNp9SFXuLVwQalvzyHk0FhnNZcZnfuwnlCxb6wnKg117fEfy91eHNTt5PzYPpf+xzD1FnP7/qsIninQ==</InverseQ><D>Fijko56+qGyN8M0RVyaRAXz++xTqHBLh3tx4VgMtrQ+WEgCjhoTwo23KMBAuJGSYnRmoBZM3lMfTKevIkAidPExvYCdm5dYq3XToLkkLv5L2pIIVOFMDG+KESnAFV7l2c+cnzRMW0+b6f8mR1CJzZuxVLL6Q02fvLi55/mbSYxE=</D></RSAKeyValue>";

            var testData = Encoding.UTF8.GetBytes(strText);
            System.Security.Cryptography.CspParameters a = new CspParameters();
            a.ProviderType = 1;


            var rsa = new RSACryptoServiceProvider(1024, a);



            try
            {
                var base64Encrypted = strText;

                // server decrypting data with private key                    
                rsa.FromXmlString(privateKey);

                var resultBytes = Convert.FromBase64String(base64Encrypted);

                var decryptedBytes = rsa.Decrypt(resultBytes, false);

                var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                return decryptedData.ToString();
            }
            catch (Exception ex)
            {

                return "";
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }


        }
    }
}
