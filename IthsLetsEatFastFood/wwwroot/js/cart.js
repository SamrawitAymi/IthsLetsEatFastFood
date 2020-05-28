window.onload = function () {
    GetCartAmount();
}
function GetCartItem() {
    fetch("http://localhost:50161/api/shoppingCart/getcartamount")
        .then(response => {
            console.log("GetCartAmount:", response);
            if (response.ok) {
                return response.text();
            }
        }).then(data => {
            var element = document.getElementById("cart-amount");
            element.innerHTML = data;
        });
function AddToCart(foodProductId) {
    fetch("http://localhost:50161/api/shoppingCart/addtocart?id=" + foodProductId)
        .then(response => {
            console.log("response:", response);
            if (response.ok) {
                return response.text();
            }
        }).then(data => {
            var element = document.getElementById("cart-amount");
            element.innerHTML = data;
        });
}