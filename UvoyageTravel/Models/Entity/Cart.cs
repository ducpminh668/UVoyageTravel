using System.Collections.Generic;
using System.Linq;

namespace UvoyageTravel.Models.Entity
{
    public class Cart
    {
        private List<CartItem> _ListCart = new List<CartItem>();

        public void AddItem(PhongKhachSan phong, int quantity)
        {
            CartItem item = _ListCart.Where(p => p.Phong.ID == phong.ID).FirstOrDefault();
            if (item == null)
            {
                _ListCart.Add(new CartItem
                {
                    Phong = phong,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
                if (item.Quantity <= 0)
                {
                    _ListCart.RemoveAll(i => i.Phong.ID == phong.ID);
                }
            }
        }

        public void UpdateItem(PhongKhachSan phong, int quantity)
        {
            CartItem item = _ListCart.Where(p => p.Phong.ID == phong.ID).FirstOrDefault();
            if (item != null)
            {
                if (quantity > 0)
                {
                    item.Quantity = quantity;
                }
                else
                {
                    _ListCart.RemoveAll(i => i.Phong.ID == phong.ID);
                }
            }
        }

        public void RemoveItem (PhongKhachSan phong)
        {
            _ListCart.RemoveAll(i => i.Phong.ID == phong.ID);
        }

        public decimal? ComputeTotalValue()
        {
            return _ListCart.Sum(x => x.Phong.GiaTien * x.Quantity);
        }

        public int? CoputeTotalRoom()
        {
            return _ListCart.Sum(x => x.Quantity);
        }

        public void Clear()
        {
            _ListCart.Clear();
        }

        public IEnumerable<CartItem> Carts
        {
            get { return _ListCart; }
        }
    }
}