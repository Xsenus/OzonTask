using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetSumTest()
        {
            var directions = Directory.GetFiles("Example1Test");
            var directionsCount = directions.Count();;

            for (int i = 0; i < directionsCount; i += 2)
            {
                var inputs = new List<int[]>();
                var outputs = new List<int>();

                var inputsFile = File.ReadAllLines(directions[i]);
                for (int s = 1; s < inputsFile.Length; s++)
                {
                    inputs.Add(inputsFile[s].Split(' ').Select(it => int.Parse(it)).ToArray());
                }

                var outputsFile = File.ReadAllLines(directions[i + 1]);
                for (int s = 0; s < outputsFile.Length; s++)
                {
                    outputs.Add(int.Parse(outputsFile[s]));
                }

                if (inputs.Count == outputs.Count)
                {
                    for (int j = 0; j < inputs.Count; j++)
                    {
                        Assert.AreEqual(Program.GetSum(inputs[j]), outputs[j]);
                    }
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
    }
}

namespace Example2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetValueTest()
        {
            var directions = Directory.GetFiles("Example2Test");
            var directionsCount = directions.Count();;

            for (int i = 0; i < directionsCount; i+= 2)
            {
                var inputs = new List<int[]>();
                var outputs = new List<int>();
                
                var inputsFile = File.ReadAllLines(directions[i]);
                for (int s = 1; s < inputsFile.Length; s+= 2)
                {
                    inputs.Add(inputsFile[s + 1].Split(' ').Select(it => int.Parse(it)).ToArray());
                }

                var outputsFile = File.ReadAllLines(directions[i + 1]);
                for (int s = 0; s < outputsFile.Length; s++)
                {
                    outputs.Add(int.Parse(outputsFile[s]));
                }

                if (inputs.Count == outputs.Count)
                {
                    for (int j = 0; j < inputs.Count; j++)
                    {
                        Assert.AreEqual(Program.GetValue(inputs[j]), outputs[j]);
                    }
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
    }
}

namespace Example3.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetSortArrayTest()
        {
            var directions = Directory.GetFiles("Example3Test");
            var directionsCount = directions.Count();;

            for (int i = 0; i < directionsCount; i += 2)
            {
                var inputs = new List<Base>();
                var outputs = new List<Base>();

                var inputsFile = File.ReadAllLines(directions[i]);
                for (int s = 1; s < inputsFile.Length; s++)
                {
                    var @base = new Base();

                    if (string.IsNullOrWhiteSpace(inputsFile[s]))
                    {
                        continue;
                    }

                    var sizes = inputsFile[s].Split(' ').Select(it => int.Parse(it)).ToArray();
                    var row = sizes[0];
                    var column = sizes[1];

                    var array = new int[row][];

                    for (int j = 0; j < row; j++)
                    {
                        s++;
                        array[j] = inputsFile[s].Split(' ').Select(it => int.Parse(it)).ToArray();
                    }

                    s++;
                    var countClick = int.Parse(inputsFile[s]);
                    s++;

                    var clickCollection = inputsFile[s].Split(' ').Select(it => int.Parse(it)).ToArray();

                    
                    @base.ClickArray = clickCollection;
                    @base.CurrentArray = array;

                    inputs.Add(@base);
                }

                var outputsFile = File.ReadAllLines(directions[i + 1]);
                for (int s = 0; s < outputsFile.Length; s++)
                {
                    var @base = new Base();

                    var row = 0;
                    var position = s;
                    while (!string.IsNullOrWhiteSpace(outputsFile[position]))
                    {
                        row++;
                        position++;
                    }

                    var array = new int[row][];
                    for (int j = 0; j < row; j++)
                    {
                        array[j] = outputsFile[s].Split(' ').Select(it => int.Parse(it)).ToArray();
                        s++;
                    }
                    @base.CurrentArray = array;

                    outputs.Add(@base);
                }

                if (inputs.Count == outputs.Count)
                {
                    for (int j = 0; j < inputs.Count; j++)
                    {
                        var result = Program.GetSortArray(inputs[j].CurrentArray, inputs[j].ClickArray);

                        var intResult = Base.GetResult(result);
                        var outResult = Base.GetResult(outputs[j].CurrentArray);

                        Assert.AreEqual(intResult, outResult);
                    }
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
    }

    public class Base
    {
        public int[][]? CurrentArray { get; set; }
        public int[]? ClickArray { get; set; }

        public static string GetResult(int[][] array)
        {
            var result = default(string);

            foreach (var i in array)
            {
                foreach (var j in i)
                {
                    result += $"{j} ";
                }
            }

            return result;
        }
    }
}

namespace Example4.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetAnswerTest1()
        {
            var directions = Directory.GetFiles("Example4Test");
            var directionsCount = directions.Count();;

            for (int i = 0; i < directionsCount; i += 2)
            {
                var inputsFile = File.ReadAllLines(directions[i]);

                var resultIn = default(string);
                var resultOut = default(string);

                var position = 0;
                var testCaseCount = int.Parse(inputsFile[position++]);
                for (var a = 0; a < testCaseCount; a++)
                {
                    var countAttempts = int.Parse(inputsFile[position++]);
                    var dictionary = new HashSet<string>();
                    for (int j = 0; j < countAttempts; j++)
                    {
                        var login = inputsFile[position++];
                        resultIn += $"{Program.GetAnswer(login, dictionary)}{Environment.NewLine}";
                    }
                    resultIn += Environment.NewLine;
                }

                var outputsFile = File.ReadAllLines(directions[i + 1]);
                for (int s = 0; s < outputsFile.Length; s++)
                {
                    resultOut += $"{outputsFile[s]}{Environment.NewLine}";
                }

                Assert.AreEqual(resultIn?.Trim(), resultOut?.Trim());
            }
        }

        [TestMethod()]
        public void GetAnswerTest2()
        {
            Assert.AreEqual(Program.GetAnswer("-test-me", null)?.Trim(), "NO");
            Assert.AreEqual(Program.GetAnswer("+yes", null)?.Trim(), "NO");
        }
    }
}

namespace Example5.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ChangeBookTestListClass()
        {
            var directions = Directory.GetFiles("Example5Test");
            var directionsCount = directions.Count();;

            for (int i = 0; i < directionsCount; i += 2)
            {
                var inputsFile = File.ReadAllLines(directions[i]);

                var resultIn = default(string);
                var resultOut = default(string);

                var position = 0;
                var testCaseCount = int.Parse(inputsFile[position++]);
                for (var a = 0; a < testCaseCount; a++)
                {
                    var directory = new HashSet<Program.Book>();
                    var countAttempts = int.Parse(inputsFile[position++]);
                    for (int j = 0; j < countAttempts; j++)
                    {
                        var record = inputsFile[position++].Split(' ').ToArray();
                        Program.ChangeBook(directory, record);
                    }

                    resultIn += string.Join("\r\n", directory.OrderBy(o => o.Name));
                    resultIn += Environment.NewLine + Environment.NewLine;
                }

                var outputsFile = File.ReadAllLines(directions[i + 1]);
                for (int s = 0; s < outputsFile.Length; s++)
                {
                    resultOut += $"{outputsFile[s]}{Environment.NewLine}";
                }

                Assert.AreEqual(resultIn?.Trim(), resultOut?.Trim());
            }
        }

        [TestMethod()]
        public void ChangeBookTestDictionary()
        {
            var directions = Directory.GetFiles("Example5Test");
            var directionsCount = directions.Count();;

            for (int i = 0; i < directionsCount; i += 2)
            {
                var inputsFile = File.ReadAllLines(directions[i]);

                var resultIn = default(string);
                var resultOut = default(string);

                var position = 0;
                var testCaseCount = int.Parse(inputsFile[position++]);
                for (var a = 0; a < testCaseCount; a++)
                {
                    var directory = new Dictionary<string, List<string>>();
                    var countAttempts = int.Parse(inputsFile[position++]);
                    for (int j = 0; j < countAttempts; j++)
                    {
                        var record = inputsFile[position++].Split(' ').ToArray();
                        Program.ChangeBook(directory, record);
                    }

                    foreach (var item in directory.OrderBy(o => o.Key))
                    {
                        resultIn += $"{item.Key}: {item.Value.Count} {string.Join(" ", item.Value)}";
                        resultIn += Environment.NewLine;
                    }
                    resultIn += Environment.NewLine;
                }

                var outputsFile = File.ReadAllLines(directions[i + 1]);
                for (int s = 0; s < outputsFile.Length; s++)
                {
                    resultOut += $"{outputsFile[s]}{Environment.NewLine}";
                }

                Assert.AreEqual(resultIn?.Trim(), resultOut?.Trim());
            }
        }
    }
}

