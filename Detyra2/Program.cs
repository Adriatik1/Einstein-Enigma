using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detyra2
{
    class Program
    {
        static List<int> ngjyrat = new List<int> { 1, 2, 3, 4, 5 }; //kuqe,verdhe,blue,green,ivory
        static List<int> kombesite = new List<int> { 1, 2, 3, 4, 5 };   //anglez,spanjoll,norvegjez,ukrainas,japonez
        static List<int> cigaret = new List<int> { 1, 2, 3, 4, 5 }; //marlboro,chesterfields,winston,lucky strike,parlament
        static List<int> pijet = new List<int> { 1, 2, 3, 4, 5 };       //portokall,qaj,kafe,qumesht,uje
        static List<int> kafshet = new List<int> { 1, 2, 3, 4, 5 };     //zebrat,qeni,dhelpra,kerminjte,kali

        static Dictionary<int, List<string>> emrimet = new Dictionary<int, List<string>>() {
            {1, new List<string> { "E Kuqe", "E Verdhe", "E kaltert", "E gjelbert", "E Fildishte" } },
            {2, new List<string> { "Anglezi", "Spanjolli", "Norvegjezi", "Ukrainasi", "Japonezi" } },
            {3, new List<string> { "Marlboro", "Chesterfield", "Winston", "Lucky Strike", "Parlament" } },
            {4, new List<string> { "Portokall", "Qaj", "Kafe", "Qumesht", "Uje" } },
            {5, new List<string> { "Zebrat", "Qeni", "Dhelpra", "Kerminjte", "Kali" } } };

        static Dictionary<int, List<int>> tabela = new Dictionary<int, List<int>>()
        {                   //ngjyra,kombesia,cigaret,pija,kafshet
            {1,new List<int>{ 2,3,1,0,0 } },
            {2,new List<int>{ 3,0,0,0,5 } },
            {3,new List<int>{ 0,0,0,4,0 } },
            {4,new List<int>{ 0,0,0,0,0 } },
            {5,new List<int>{ 0,0,0,0,0 } }
        };

        static List<int[]> relacionet = new List<int[]>() {

            new int[4]{2,2,5,2}, //spanjolli zoteron qenin (kolona, vlera, kolona, vlera)
            new int[4]{1,1,2,1}, //anglezi jeton ne shtepine e kuqe
            new int[4]{3,3,5,4}, //njeriu qe pin Winston ka kerminje
            new int[4]{3,4,4,1}, //njeriu qe pin lucky strike pin lenge portokalli
            new int[4]{2,5,3,5}, //japonezi pin cigare parlament
            new int[4]{1,4,4,3}, //ne shtepine e gjelbert pihet kafja
            new int[4]{2,4,4,2}  //ukrainasi pine qaj 
        };

        static List<int[]> mundesite = new List<int[]>()
        {
            new int[3]{5,4,1},
            new int[3]{1,5,4} //ngjyra e kuqe,ivory,green                   
        };

        static int[] relacioniBig = new int[4] { 3, 2, 5, 3 };

        static void Main(string[] args)
        {
            trySolution();
            //printoSolution();
        }

        static void startSolution()
        {
            int n = 0;
            if (n == 0)
            {
                int k = 0;
                for (int i = 0; i < tabela.Count; i++)
                {
                    if (tabela.Values.ElementAt(i)[0] == 0)
                    {
                        tabela.Values.ElementAt(i)[0] = mundesite[n][k];
                        k++;
                    }
                }

                if (!provoPerDegen())
                {
                    k = 0;
                    for (int i = 0; i < tabela.Count; i++)
                    {
                        if (tabela.Values.ElementAt(i)[0] == mundesite[n][k])
                        {
                            tabela.Values.ElementAt(i)[0] = 0;
                            k++;
                        }
                    }
                }
                else
                {
                    return;
                }
                n++;
            }
            if (n == 1)
            {
                int k = 0;
                for (int i = 0; i < tabela.Count; i++)
                {
                    if (tabela.Values.ElementAt(i)[0] == 0)
                    {
                        tabela.Values.ElementAt(i)[0] = mundesite[n][k];
                        k++;
                    }
                }

                if (!provoPerDegen())
                {
                    k = 0;
                    for (int i = 0; i < tabela.Count; i++)
                    {
                        if (tabela.Values.ElementAt(i)[0] == mundesite[n][k])
                        {
                            tabela.Values.ElementAt(i)[0] = 0;
                            k++;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }
        static bool provoPerDegen(int? n = null, int? n1 = null, int? m = null, int? m1 = null)
        {
            if (endRelacionet())
            {
                printoSolution();
                return true;
            }
            if (n == null)
            {
                for (int i = 0; i < relacionet.Count; i++)
                {
                    if (!isLocated(relacionet[i][0], relacionet[i][1], relacionet[i][2], relacionet[i][3]))
                    {
                        for (int j = 0; j < tabela.Count; j++)
                        {
                            if (tabela.Values.ElementAt(j)[relacionet[i][0] - 1] == relacionet[i][1] && tabela.Values.ElementAt(j)[relacionet[i][2] - 1] == relacionet[i][3])
                                continue;
                            else if (tabela.Values.ElementAt(j)[relacionet[i][0] - 1] == 0 && tabela.Values.ElementAt(j)[relacionet[i][2] - 1] == 0)
                            {
                                tabela.Values.ElementAt(j)[relacionet[i][0] - 1] = relacionet[i][1];
                                tabela.Values.ElementAt(j)[relacionet[i][2] - 1] = relacionet[i][3];

                                if (!provoPerDegen(relacionet[i][0], relacionet[i][1], relacionet[i][2], relacionet[i][3]))
                                {
                                    //kthejme ne gjendjen e meparshme (backtracking)
                                    tabela.Values.ElementAt(j)[relacionet[i][0] - 1] = 0;
                                    tabela.Values.ElementAt(j)[relacionet[i][2] - 1] = 0;
                                    if (j == (tabela.Count - 1))
                                        return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else if (tabela.Values.ElementAt(j)[relacionet[i][0] - 1] == 0 && tabela.Values.ElementAt(j)[relacionet[i][2] - 1] == relacionet[i][3])
                            {
                                tabela.Values.ElementAt(j)[relacionet[i][0] - 1] = relacionet[i][1];

                                if (!provoPerDegen(relacionet[i][0], relacionet[i][1], relacionet[i][2], relacionet[i][3]))
                                {
                                    //kthejme ne gjendjen e meparshme (backtracking)
                                    tabela.Values.ElementAt(j)[relacionet[i][0] - 1] = 0;
                                    if (j == (tabela.Count - 1))
                                        return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else if (tabela.Values.ElementAt(j)[relacionet[i][0] - 1] == relacionet[i][1] && tabela.Values.ElementAt(j)[relacionet[i][2] - 1] == 0)
                            {

                                tabela.Values.ElementAt(j)[relacionet[i][2] - 1] = relacionet[i][3];

                                if (!provoPerDegen(relacionet[i][0], relacionet[i][1], relacionet[i][2], relacionet[i][3]))
                                {
                                    //kthejme ne gjendjen e meparshme (backtracking)
                                    tabela.Values.ElementAt(j)[relacionet[i][2] - 1] = 0;
                                    if (j == (tabela.Count - 1))
                                        return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < relacionet.Count; i++)
                {
                    if (isLocated(relacionet[i][0], relacionet[i][1], relacionet[i][2], relacionet[i][3]))
                        continue;
                    for (int j = 0; j < tabela.Count; j++)
                    {
                        if (tabela.Values.ElementAt(j)[relacionet[i][0] - 1] == relacionet[i][1] && tabela.Values.ElementAt(j)[relacionet[i][2] - 1] == relacionet[i][3])
                            continue;
                        else if (tabela.Values.ElementAt(j)[relacionet[i][0] - 1] == 0 && tabela.Values.ElementAt(j)[relacionet[i][2] - 1] == 0)
                        {
                            tabela.Values.ElementAt(j)[relacionet[i][0] - 1] = relacionet[i][1];
                            tabela.Values.ElementAt(j)[relacionet[i][2] - 1] = relacionet[i][3];

                            if (!provoPerDegen(relacionet[i][0], relacionet[i][1], relacionet[i][2], relacionet[i][3]))
                            {
                                //kthejme ne gjendjen e meparshme (backtracking)
                                tabela.Values.ElementAt(j)[relacionet[i][0] - 1] = 0;
                                tabela.Values.ElementAt(j)[relacionet[i][2] - 1] = 0;
                                if (j == (tabela.Count - 1))
                                    return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else if (tabela.Values.ElementAt(j)[relacionet[i][0] - 1] == 0 && tabela.Values.ElementAt(j)[relacionet[i][2] - 1] == relacionet[i][3])
                        {
                            tabela.Values.ElementAt(j)[relacionet[i][0] - 1] = relacionet[i][1];

                            if (!provoPerDegen(relacionet[i][0], relacionet[i][1], relacionet[i][2], relacionet[i][3]))
                            {
                                //kthejme ne gjendjen e meparshme (backtracking)
                                tabela.Values.ElementAt(j)[relacionet[i][0] - 1] = 0;
                                if (j == (tabela.Count - 1))
                                    return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else if (tabela.Values.ElementAt(j)[relacionet[i][0] - 1] == relacionet[i][1] && tabela.Values.ElementAt(j)[relacionet[i][2] - 1] == 0)
                        {
                            tabela.Values.ElementAt(j)[relacionet[i][2] - 1] = relacionet[i][3];

                            if (!provoPerDegen(relacionet[i][0], relacionet[i][1], relacionet[i][2], relacionet[i][3]))
                            {
                                //kthejme ne gjendjen e meparshme (backtracking)
                                tabela.Values.ElementAt(j)[relacionet[i][2] - 1] = 0;
                                if (j == (tabela.Count - 1))
                                    return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        static void trySolution()
        {
            for (int i = 0; i < tabela.Count; i++)
            {
                if ((i + 1) < tabela.Count && (i - 1) >= 0)
                {
                    if (tabela.Values.ElementAt(i)[relacioniBig[0] - 1] == 0)
                    {
                        if (tabela.Values.ElementAt(i + 1)[relacioniBig[2] - 1] == 0)
                        {
                            tabela.Values.ElementAt(i)[relacioniBig[0] - 1] = relacioniBig[1];
                            tabela.Values.ElementAt(i + 1)[relacioniBig[2] - 1] = relacioniBig[3];

                            startSolution();
                            //nese programi e kalon metoden startSoultion() i bie qe ska kry pune edhe backtrack
                            tabela.Values.ElementAt(i)[relacioniBig[0] - 1] = 0;
                            tabela.Values.ElementAt(i + 1)[relacioniBig[2] - 1] = 0;
                        }
                        if (tabela.Values.ElementAt(i - 1)[relacioniBig[2] - 1] == 0)
                        {
                            tabela.Values.ElementAt(i)[relacioniBig[0] - 1] = relacioniBig[1];
                            tabela.Values.ElementAt(i - 1)[relacioniBig[2] - 1] = relacioniBig[3];

                            startSolution();
                            //nese programi e kalon metoden startSoultion() i bie qe ska kry pune edhe backtrack
                            tabela.Values.ElementAt(i)[relacioniBig[0] - 1] = 0;
                            tabela.Values.ElementAt(i - 1)[relacioniBig[2] - 1] = 0;
                        }
                    }
                }
            }
        }
        static bool isLocated(int n, int n1, int m, int m1)
        {
            for (int i = 0; i < tabela.Count; i++)
            {
                if (tabela.Values.ElementAt(i)[n - 1] == n1 && tabela.Values.ElementAt(i)[m - 1] == m1)
                    return true;
            }
            return false;
        }
        static void printoSolution()
        {
            for (int i = 0; i < tabela.Count; i++)
            {
                Console.Write("Shtepia " + tabela.Keys.ElementAt(i) + " :  ");
                for (int j = 0; j < 5; j++)
                {
                    if ((tabela.Values.ElementAt(i)[j] - 1) >= 0)
                        Console.Write(emrimet.Values.ElementAt(j)[tabela.Values.ElementAt(i)[j] - 1] + ", ");
                    else if (j == 3)
                        Console.Write("Uji, ");
                    else
                        Console.Write("Zebrat ");
                }
                Console.Write("\n\n");
            }
            printoPergjigjet();
        }
        static bool endRelacionet()
        {
            int t = 0;
            for (int i = 0; i < relacionet.Count; i++)
            {
                for (int j = 0; j < tabela.Count; j++)
                {
                    if (tabela.Values.ElementAt(j)[relacionet[i][0] - 1] == relacionet[i][1] && tabela.Values.ElementAt(j)[relacionet[i][2] - 1] == relacionet[i][3])
                        t++;
                }
            }
            if (t == 7)
                return true;
            return false;
        }
        static void printoPergjigjet()
        {
            int shtepiaZ = tabela.Where(x => x.Value[4] == 0).Select(x => x.Value[0]).SingleOrDefault();
            int shtepiaU = tabela.Where(x => x.Value[3] == 0).Select(x => x.Value[0]).SingleOrDefault();
            Console.Write("Zebrat jetojne ne shtepine " + emrimet.Values.ElementAt(0)[shtepiaZ - 1].ToLower() + " dhe pine uje ne shtepine " + emrimet.Values.ElementAt(0)[shtepiaU - 1].ToLower() + ".");
            Console.ReadKey();
        }
    }
}
