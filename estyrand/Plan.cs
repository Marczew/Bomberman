using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estyrand
{
    class Plan
    {
        public int[][] Tablica;
        public int w;
        public int k;
        public int N;
        public int P;

        public Plan()
        {
            Tablica = null;
            w = 0;
            k = 0;
            N = 0;
            P = 0;
        }

        public void Plano()
        {
            Random r = new Random();
            int p = 0, n = 0;
            w = 13;
            k = 11;
            Tablica = new int[w][];
            for (int i = 0; i < w; i++)
            {
                Tablica[i] = new int[k];
            }
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (j % 2 == 1 && i % 2 == 1) Tablica[i][j] = 2;
                    else if (n < N && r.Next(5) % 3 == 1)
                    {
                        Tablica[i][j] = 1;
                        n++;
                    }
                    else
                        Tablica[i][j] = 0;
                }
            }
            Tablica[0][0] = 0;
            Tablica[1][0] = 0;
            Tablica[0][1] = 0;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    
                    if (i + j > 1 && r.Next(5) % 3 == 1 && Tablica[i][j] == 0 && p < P)
                    {
                        Tablica[i][j] = 3;
                        p++;
                    }
                }
            }

        }

        public void Poprawa(Blok B)
        {
            int n;
            for(int i=0;i<k;i++)
            {
                for(int j=0;j<w;j++)
                {
                    n = j * 11 + i;
                    if (B.Tablica[n] == null) Tablica[j][i] = 0;
                }
            }
        }
    }
}
