using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel
{
    public class Path
    {
        string path;

        public string PathDim {
            get { return path; }
            set { path = value; }
        }
        
        public byte[] convertToBinary(){
            byte[] result = new byte[PathDim.Length];
            int i = 0;
            foreach (char item in PathDim.ToCharArray()) {
                result[i] = Convert.ToByte(item);
                i++;
            }
            return result;
        }
    }
}
