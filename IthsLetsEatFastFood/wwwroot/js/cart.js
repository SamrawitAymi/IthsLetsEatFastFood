window.onload = function () {
    GetCartAmount();
}
function GetCartAmount() {
    fetch("https://localhost:44301/api/cart/getcartamount")
        .then(response => {
            console.log("GetCartAmount:", response);
            if (response.ok) {
                return response.text();
            }
        }).then(data => {
            var element = document.getElementById("cart-amount");
            element.innerHTML = data;
        });
}
function AddToCart(foodProductId) {
        fetch("https://localhost:44301/api/cart/addtocart?id=" + foodProductId)
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
