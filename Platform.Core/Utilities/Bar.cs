using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.Utilities
{
    public class Bar
    {
        public string GenerateUKey()
        {
            string prefix = "a";
            int keyLength = 5;

            string[] collection = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,1,2,3,4,5,6,7,8,9".Split(',');

            Random random = new Random();

            string output = prefix;

            for (int i = 1; i <= keyLength; i++)
            {
                output += collection[random.Next(0, collection.Length)];
            }

            return output;
        }
    }
}
