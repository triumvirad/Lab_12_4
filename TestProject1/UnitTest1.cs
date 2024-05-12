using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using ClassLibrary;
using Lab_12_4;
namespace TestProject4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodRemove()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myCollection.Add(muz);
            myCollection.Remove(muz);
            Assert.AreEqual("False", myCollection.Contains(muz).ToString());
        }
        [TestMethod]
        public void TestMethodAdd1()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myCollection.Add(muz);
            Assert.AreEqual("True", myCollection.Contains(muz).ToString());
        }
        [TestMethod]
        public void TestMethodAdd2()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>(10);
            MusicalInstrument muz = new MusicalInstrument();
            muz.RandomInit();
            myCollection.Add(muz);
            Assert.IsTrue(myCollection.Contains(muz));
        }
        [TestMethod]
        public void TestMethodAddContains()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myCollection.Add(muz);
            Assert.AreEqual(true, myCollection.Contains(muz));
        }
        [TestMethod]
        public void TestMethodLength()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>(10);
            Assert.IsTrue(myCollection.Capacity == 10 && myCollection.Count == 0);
        }

        [TestMethod]
        public void TestMethodFindItem1()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>(10);
            MusicalInstrument muz = new MusicalInstrument();
            myCollection.Add(muz);
            myCollection.Remove(muz);
            Assert.IsTrue(!myCollection.Contains(muz));
        }
        [TestMethod]
        public void TestMethodFindItem2()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>(10);
            MusicalInstrument muz = new MusicalInstrument();
            myCollection.Add(muz);
            Assert.IsTrue(myCollection.Contains(muz));
        }

        [TestMethod]
        public void TestMethodClear()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>(10);
            myCollection.Clear();
            Assert.IsTrue(myCollection.Count == 0);
        }

        [TestMethod]
        public void TestMethodCopyTo()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>(10);
            MusicalInstrument[] array = new MusicalInstrument[10];
            myCollection.CopyTo(array, 1);
            bool isTrue = false;
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                foreach (MusicalInstrument mi in array)
                {
                    if (array[i] == mi)
                    {
                        cnt++;
                    }
                }
            }
            if (cnt == 9 || cnt == 8)
            {
                isTrue = true;
            }
            Assert.AreEqual(true, isTrue);
        }
        [TestMethod]
        public void TestMethodCopyToEmpty()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>();
            Assert.ThrowsException<NullReferenceException>(() => { myCollection.CopyTo(null, 0); });
        }

        [TestMethod]
        public void TestMethodCloneList1()
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>();
            MyCollection<MusicalInstrument> myCollectionClone = (MyCollection<MusicalInstrument>)myCollection.Clone();
            Assert.AreNotEqual(myCollection, myCollectionClone);
        }

    }
}