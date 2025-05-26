using Newtonsoft.Json;

namespace Project.WebAPI.Models.ShoppingTools
{
    [Serializable]
    public class Cart
    {
        readonly Dictionary<int, CartItem> _myCart;
        public Cart()
        {
            _myCart = new Dictionary<int,CartItem>();
        }
        [JsonProperty]
        public List<CartItem> CartItems { 
            get
            {
              return  _myCart.Values.ToList();
            } 
        }
        public void AddToCart(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.ID))
            {
                _myCart[cartItem.ID].Quantity++;
                return;
            }
            _myCart.Add(cartItem.ID, cartItem);
        }
        public void Decrease(int id)
        {
            _myCart[id].Quantity--;
            if (_myCart[id].Quantity == 0)
            {

                _myCart.Remove(id);
            }
        }
        public void Increase(int id)
        {
            _myCart[id].Quantity++ ;
        }
        public void RemoveFromCart(int id)
        {
            _myCart.Remove(id);
        }
        [JsonProperty]
        public decimal TotalPrice { get; set; }
    }
}