namespace Example6.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetFreeSeatsTest()
        {
            var directions = Directory.GetFiles("Example6Test");
            var directionsCount = directions.Count();;

            for (int i = 0; i < directionsCount; i += 2)
            {
                var inputsFile = File.ReadAllLines(directions[i]);

                var resultIn = default(string);
                var resultOut = default(string);

                var position = 0;
                var testCaseCount = int.Parse(inputsFile[position++]);

                for (var a = 0; a < testCaseCount; a++)
                {
                    position++;

                    var info = inputsFile[position++].Split(' ').Select(it => int.Parse(it)).ToArray();
                    var countCoupe = info[0];
                    var countQuery = info[1];

                    var occupiedPlaces = new HashSet<int>(Enumerable.Range(1, countCoupe * 2));
                    var useСompartment = new SortedSet<int>(Enumerable.Range(1, countCoupe));

                    for (int j = 0; j < countQuery; j++)
                    {
                        var record = inputsFile[position++].Split(' ').Select(it => int.Parse(it)).ToArray();
                        if (record.Length == 2)
                        {
                            switch (record[0])
                            {
                                case 1:
                                    resultIn += Program.GetBoughtSeat(occupiedPlaces, useСompartment, record[1]);
                                    break;

                                case 2:
                                    resultIn += Program.GetHandedOverSeat(occupiedPlaces, useСompartment, record[1]);
                                    break;
                            }
                        }
                        else
                        {
                            resultIn += Program.GetFreeSeats(occupiedPlaces, useСompartment);
                        }
                        resultIn += Environment.NewLine;
                    }
                    resultIn += Environment.NewLine;
                }
                
                var outputsFile = File.ReadAllLines(directions[i + 1]);
                for (int s = 0; s < outputsFile.Length; s++)
                {
                    resultOut += $"{outputsFile[s]}{Environment.NewLine}";
                }

                Assert.AreEqual(resultIn?.Trim(), resultOut?.Trim());
            }
        }
    }
}


