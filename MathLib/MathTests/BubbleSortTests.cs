using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathTests
{
    [TestClass]
    public class BubbleSortTests
    {

        [TestMethod]
        public void Sort_Puz5()
        {
            //arrange

            //act

            //assert
        }

        [TestMethod]
        public void Sort_puz1()
        {
            //arrange
            BubbleSort bubble = new BubbleSort();
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
            BubbleSort bubble = new BubbleSort();
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
            BubbleSort bubble = new BubbleSort();
            int[] testArr = new int[1];
            Random n = new Random();
            testArr[0] = n.Next(-5, 100);
            //act
            testArr = bubble.DoBubbleSort(testArr);
            //assert
            Assert.AreEqual("Входной массив содержит одно значение", testArr);
        }
        [TestMethod]
        public void Sort_Puz8()
        {
            //arrange
            BubbleSort bubble = new BubbleSort();

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
        [TestMethod]
        public void Sort_Puz6()
        {
            //arrange

            //act

            //assert
        }

        [TestMethod]
        public void Sort_Puz7()
        public void Sort_Puz9()
        {
            //arrange
            BubbleSort bubble = new BubbleSort();

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
            BubbleSort bubble = new BubbleSort();

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
