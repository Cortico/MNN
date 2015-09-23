using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MNN
{
    class tabelaPitagorica
    {
        private bool isVogal(char letra)
        {
            if ("AEIOU".Contains(letra))
                return true;
            else return false;
        }
        private char removeAcento(char letra)
        {
            switch (letra)
            {
                case 'Á': return 'A';
                case 'Ã': return 'A';
                case 'À': return 'A';
                case 'Â': return 'A';
                case 'É': return 'E';
                case 'È': return 'E';
                case 'Ê': return 'E';
                case 'Í': return 'I';
                case 'Ì': return 'I';
                case 'Î': return 'I';
                case 'Ó': return 'O';
                case 'Ò': return 'O';
                case 'Õ': return 'O';
                case 'Ô': return 'O';
                case 'Ú': return 'U';
                case 'Ù': return 'U';
                case 'Û': return 'U';
                case 'Ñ': return 'N';
                default: return letra;
            }
        }
        public void AddLetters(Dictionary<char, int> tabela, char a, char b, char c, int key)
        {
            tabela.Add(a, key);
            tabela.Add(b, key);
            tabela.Add(c, key);
        }
        public int ConvertePraNumero(char a)
        {
            Dictionary<char, int> tabela = new Dictionary<char, int>();
            AddLetters(tabela, 'A', 'J', 'S', 1);
            AddLetters(tabela, 'B', 'K', 'T', 2);
            AddLetters(tabela, 'C', 'L', 'U', 3);
            AddLetters(tabela, 'D', 'M', 'V', 4);
            AddLetters(tabela, 'E', 'N', 'W', 5);
            AddLetters(tabela, 'F', 'O', 'X', 6);
            AddLetters(tabela, 'G', 'P', 'Y', 7);
            AddLetters(tabela, 'H', 'Q', 'Z', 8);
            tabela.Add('I', 9);
            tabela.Add('R', 9);
            int retorno;
            tabela.TryGetValue(a, out retorno);
            return retorno;
        }
        private List<char> quebraEmChar(string s)
        {
            List<char> n = new List<char>();
            n = s.ToCharArray().ToList();
            n.ForEach(i => removeAcento(i));
            return n;
        }

        public int calculaEU (List<List<int>> consoantes)
        {
            int aux = 0, aux2 = 0;
            foreach (List<int> i in consoantes)
            {
                aux = 0;
                foreach (int v in i)
                {
                    aux = aux + v;
                }
                    aux2 = (1 + (aux - 1) % 9) + aux2;
            }
            if (aux2 >= 10 && aux2 != 11 && aux2 != 22)
            {
                aux2 = 1 + (aux2 - 1) % 9;
            }
            return aux2;
        }

        public int calculaMO(List<List<int>> vogais)
        {
            int aux = 0, aux2 = 0;
            foreach (List<int> i in vogais)
            {
                aux = 0;
                foreach (int v in i)
                {
                    aux = aux + v;
                }
                aux2 = (1 + (aux - 1) % 9) + aux2;
            }
            if (aux2 >= 10 && aux2 != 11 && aux2 != 22)
            {
                aux2 = 1 + (aux2 - 1) % 9;
            }
            return aux2;
        }

        private int calculaEX(int MO, int EU)
        {
            int EX = MO + EU;
            if(EX >= 10 && EX != 11 && EX != 22)
            {
                EX = 1 + (EX - 1) % 9;
            }
            return EX;
        }

        private caminho usaNasc(DateTime dataNasc)
        {
            int auxDia = 0, auxMes = 0, auxAno = 0;
            caminho C = new caminho();

            C.C2 = dataNasc.Day; // neste ponto, C.C2 pode não representar o valor de C2
            if (C.C2 >= 10 && C.C2 != 11 && C.C2 != 22)
            {
                C.C2 = 1 + (C.C2 - 1) % 9; // Neste ponto, C.C2 definitivamente representa C2.
            }
            C.C1 = dataNasc.Month;
            if (C.C1 >= 10 && C.C1 != 11 && C.C1 != 22)
            {
                C.C1 = 1 + (C.C1 - 1) % 9;
            }
            C.C3 = dataNasc.Year;
            if (C.C3 >= 10 && C.C3 != 11 && C.C3 != 22)
            {
                C.C3 = 1 + (C.C3 - 1) % 9;
            }
            // As linha de código seguintes reduzem todos os C.C* para apenas um digito e os soma para encontrar CD
            auxDia = (1 + (C.C2 - 1) % 9);
            auxMes = (1 + (C.C1 - 1) % 9);
            auxAno = (1 + (C.C3 - 1) % 9);
            C.CD = auxDia + auxAno + auxMes;
            if (C.CD >= 10 && C.CD != 11 && C.CD != 22)
            {
                C.CD = 1 + (C.CD - 1) % 9;
            }

            // Cálculo dos Desafios
            C.D1 = auxDia - auxMes;
            C.D1 = Math.Abs(C.D1);
            C.D2 = auxMes - auxAno;
            C.D2 = Math.Abs(C.D2);
            C.DM = C.D1 - C.D2;
            C.DM = Math.Abs(C.DM);

            // Cáluclo das Realizações
            C.R1 = auxDia + auxMes;
            C.R1 = 1 + (C.R1 - 1) % 9; // por precaução, os numeros são reduzidos a apenas um mesmo quando são apenas um.
            C.R2 = auxDia + auxAno;
            C.R2 = 1 + (C.R2 - 1) % 9;
            C.R3 = C.R1 + C.R2;
            C.R3 = 1 + (C.R3 - 1) % 9;
            C.R4 = auxAno + auxMes;
            C.R4 = 1 + (C.R4 - 1) % 9;

            return C;
        }

        private int calculaRs()
        {
            return 1;
        }

        public leitura efetuaLeitura(string nome, DateTime dataNasc)
        {
            leitura l = new leitura();
            caminho c = new caminho();
            nome = nome.ToUpper();


            // quebra o nome onde tem espaço e converte pra lista
            List<string> nomes = nome.Split(' ').ToList();
            List<List<char>> nomes2 = new List<List<char>>();
            List<List<int>> vogais = new List<List<int>>();
            List<List<int>> consoantes = new List<List<int>>();
            nomes.ForEach(i => nomes2.Add(quebraEmChar(i)));

            foreach (List<char> lista in nomes2)
            {
                List<int> vogaisIn = new List<int>();
                List<int> consoantesIn = new List<int>();
                foreach (char x in lista){
                    if (isVogal(x))
                    {
                        vogaisIn.Add(ConvertePraNumero(x));
                    }
                    else
                    {
                        consoantesIn.Add(ConvertePraNumero(x));
                    }
                }
                if (vogaisIn.Any())
                {
                    vogais.Add(vogaisIn);
                }
                if (consoantesIn.Any())
                {
                    consoantes.Add(consoantesIn);
                }
            }

            l.MO = calculaMO(vogais);
            l.EU = calculaEU(consoantes);
            l.EX = calculaEX(l.MO, l.EU);
            c = usaNasc(dataNasc);
            l.CD = c.CD;
            l.C1 = c.C1;
            l.C2 = c.C2;
            l.C3 = c.C3;
            l.D1 = c.D1;
            l.D2 = c.D2;
            l.DM = c.DM;
            l.R1 = c.R1;
            l.R2 = c.R2;
            l.R3 = c.R3;
            l.R4 = c.R4;

            return l;
        }

    }
}
