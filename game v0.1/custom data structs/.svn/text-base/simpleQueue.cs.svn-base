using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game_v0._1
{
    class simpleQueue
    {
        List<thingy>[] theQueue;
        int maxVal;
        public simpleQueue()
        {
            theQueue = new List<thingy>[10];
            maxVal = 0;
        }
        public void push(List<thingy> newObj)
        {
            if (maxVal >= theQueue.Length)
            {
                List<thingy>[] temp = new List<thingy>[theQueue.Length + 5];
                for (int x = 0; x < theQueue.Length; x++)
                {
                    temp[x] = theQueue[x];
                }
                theQueue = temp;
            }
            maxVal++;
            theQueue[maxVal] = newObj;
        }
        public List<thingy> pop()
        {
            List<thingy> toReturn = theQueue[maxVal];
            maxVal--;
            return toReturn;
        }
        public List<thingy> peek()
        {
            List<thingy> toReturn = theQueue[maxVal];
            return toReturn;
        }
    }
}
