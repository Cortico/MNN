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
        public leitura efetuaLeitura(string nome, DateTime dataNasc)
        {
            leitura l = new leitura();
            nome = nome.ToUpper();
            int auxMO = 0, auxMO2 = 0;


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

            foreach (List<int> i in consoantes)
            {
                foreach (int v in i)
                {
                    auxMO = auxMO + v;
                }
                auxMO2 = 1 + (auxMO - 1) % 9;
                //do
                //{
                //    if (auxMO % 10 < 1)
                //    {
                //        auxMO2 = auxMO2 + auxMO;
                //    }
                //    else
                //    {
                //        auxMO2 = (((auxMO - auxMO % 10) / 10) + auxMO % 10) + auxMO2;
                //    }
                //} while (auxMO2 % 10 >= 1 || auxMO2 != 11 || auxMO2 != 22);
            }
            return l;
        }

    }
}
