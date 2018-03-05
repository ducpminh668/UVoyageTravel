using System;

namespace UvoyageTravel.Models.Entity
{
    [Serializable]
    public class CartItem
    {
        public PhongKhachSan Phong { get; set; }
        public int Quantity { get; set; }
    }
}