namespace Example7.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetPositionTest()
        {
            var directions = Directory.GetFiles("Example7Test");
            var directionsCount = directions.Count();

            for (int i = 0; i < 10; i += 2)
            {
                var inputsFile = File.ReadAllLines(directions[i]);

                var resultIn = default(string);
                var resultOut = default(string);

                var position = 0;
                var testCaseCount = int.Parse(inputsFile[position++]);

                for (var a = 0; a < testCaseCount; a++)
                {
                    var dictyonary = new Dictionary<string, List<string>>();
                    var assemblyOrders = new HashSet<string>();

                    position++;

                    var countModul = int.Parse(inputsFile[position++]);
                    for (int j = 0; j < countModul; j++)
                    {
                        var record = inputsFile[position++].Replace(":", " ").Split(' ').ToArray();
                        dictyonary.Add(record[0], record.Skip(1).Where(w => !string.IsNullOrWhiteSpace(w)).ToList());
                    }

                    var countAssemblyOrder = int.Parse(inputsFile[position++]);
                    for (int j = 0; j < countAssemblyOrder; j++)
                    {
                        var module = inputsFile[position++];
                        resultIn += Program.GetPosition(dictyonary, assemblyOrders, module).Trim();
                    }
                }

                var outputsFile = File.ReadAllLines(directions[i + 1]);
                for (int s = 0; s < outputsFile.Length; s++)
                {
                    resultOut += $"{outputsFile[s].Trim()}{Environment.NewLine}";
                }

                resultIn = resultIn?.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Trim();
                resultOut = resultOut?.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Trim();

                Assert.AreEqual(resultIn?.Trim(), resultOut?.Trim());
            }
        }
    }
}