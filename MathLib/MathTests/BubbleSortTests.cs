using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathTests
{
    [TestClass]
    public class BubbleSortTests
    {
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
