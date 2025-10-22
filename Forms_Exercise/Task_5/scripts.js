function getPrice(event) {
    event.preventDefault(); 

    const nameInput = document.querySelector('input[name="name"]');
    const userName = nameInput.value || "Потребител";

    const pizzas = document.getElementsByName('type_pizza');
    let pizzaPrice = 0;
    for (let i = 0; i < pizzas.length; i++) {
        if (pizzas[i].checked) {
            pizzaPrice = Number(pizzas[i].value);
            break;
        }
    }

    const sizeSelect = document.getElementById('pizza_size');
    const sizePrice = Number(sizeSelect.value);

    let quantity = Number(document.getElementById('quantity').value);
    if (!quantity) quantity = 1;

    const total = (pizzaPrice + sizePrice) * quantity;

    alert(`Здравей, ${userName}! Общата цена на поръчката е ${total} лв`);
}