using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deník
{
    public class Denik
    {
        private LinkedList<Zaznam> zaznamy = new LinkedList<Zaznam>();
        private LinkedListNode<Zaznam> aktualniZaznam;
        public void AddZaznam(Zaznam zaznam)
        {
            zaznamy.AddLast(zaznam);
            aktualniZaznam = zaznamy.Last;
        }
        public void RemoveZaznam()
        {
            if (aktualniZaznam != null)
            {
                if (aktualniZaznam != null)
                {
                    var toRemove = aktualniZaznam;
                    aktualniZaznam = aktualniZaznam.Next ?? aktualniZaznam.Previous;
                    zaznamy.Remove(toRemove);
                    aktualniZaznam = zaznamy.First;
                }
            }
        }
        public Zaznam GetAktualniZaznam()
        {
            return aktualniZaznam?.Value;
        }
        public void Predchozi()
        {
            if (aktualniZaznam != null)
            {
                if (aktualniZaznam.Previous != null)
                {
                    aktualniZaznam = aktualniZaznam.Previous;
                }
                else
                {
                    aktualniZaznam = zaznamy.Last;
                }
            }
        }
        public void Dalsi()
        {
            if (aktualniZaznam != null)
            {
                if (aktualniZaznam.Next != null)
                {
                    aktualniZaznam = aktualniZaznam.Next;
                }
                else
                {
                    aktualniZaznam = zaznamy.First;
                }
            }
        }
        public int GetPocetZaznamu()
        {
            return zaznamy.Count;
        }
    }
}
