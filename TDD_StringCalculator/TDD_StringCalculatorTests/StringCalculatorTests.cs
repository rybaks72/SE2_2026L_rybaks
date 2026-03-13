using TDD_StringCalculator;
namespace TDD_StringCalculatorTests
{
    [TestClass]
    public class StringCalculatorTests
    {
        StringCalculator calculator = new StringCalculator();
        [TestMethod]
        public void EmptyString_ExpectedZero()
        {
            string testString1 = "";
            string? testString2 = null;

            int result1 = calculator.Calculate(testString1);
            int result2 = calculator.Calculate(testString2!);

            Assert.AreEqual(result1, 0);
            Assert.AreEqual(result2, 0);
        }

        [TestMethod]

        public void SingleNumber_ExpectedValue()
        {
            string testString1 = "2";
            string testString4 = "5.0";
            string testString6 = "00007";
            string testString7 = "  90 ";
            string testString8 = "   ";
            string testString9 = "-5.0";

            int result1 = calculator.Calculate(testString1);
            int result6 = calculator.Calculate(testString6);
            int result7 = calculator.Calculate(testString7);
            int result8 = calculator.Calculate(testString8);
            int result9 = calculator.Calculate(testString9);

            Assert.AreEqual(result1, 2);
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString4));
            Assert.AreEqual(result6, 7);
            Assert.AreEqual(result7, 90);
            Assert.AreEqual(result8, 0);
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString9));
        }

        [TestMethod]
        public void TwoNumbersComma_ExpectedSum()
        {
            string testString3 = "1,";
            string testString4 = ",";
            string testString5 = "    ,      ";

            int result3 = calculator.Calculate(testString3);
            int result4 = calculator.Calculate(testString4);
            int result5 = calculator.Calculate(testString5);

            Assert.AreEqual(result3, 1);
            Assert.AreEqual(result4, 0);
            Assert.AreEqual(result5, 0);
        }

        [TestMethod]
        public void TwoNumbersNewLine_ExpectedSum()
        {
            string testString3 = "1\n";
            string testString4 = "\n";
            string testString5 = "    \n      ";

            int result3 = calculator.Calculate(testString3);
            int result4 = calculator.Calculate(testString4);
            int result5 = calculator.Calculate(testString5);

            Assert.AreEqual(result3, 1);
            Assert.AreEqual(result4, 0);
            Assert.AreEqual(result5, 0);
        }

        [TestMethod]
        public void ThreeNumbersEither_ExpectedSum()
        {
            string testString6 = ",  ,";
            string testString7 = "12,\n1";

            int result6 = calculator.Calculate(testString6);
            int result7 = calculator.Calculate(testString7);

            Assert.AreEqual(result6, 0);
            Assert.AreEqual(result7, 13);
        }

        [TestMethod]
        public void NegativeNumbers_ExpectedError()
        {
            string testString1 = "12,-12";
            string testString2 = "-2,     ";
            string testString3 = "12\n-12";
            string testString4 = "12,-12\n1";
            string testString5 = "0012\n       ,-12";
            string testString6 = "-1234\n-1234\n-1";
            string testString7 = "12\n-12,12";
            string testString8 = "-2\n     ";
            string testString9 = "-2";

            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString1));
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString2));
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString3));
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString4));
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString5));
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString6));
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString7));
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString8));
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString9));
        }

        [TestMethod]
        public void NumbersGreaterThan1000_ExpectedIgnorance()
        {
            string testString1 = "2115";
            string testString2 = "1234,1234";
            string testString3 = "1234\n1234";
            string testString4 = "1234,1234,1";
            string testString5 = "1234\n1234\n1";

            int result1 = calculator.Calculate(testString1);
            int result2 = calculator.Calculate(testString2);
            int result3 = calculator.Calculate(testString3);
            int result4 = calculator.Calculate(testString4);
            int result5 = calculator.Calculate(testString5);

            Assert.AreEqual(result1, 0);
            Assert.AreEqual(result2, 0);
            Assert.AreEqual(result3, 0);
            Assert.AreEqual(result4, 1);
            Assert.AreEqual(result5, 1);
        }

        [TestMethod]
        public void SingleCharDelimiterDeclaration()
        {
            string testString1 = "//#\n1#4,9";
            string testString2 = "1#3#4";

            int result1 = calculator.Calculate(testString1);

            Assert.AreEqual(result1, 14);
            Assert.ThrowsException<Exception>(() => calculator.Calculate(testString2));
        }
    }
}