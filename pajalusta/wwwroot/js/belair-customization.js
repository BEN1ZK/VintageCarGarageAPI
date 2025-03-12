const basePrice = 50000;
let totalPrice = basePrice;

function showSummary() {
    const color = document.getElementById('color').value;
    const interior = document.getElementById('interior').value;
    const wheels = document.getElementById('wheels').value;

    const colorPrice = 500;
    const interiorPrice = interior === 'Leather' ? 1000 : 500;
    const wheelsPrice = wheels === 'Alloy' ? 1500 : wheels === 'Chrome' ? 2000 : 0;

    totalPrice = basePrice + colorPrice + interiorPrice + wheelsPrice;

    document.getElementById('summaryList').innerHTML = `
        <li>Color: ${color} (+$${colorPrice})</li>
        <li>Interior: ${interior} (+$${interiorPrice})</li>
        <li>Wheels: ${wheels} (+$${wheelsPrice})</li>
    `;
    document.getElementById('totalPrice').innerText = `$${totalPrice}`;

    // Show the summary
    document.getElementById('summary').style.display = 'block';

    // Show the "Pay Now" button by adding the "show" class
    document.getElementById('payNowButton').classList.add('show');
}

async function processPayment() {
    const orderDetails = {
        car: "1957 Chevrolet Bel Air",
        color: document.getElementById('color').value,
        interior: document.getElementById('interior').value,
        wheels: document.getElementById('wheels').value,
        totalPrice: totalPrice
    };

    try {
        const response = await fetch('http://localhost:5088/api/payments/process', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(orderDetails),
        });

        if (response.ok) {
            document.getElementById('summary').style.display = 'none';
            document.getElementById('thankYouMessage').style.display = 'block';
            alert('Payment successful! Your order has been processed.');
        } else {
            alert('Payment failed. Please try again.');
        }
    } catch (error) {
        console.error("🚨 Payment Error:", error);
        alert('An error occurred while processing your payment.');
    }
}
