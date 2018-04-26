using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary1;

namespace MathTests
{
    [TestClass]
    public class BubbleSortTests
    {
        private static BubbleSort bubble;

        [TestInitialize]
        public static void ClassInitialize()
        {
            bubble = new BubbleSort();
        }


        [TestMethod]
        public void Sort_puz1()
        {
            //arrange
            //BubbleSort bubble = new BubbleSort();
            int[] testArr = new int[10];
            Random n = new Random();
            for (int i = 0; i < testArr.Length; i++)
            {
                testArr[i] = n.Next(-5, 100);
            }
            //act
            testArr = bubble.DoBubbleSort(testArr);
            //assert
            Assert.IsTrue(Check(testArr));
        }

        [TestMethod]
        public void Sort_puz2()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void Sort_puz3()
        {
            //arrange
            //BubbleSort bubble = new BubbleSort();
            int[] testArr = new int[0];
            //act
            testArr = bubble.DoBubbleSort(testArr);
            //assert
            Assert.AreEqual("Входной массив пуст",testArr);
        }

        [TestMethod]
        public void Sort_puz4()
        {
            //arrange
           // BubbleSort bubble = new BubbleSort();
            int[] testArr = new int[1];
            Random n = new Random();
            testArr[0] = n.Next(-5, 100);
            //act
            testArr = bubble.DoBubbleSort(testArr);
            //assert
            Assert.AreEqual("Входной массив содержит одно значение", testArr);
        }

        [TestMethod]
        public void Sort_Puz5()
        {
            //arrange
            int[] testArr = {1,2,3,4,5};

            //act
            testArr = bubble.DoBubbleSort(testArr);

            //assert
            Assert.AreEqual("Входной массив уже отстортирован", testArr);
        }

        [ExpectedException(typeof(ArgumentException),"Во входном массиве присутствуют не численные значения")]
        [TestMethod]
        public void Sort_Puz6()
        {
            //arrange
            string[] testArr = {"test", "1", "2", "3"};
            //act
            //testArr = bubble.DoBubbleSort(testArr);
            // Нужно переделать метод пузырька, чтобы тест заработал
        }

        [ExpectedException(typeof(ArgumentException), "Во входном массиве присутствуют значения, выходящие за числовой диапазон")]
        [TestMethod]
        public void Sort_Puz7()
        {
            //arrange
            decimal[] testArr = {decimal.MaxValue, 0, 2, decimal.MinValue};

            //act
            //testArr = bubble.DoBubbleSort(testArr);
            // Нужно переделать метод пузырька, чтобы тест заработал
        }


        [TestMethod]
        public void Sort_Puz8()
        {
            //arrange
            //BubbleSort bubble = new BubbleSort();

            Random n = new Random();
            int[] mas = new int[1000];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = n.Next(1, 1000);
            }
            //act
            mas = bubble.DoBubbleSort(mas);
            //assert
            Assert.IsTrue(Check(mas));
        }

        public bool Check(int[] mas)
        {
            for (int i = 0; i < mas.Length - 1; i++)
            {
                if (mas[i] > mas[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public void Sort_Puz9()
        {
            //arrange
            //BubbleSort bubble = new BubbleSort();

            Random n = new Random();
            int[] mas = new int[10000];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = n.Next(1, 10000);
            }

            //act
            mas = bubble.DoBubbleSort(mas);
            //assert
            Assert.IsTrue(Check(mas));
        }
        [TestMethod]
        public void Sort_Puz10()
        {
            //arrange
            //BubbleSort bubble = new BubbleSort();

            Random n = new Random();
            int[] mas = new int[100000];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = n.Next(1, 100000);
            }
            //act
            mas = bubble.DoBubbleSort(mas);
            //assert
            Assert.IsTrue(Check(mas));
        }
    }
}
