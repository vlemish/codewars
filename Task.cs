using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace CodeWarsSolutions
{

    public abstract class Task
    {

        #region https://www.codewars.com/kata/514b92a657cdc65150000006/
        public static int Solution(int value)
        {
            //int sum = 0;
            //for (int i = 3; i < value; i++)
            //{
            //    if (i % 3 == 0 && i % 5 == 0)
            //    {
            //        sum += i;
            //    }
            //    else
            //    {

            //        if (i % 3 == 0)
            //        {
            //            sum += i;
            //        }

            //        if (i % 5 == 0)
            //        {
            //            sum += i;
            //        }
            //    }
            //}
            //return sum;


            ////LINQ (not mine)
            return Enumerable.Range(0, value)
                 .Where(x => x % 3 == 0 || x % 5 == 0)
                 .Sum();
        }

        #endregion
        #region https://www.codewars.com/kata/51f2d1cafc9c0f745c00037d/

        public static bool Solution(string str, string ending)
        {

            //if (str.Length < ending.Length) { return false; }

            //int index = 0;
            //for (int i = str.Length - ending.Length; i < str.Length; i++)
            //{
            //    char first = str[i];
            //    char second = ending[index];
            //    index++;
            //    if (first != second)
            //    {
            //        return false;
            //    }
            //}

            //return true;


            //with string internal methods;

            return str.Length < ending.Length ? false : str.Substring(str.Length - ending.Length).Contains(ending);
        }

        #endregion

        #region https://www.codewars.com/kata/54bf1c2cd5b56cc47f0007a1/

        public static int DuplicateCount(string str)=> str.ToLower().GroupBy(g => g).Where(s => s.Count() > 1).Select(s => s).Count();

            #endregion

        #region https://www.codewars.com/kata/5679aa472b8f57fb8c000047
        public delegate int SideSum(int[] array, int startIndex, int lastIndex);
        public static int FindEvenIndex(int[] arr)
        {

            SideSum sideSum = (a, sIndex, lIndex) =>
            {
                int sum = 0;
                for (int i = sIndex; i < lIndex; i++)
                {
                    sum += a[i];
                }

                return sum;
            };


            for (int i = 0; i < arr.Length; i++)
            {
                int left = i == 0 ? 0 : sideSum(arr, 0, i);

                int startWith = i + 1 > arr.Length ? arr.Length : i + 1;
                int right = sideSum(arr, startWith, arr.Length);

                if (left == right)
                {
                    return i;
                }
            }

            return -1;
        }
        #endregion

        #region https://www.codewars.com/kata/576757b1df89ecf5bd00073b/

        public static String LongestConsec(string[] strarr, int k)
        {
            if (strarr.Length == 0 || k <= 0)
            {
                return string.Empty;
            }

            if (k == 1)
            {
                return strarr.OrderBy(o => o.Length).Last();
            }

            List<string> strings = new List<string>();

            for (int i=0; i < strarr.Length+1 / k; i++)
            {
                strings.Add($"{strarr[i]}{strarr[i + 1]}");
            }

            return strings.OrderBy(o => o.Length).Last();
        }


        #endregion

        #region https://www.codewars.com/kata/57eb8fcdf670e99d9b000272
        public static string High(string s)
        {
            var splited = s.Split(' ');
            var list = new List<int>();

            foreach(var i in splited)
            {
                list.Add(LetterToInt(i));
            }

            return splited[list.IndexOf(list.Max())];

            //Some bright guy did in the way i wanted to do...
            //return s.Split(' ').OrderBy(a => a.Select(b => b - 96).Sum()).Last();
        }

        private static int LetterToInt(string s)
        {
            return s.Select(i => ((int)i-96)).Sum();
        }

        #endregion

        #region https://www.codewars.com/kata/52597aa56021e91c93000cb0

        public static int[] MoveZeroes(int[] arr)
        {
            var zeroes = arr.Where(i => i == 0).ToArray();
            var notZeroes = arr.Where(i => i != 0).ToArray();

            var rightSequance = new List<int>();
            rightSequance.AddRange(notZeroes);
            rightSequance.AddRange(zeroes);

            return rightSequance.ToArray(); 

      
        }

        #endregion

        #region https://www.codewars.com/kata/541c8630095125aba6000c00/
        public static int DigitalRoot(long n)
        {
            int result=0;
            string strN = n.ToString();

            while (strN.Length != 1)
            {
                result = 0;
                for(int i=0; i < strN.Length; i++)
                {
                    result +=int.Parse(strN[i].ToString());
                }
                strN = result.ToString();
            }

            return result;
        }

        public static int DigitalRoot(long n, string s) => (int) (1 + (n - 1) % 9);

        #endregion https://www.codewars.com/kata/541c8630095125aba6000c00/

        #region https://www.codewars.com/kata/520b9d2ad5c005041100000f/
        public static string PigIt(string str)
        {
            var arr = str.Split(' ');
            List<string> newArr = new List<string>();
            foreach (var el in arr)
            {
                var temp = el[0];
                newArr.Add($"{el.Remove(0, 1)}{temp}ay");
            }

            return string.Join(" ", newArr);

            //with Linq 
            //return string.Join(" ", str.Split().Select(i => i.Substring(1) + i[0] + "ay"));
        }


        #endregion https://www.codewars.com/kata/520b9d2ad5c005041100000f/

        #region https://www.codewars.com/kata/54da539698b8a2ad76000228/

        public static bool IsValidWalk(string[] walk)
        {
            int countWest = 0;
            int countNorth = 0;
            int countSouth = 0;
            int countEast = 0;

            foreach (var w in walk)
            {
                switch (w)
                {
                    case "n":
                        {
                            countNorth++;
                            break;
                        }
                    case "s":
                        {
                            countSouth++;
                            break;
                        }
                    case "w":
                        {
                            countWest++;
                            break;
                        }
                    case "e":
                        {
                            countEast++;
                            break;
                        }
                }
            }

            bool isPoint = countNorth == countSouth && countWest == countEast;
            bool isTakenTen = countWest + countNorth + countSouth + countEast == 10;

            return isPoint && isTakenTen ? true : false;


        }

        #endregion

        #region https://www.codewars.com/kata/54d512e62a5e54c96200019e/

        public static String Factors(int lst)
        {
            int divider = 2;
            int count = 0;
            List<string> chars = new List<string>();
            while (lst != 1)
            {
                if (lst % divider == 0)
                {
                    lst /= divider;
                    count++;
                    chars.Add(divider.ToString());
                }
                else
                {
                    divider++;
                }
            }

            return string.Join("*", chars);
        }

        #endregion 

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

        #region https://www.codewars.com/kata/513e08acc600c94f01000001/

        public static string Rgb(int r, int g, int b)
        {

            r = r < 0 ? 0 : r > 255 ? 255 : r;
            g = g < 0 ? 0 : g > 255 ? 255 : g;
            b = b < 0 ? 0 : b > 255 ? 255 : b;

            string rStr = r < 15 && r > 0 ? "0" : null;
            rStr += ToHex(r, r == 0 ? "00" : null);
            string gStr = g < 15 && g > 0 ? "0" : null;
            gStr += ToHex(g, g == 0 ? "00" : null);
            string bStr = b < 15 && b > 0 ? "0" : null;
            bStr += ToHex(b, b == 0 ? "00" : null);

            return string.Join("", rStr, gStr, bStr);
        }

        public static string ToHex(int value, string hex = null)
        {
            if (value <= 0 && hex != null)
            {
                return string.Join("", hex.Reverse());
            }

            int divided = value / 16;
            int remainder = value % 16;


            switch (remainder)
            {
                case 10:
                    {
                        hex += 'A';
                        break;
                    }

                case 11:
                    {
                        hex += 'B';
                        break;
                    }

                case 12:
                    {
                        hex += 'C';
                        break;
                    }

                case 13:
                    {
                        hex += 'D';
                        break;
                    }

                case 14:
                    {
                        hex += 'E';
                        break;
                    }

                case 15:
                    {
                        hex += 'F';
                        break;
                    }
                default:
                    {
                        hex += remainder;
                        break;
                    }
            }

            return ToHex(divided, hex);
        }

        #endregion

        #region https://www.codewars.com/kata/596fba44963025c878000039/
        public static string Contamination(string text, string character)
        {
            return text.Length >= 0 || character.Length >= 0 ? string.Join("", text.Select(x => character)) : string.Empty;
        }
        #endregion

        #region https://www.codewars.com/kata/55908aad6620c066bc00002a/
        public static bool XO(string input)
        {
            var x = input.ToLower().Where(i => i == 'x').Count();
            var o = input.ToLower().Where(i => i == 'o').Count();
            return x == o;
        }

        #endregion

        #region https://www.codewars.com/kata/54df2067ecaa226eca000229/
        public static long? RangeSum(long n)
        {
            if (n <= 0)
            {
                return null;
            }
            return (n * (n + 1) / 2);

        }

        #endregion

        #region https://www.codewars.com/kata/57f609022f4d534f05000024/
        public static int Stray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {

                int temp = numbers[i];
                if (temp != numbers[0] && temp != numbers[1])
                {
                    return temp;
                }
            }

            return numbers[0];

        }
        #endregion

        #region https://www.codewars.com/kata/54d512e62a5e54c96200019e/

        //public static String Factors(int lst)
        //{
        //    int divider = 2;
        //    int count = 0;
        //    List<string> chars = new List<string>();
        //    while (lst != 1)
        //    {
        //        if (lst % divider == 0)
        //        {
        //            lst /= divider;
        //            count++;
        //            chars.Add(divider.ToString());
        //        }
        //        else
        //        {
        //            divider++;
        //        }
        //    }

        //    return string.Join("*", chars);
        //}

        #endregion 

        #region https://www.codewars.com/kata/5526fc09a1bbd946250002dc/
        public static int Find(int[] integers)
        {
            var odd = integers.Where(i => i % 2 == 0).ToArray();
            var even = integers.Where(i => i % 2 != 0).ToArray();
            return odd.Length > even.Length ? even[0] : odd[0];
        }

        #endregion

        #region https://www.codewars.com/kata/56b5afb4ed1f6d5fb0000991/
        public static string RevRot(string strng, int sz)
        {
            Console.WriteLine($"{strng}, {sz}");
            List<string> list = new List<string>();
            int length = strng.Length;
            string output = "";
            if (sz <= 0 || sz > strng.Length) { return ""; }
            while (length != 0 && length >= sz)
            {
                string temp = strng.Substring(0, sz);
                list.Add(temp);
                strng = strng.Remove(0, sz);
                length -= sz;
            }
            for (int i = 0; i < list.Count; i++)
            {
                var temp2 = list[i];
                int sum = 0;
                foreach (var el in temp2)
                {
                    sum += (int)Math.Pow((int)el - 48, 3);
                }
                if (sum % 2 == 0)
                {
                    char[] arr = temp2.ToCharArray();
                    Array.Reverse(arr);
                    output += new string(arr);
                }
                else
                {
                    char temp3 = temp2[0];
                    output += $"{temp2.Remove(0, 1)}{temp3}";
                }
            }
            return output.ToString();
        }

        #endregion

        #region https://www.codewars.com/kata/52c31f8e6605bcc646000082/
        public static int[] TwoSum(int[] numbers, int target)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int temp;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    temp = numbers[i] + numbers[j];
                    if (temp == target)
                    {
                        list.Add(i);
                        list.Add(j);
                        break;
                    }
                }
            }

            return list.ToArray();
        }

        #endregion

        #region https://www.codewars.com/kata/52efefcbcdf57161d4000091/
        public static Dictionary<char, int> Count(string str)
        {
            Dictionary<char, int> list = new Dictionary<char, int>();
            char temp = ' ';
            int count = 0;
            var sortedStr = str.OrderBy(s => s).ToArray();
            for (int i = 0; i < sortedStr.Length; i += count)
            {
                temp = sortedStr[i];
                count = 0;
                for (int j = 0; j < sortedStr.Length; j++)
                {
                    if (sortedStr[i] == sortedStr[j])
                    {
                        count++;
                    }
                }
                list.Add(temp, count);
            }
            return list;
        }

        #endregion

        #region https://www.codewars.com/kata/56606694ec01347ce800001b/
        public static bool IsTriangle(int a, int b, int c)
        {
            return a > 0 && b > 0 &&
            a + b > c && a + c > b && b + c > a ?
            true : false;
        }

        #endregion

        #region https://www.codewars.com/kata/545cedaa9943f7fe7b000048/
        public static bool IsPangram(string str)
        {
            char[] alphabet =
           {
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
            };
            if (str.Length >= 26)
            {
                str = str.ToLower();
                int count = 0;
                for (int i = 0; i < alphabet.Length; i++)
                {
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (alphabet[i] == str[j])
                        {
                            Console.WriteLine($"letters : {alphabet[i]} and {str[j]} are the same!");
                            count++;
                            Console.WriteLine(count);
                            break;
                        }
                    }
                }
                return count >= 26 ? true : false;
            }
            else
            {
                return false;

            }
        }

        #endregion

        #region https://www.codewars.com/kata/57a0556c7cb1f31ab3000ad7/
        public static string MakeUpperCase(string str)
        {
            return str.ToUpper();
        }

        #endregion

        #region https://www.codewars.com/kata/55eca815d0d20962e1000106/
        public static int[] GenerateRange(int min, int max, int step)
        {
            List<int> arr = new List<int>();
            for (; min <= max; min += step)
            {
                arr.Add(min);
            }
            return arr.ToArray();
        }

        #endregion

        #region https://www.codewars.com/kata/5264d2b162488dc400000001
        public static string SpinWords(string sentence)
        {
            var words = sentence.Split(' ');
            string result = null;

            for (int i = 0; i < words.Length; i++)
            {
                char[] temp = words[i].ToCharArray();
                if (temp.Length >= 5)
                {
                    Array.Reverse(temp);
                    result += new string(temp);
                }
                else
                {
                    result += new string(temp);
                }
                result += " ";
            }
            result = result.Remove(result.LastIndexOf(" "), 1);
            return result;
        }

        #endregion

        #region https://www.codewars.com/kata/5388f0e00b24c5635e000fc6/
        public class Swapper
        {
            public object[] Arguments { get; private set; }

            public Swapper(object[] args)
            {
                Arguments = args;
            }

            public void SwapValues()
            {

                object temp = Arguments[0];
                Arguments[0] = Arguments[1];
                Arguments[1] = temp;
            }

        }
        #endregion

        #region https://www.codewars.com/kata/5772da22b89313a4d50012f7/
        public static string Greet(string name, string owner)
        {
            if (name.Length != owner.Length) { return "Hello guest"; }
            else
            {
                int count = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i] == owner[i])
                    {
                        count++;
                    }
                }
                if (count == name.Length) { return "Hello boss"; }
            }
            return "Hello guest";
        }

        #endregion

        #region https://www.codewars.com/kata/5949481f86420f59480000e7/
        public static string OddOrEven(int[] array)
        {
            int sum = 0;
            string odd = "odd";
            string even = "even";
            if (array.Length < 1)
            {
                return even;
            }
            foreach (var i in array)
            {
                sum += i;
            }
            Console.WriteLine(sum);
            if (sum % 2 == 0)
            {
                return even;
            }
            else { return odd; }
        }

        #endregion

        #region https://www.codewars.com/kata/5839edaa6754d6fec10000a2/
        public static char FindMissingLetter(char[] array)
        {
            char result = ' ';
            int temp = Convert.ToInt32(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                int temp1 = Convert.ToInt32(array[i]);
                Console.WriteLine($"temp: {temp}\ntemp1: {temp1}");
                int diff = temp1 - temp;
                Console.WriteLine($"Difference between them: {diff}");
                if (diff == 1)
                {
                    temp = temp1;
                    Console.WriteLine("THERE ARE  NO DIFFERENCE!");
                }
                else
                {
                    result = Convert.ToChar(temp + 1);
                    Console.WriteLine("THERE ARE DIFFERENCE!");
                }

            }
            return result;
        }

        #endregion

        #region https://www.codewars.com/kata/5626b561280a42ecc50000d1/
        public class SumDigPower
        {

            public static long[] SumDigPow(long a, long b)
            {
                List<long> longs = new List<long>();
                for (long i = a; i < b; i++) //every step we'll send some value [a...b] into method IsEureka, if we have true, we'll add this value to massive
                {
                    if (IsEureka(i))
                    {
                        longs.Add(i);
                    }
                }
                return longs.ToArray();
            }

            public static bool IsEureka(long x)
            {

                string strX = Convert.ToString(x);
                long sum = 0;
                long temp = 0;
                for (int i = 0; i < strX.Length; i++)
                {
                    temp = Convert.ToInt64(strX[i]) - 48;
                    sum += (int)Math.Pow((temp), (i + 1));
                }
                if (x == sum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region https://www.codewars.com/kata/55685cd7ad70877c23000102/
        public static int MakeNegative(int number)
        {
            return Math.Abs(number) * -1;
        }

        #endregion

        #region https://www.codewars.com/kata/55c45be3b2079eccff00010f/
        public static string Order(string words)
        {
            string finalString = "";
            string stringTemp = "";
            int intTemp = 0;
            List<string> strings = new List<string>();
            strings.AddRange(words.Split(' '));
            List<int> numb = new List<int>();

            for (int i = 0; i < strings.Count; i++)
            {
                string temp = strings[i];
                for (int j = 0; j < temp.Length; j++)
                {
                    if (Char.IsNumber(temp[j]))
                    {
                        numb.Add(temp[j]);
                    }
                }
            }

            for (int i = 0; i < numb.Count; i++)
            {

                for (int j = i + 1; j < numb.Count; j++)
                {
                    if (numb[i] > numb[j])
                    {
                        intTemp = numb[i];
                        stringTemp = strings[i];
                        strings[i] = strings[j];
                        numb[i] = numb[j];
                        strings[j] = stringTemp;
                        numb[j] = intTemp;
                    }
                }
            }

            for (int i = 0; i < strings.Count - 1; i++)
            {
                finalString += $"{strings[i]} ";
            }

            return finalString += $"{strings[strings.Count - 1]}";
        }

        #endregion

        #region https://www.codewars.com/kata/59752e1f064d1261cb0000ec/
        public static string WhatTimeIsIt(double angle)
        {
            if (angle < 30)
            {
                angle += angle;
                angle = (int)angle;
                if (angle <= 9)
                {
                    return $"12:0{angle}";
                }
                return $"12:{angle}";
            }
            int min = 0;
            int hour = 0;
            double angle1 = angle;
            string result = "";
            angle += angle;
            hour = (int)angle / 60;
            bool hourIsExist = hour > 0;
            if (hour <= 9)
            {
                result = $"0{hour}:";
            }
            else
            {
                result = $"{hour}:";
            }
            if (hourIsExist)
            {
                min = (int)angle - (60 * hour);
                if (min <= 9)
                {
                    result += $"0{min}";
                }
                else
                    result += $"{min}";
            }
            else
            {
                min = (int)angle;
                result += $"{min}";
            }

            return result;
        }

        #endregion

        #region https://www.codewars.com/kata/54e6533c92449cc251001667/
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {

            T previous = default(T);
            foreach (T current in iterable)
            {
                if (!current.Equals(previous))
                {
                    previous = current;
                    yield return current;
                }
            }
        }

        #endregion

        #region https://www.codewars.com/kata/5544c7a5cb454edb3c000047/
        public static int bouncingBall(double h, double bounce, double window)
        {
            int count = 0;
            if (h > 0 && bounce > 0 && bounce < 1 && h > window)
            {
                while (h >= window)
                {
                    count++;
                    h *= bounce;
                    if (h > window)
                    {
                        count++;
                    }
                }
                if (count == 2) { return 1; }
                else
                {
                    return count;
                }
            }
            else { return -1; }
        }
        #endregion


    }
}
