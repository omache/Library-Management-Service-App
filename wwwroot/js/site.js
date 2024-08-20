   // Initialize cart
   let cart = {};

   function AddToCart(id, title) {
       if (cart[id]) {
           cart[id].quantity += 1;
       } else {
           cart[id] = { title: title, quantity: 1 };
       }
       UpdateCartDisplay();
   }

   function RemoveFromCart(id) {
       if (cart[id]) {
           if (cart[id].quantity > 1) {
               cart[id].quantity -= 1;
           } else {
               delete cart[id]; // Remove item from cart
           }
           UpdateCartDisplay();
       }
   }

   function UpdateCartDisplay() {
       const cartBody = document.getElementById('cart-body');
       const cartContainer = document.getElementById('cart-container');
       
       cartBody.innerHTML = ''; // Clear existing cart display

       if (Object.keys(cart).length > 0) {
           cartContainer.style.display = 'block'; // Show the cart container

           for (const id in cart) {
               if (cart.hasOwnProperty(id)) {
                   const item = cart[id];
                   const truncatedTitle = item.title.length > 35 ? item.title.substring(0, 35) + '...' : item.title;
                   const row = document.createElement('tr');
                   row.innerHTML = `
                       <td asp-label-for="Title">${truncatedTitle}</td>
                       <td asp-label-for="Quantity">${item.quantity}</td>
                       <td>
                           <button class="btn btn-transparent btn-sm text-danger fw-bold ouline-none" onclick="RemoveFromCart('${id}')">X</button>
                       </td>
                   `;
                   cartBody.appendChild(row);
               }
           }
       } else {
           cartContainer.style.display = 'none'; // Hide the cart container if empty
       }
   }

   function ClearCart() {
       cart = {}; // Clear the cart object
       UpdateCartDisplay(); // Update cart display
   }

   function submitCartData() {
    document.getElementById('cart-data').value = JSON.stringify(cart);
}





