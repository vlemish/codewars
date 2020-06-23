using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsSolutions
{
    public abstract class Task
    {

        #region https://www.codewars.com/kata/523f5d21c841566fde000009/
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            var aList = a.ToList();
            foreach (var el in b)
            {
                if (aList.Contains(el))
                {
                    aList.RemoveAll(i => { return i == el; });
                }
            }
            foreach (var i in aList)
            {
                Console.WriteLine(i);

            }
            return aList.ToArray();
        }
        #endregion

        #region https://www.codewars.com/kata/530e15517bc88ac656000716/

        public static string Rot13(string message)
        {
            string result = "";
            foreach (var ch in message)
            {
                result += GetRotetedCharacter(ch);
            }

            return result;
        }

        public static char GetRotetedCharacter(char character)
        {
            char[] alhabet =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n',
                'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z'
            };

            alhabet = Char.IsUpper(character)
                ? alhabet.Select(c => char.ToUpper(c)).ToArray()
                : alhabet;

            for (int i = 0; i < alhabet.Length; i++)
            {
                //try
                //{
                if (alhabet[i] == character)
                {
                    int temp = i + 13;
                    int index = 0;
                    if (temp >= alhabet.Length)
                    {
                        index = temp - 26;

                        return alhabet[index];
                    }
                    return alhabet[temp];
                }
                //}
                //catch (IndexOutOfRangeException)
                //{
                //    return Char.IsUpper(character) ? 'A' : 'a';
                //}
            }
            return character;
        }
        #endregion

        #region https://www.codewars.com/kata/5842df8ccbd22792a4000245/

        public static string ExpandForm(long num)
        {
            string numStr = num.ToString();
            List<string> list = new List<string>();
            for (int i = 0; i < numStr.Length; i++)
            {
                if (numStr[i] != '0')
                {
                    if ((numStr.Length - i) < 2)
                    {
                        list.Add($"{numStr[i]}");
                        return string.Join(" + ", list);
                    }

                    string toAdd = $"{numStr[i]}" + new string('0', numStr.Length - i - 1);
                    list.Add(toAdd);
                }
            }
            return string.Join(" + ", list);
        }

        #endregion

        #region https://www.codewars.com/kata/546e2562b03326a88e000020/

        public static int SquareDigits(int n)
        {
            string nStr = n.ToString();
            string toReturn = "";

            foreach (var number in nStr)
            {
                double temp = double.Parse(number.ToString());
                toReturn += $"{Math.Pow(temp, 2)}";
            }

            return int.Parse(toReturn);

            //via linq

            return int.Parse(string.Join("", n.ToString().Select(i => Math.Pow(double.Parse(i.ToString()), 2))));
        }
        #endregion

        #region https://www.codewars.com/kata/5583d268479559400d000064/

        public static string BinaryToString(string binary)
        {
            var bites = new List<string>();
            string temp = binary;
            for (int i = 0; i < binary.Length / 8; i++)
            {
                bites.Add(temp.Substring(0, 8));
                temp = temp.Remove(0, 8);
            }
            return string.Join("", bites.Select(x => (char)BinaryToDecimal(x)));
        }

        static int BinaryToDecimal(string binary)
        {
            int i = 0;
            var toDecimal = binary.Select(
                x => x == '1' ? Math.Pow(2, (binary.Length - 1) - i++)
                : Math.Pow(0, i++)).Sum() - 1;

            return (int)toDecimal;
        }
        #endregion

        #region https://www.codewars.com/kata/54da5a58ea159efa38000836/

        public static int find_it(int[] seq)
        {
            return int.Parse(string.Join("", seq.GroupBy(g => g).Where(g => g.Count() % 2 != 0).Select(g => g.Key)));
        }

        #endregion

        #region https://www.codewars.com/kata/5208f99aee097e6552000148/

        public static string BreakCamelCase(string str)
        {
            var res = str.ToCharArray().Select(x => char.IsUpper(x) ? " " + x : "" + x).ToList();
            return string.Join("", res);
        }

        #endregion

        #region https://www.codewars.com/kata/576bb3c4b1abc497ec000065/

        public static bool Compare(string s1, string s2)
        {
            try
            {
                var str1 = s1.Where(i => !Char.IsLetter(i)).ToArray();
                var str2 = s2.Where(i => !Char.IsLetter(i)).ToArray();
                var sum1 = str1.Length >= 1 ? 0 : s1.ToUpper().Select(i => i.GetHashCode()).Sum();
                var sum2 = str2.Length >= 1 ? 0 : s2.ToUpper().Select(i => i.GetHashCode()).Sum();
                return sum1 == sum2;
            }
            catch (Exception) { return true; }
        }

        #endregion

        #region https://www.codewars.com/kata/5853213063adbd1b9b0000be/

        public string[] StreetFighterSelection(string[][] fighters, int[] position, string[] moves)
        {
            List<string> selectedFighters = new List<string>();
            foreach (var move in moves)
            {
                switch (move)
                {
                    case "up":
                        {
                            position[0] = 0;
                            break;
                        }
                    case "right":
                        {
                            position[1] = position[1] == 5 ? 0 : position[1] + 1;
                            break;
                        }
                    case "down":
                        {
                            position[0] = 1;
                            break;
                        }
                    case "left":
                        {
                            position[1] = position[1] == 0 ? 5 : position[1] - 1;
                            break;
                        }
                }
                int i = position[0];
                int j = position[1];
                selectedFighters.Add(fighters[i][j]);
            }

            return selectedFighters.ToArray();
        }

        #endregion

        #region https://www.codewars.com/kata/550498447451fbbd7600041c/

        public static bool comp(int[] a, int[] b)
        {
            try
            {
                if (a.Length != b.Length) { return false; }
                else if (a.Length == 0 || b.Length == 0) { return true; }
                int count = 0;
                var c = a.Select(i => i * i).OrderBy(i => i).ToArray();
                b = b.OrderBy(i => i).ToArray();
                for (int i = 0; i < b.Length; i++)
                {
                    count = c[i] == b[i] ? count += 1 : count;
                }
                return count == b.Length;
            }
            catch (Exception e) { return false; }
        }

        #endregion

        #region https://www.codewars.com/kata/5287e858c6b5a9678200083c/

        public static bool Narcissistic(int value)
        {

            string temp = value.ToString();
            int result = 0;
            foreach (char c in temp)
            {
                result += (int)Math.Pow(int.Parse(c.ToString()), temp.Length);
            }
            return result == value;
        }

        #endregion
    }
}
