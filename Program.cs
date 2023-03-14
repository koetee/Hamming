using System;

namespace Hamming
{
    class Program
    {
        static void Main()
        {
           
            Console.Write("Enter the data to be encoded: ");
            string data = Console.ReadLine();

            // Calculate the number of parity bits needed
            int numParityBits = 0;
            while (Math.Pow(2, numParityBits) < data.Length + numParityBits + 1) {
                numParityBits++;
            }

            
            int[] encodedData = new int[data.Length + numParityBits];

            // Insert the data bits into the encoded data array
            int dataIndex = 0;
            for (int i = 0; i < encodedData.Length; i++) {
                if (IsPowerOfTwo(i + 1)) {
                  
                    encodedData[i] = 0;
                }
                else {
                  
                    encodedData[i] = int.Parse(data[dataIndex].ToString());
                    dataIndex++;
                }
            }

            // Calculate the parity bits
            for (int i = 0; i < numParityBits; i++) {
                int parityBitIndex = (int)Math.Pow(2, i) - 1;
                int parity = 0;
                for (int j = parityBitIndex; j < encodedData.Length; j += (parityBitIndex + 1) * 2) {
                    for (int k = 0; k < parityBitIndex + 1 && j + k < encodedData.Length; k++) {
                        parity ^= encodedData[j + k];
                    }
                }
                encodedData[parityBitIndex] = parity;
            }

            // Print out the encoded data
            Console.Write("Encoded data: ");
            for (int i = 0; i < encodedData.Length; i++) {
                Console.Write(encodedData[i]);
            }
            Console.WriteLine();
        }

        static bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }
    }
}

