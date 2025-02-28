const basePrice = 45000;
let totalPrice = basePrice;

function showSummary() {
    const color = document.getElementById('color').value;
    const interior = document.getElementById('interior').value;
    const wheels = document.getElementById('wheels').value;

    const colorPrice = color.includes('Red') || color.includes('Blue') || color.includes('Black') || color.includes('White') ? 500 : 0;
    const interiorPrice = interior.includes('Leather') ? 1000 : 500;
    const wheelsPrice = wheels.includes('Alloy') ? 1500 : wheels.includes('Chrome') ? 2000 : 0;

    totalPrice = basePrice + colorPrice + interiorPrice + wheelsPrice;

    document.getElementById('summaryList').innerHTML = `
        <li>Color: ${color} (+$${colorPrice})</li>
        <li>Interior: ${interior} (+$${interiorPrice})</li>
        <li>Wheels: ${wheels} (+$${wheelsPrice})</li>
    `;
    document.getElementById('totalPrice').innerText = `$${totalPrice}`;
    document.getElementById('summary').style.display = 'block';
}

function payNow() {
    document.getElementById('summary').style.display = 'none';
    document.getElementById('thankYouMessage').style.display = 'block';
}