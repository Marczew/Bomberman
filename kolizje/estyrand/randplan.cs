using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estyrand
{
    class Randplan
    {

        public int[][] Tablica;
        public int w;
        int k;
        /// konstruktor
        Randplan(int N,int P)
        {
            int a = 13;
            int b = 11;
            int p=0, n=0;
            this->w = a;
            this->k = b;
            this->Tablica=new int*[w];
            if (t == null) throw;
            for(int i=0;i<w;i++)
            {
                Tablica[i] = new int[k];
            }
            for(int i=0;i<w;i++)
            {
                for(int j=0;j<k;j++)
                {
                    Random r;
                    if (j % 2 == 1 && i % 2 == 1) Tablica[i][j] = 2;
                    else if (n < N && r% 2 == 1)
                    {
                        Tablica[i][j] = 1;
                        n++;
                    }
                    else
                        t[i][j] = 0;
                }
            }
            Tablica[0][0] = 0;
            Tablica[1][0] = 0;
            Tablica[0][1] = 0;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Random r;
                    if (i + j > 1 && r % 2 == 1 && t[i][j] == 0 && p < P)
                    {
                        Tablica[i][j] = 3;
                        p++;
                    }
                }
            }
            return 0;
        }
    }
}
